using AutoMapper;
using Microsoft.AspNetCore.Identity;
using UserAPI.Data.DTOs;
using UserAPI.Models;

namespace UserAPI.Services
{
    public class UserService
    {
        //This class will make the logic behind the requisition, either sign in up in the db or not
        private IMapper _mapper;

        private UserManager<User> _userManager;
        private SignInManager<User> _signInManager;
        private TokenService _tokenService;

        public UserService(IMapper mapper, UserManager<User> userManager, SignInManager<User> signInManager, TokenService tokenService)
        {
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
        }

        //async is made for a method that will run until an await is found, then method is suspended and waits for task to complete
        //a task is some asynchronous operation
        public async Task SignIn(CreateUserDTO userDto)
        {
            User user = _mapper.Map<User>(userDto);

            IdentityResult result = await _userManager.CreateAsync(user, userDto.Password);

            if(!result.Succeeded)
            {
                throw new ApplicationException("Error while trying to Sign In User.");
            }
        }

        public async Task<string> Login(LoginUserDTO userDto)
        {
            var resultado = await _signInManager.PasswordSignInAsync(userDto.Username, userDto.Password, false, false);

            if(!resultado.Succeeded)
            {
                throw new ApplicationException("Error while trying to Login User");
            }
            var user = _signInManager.UserManager.Users.FirstOrDefault(user => user.NormalizedUserName == userDto.Username.ToUpper());

            var token = _tokenService.GenerateToken(user);

            return token;
        }
    }
}

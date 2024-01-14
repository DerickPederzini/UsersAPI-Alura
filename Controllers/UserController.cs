using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UserAPI.Data.DTOs;
using UserAPI.Models;

namespace UserAPI.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class UserController : ControllerBase
    {
        private IMapper _mapper;
        private UserManager<User> _userManager;

        public UserController(IMapper mapper, UserManager<User> userManager)
        {
            _mapper = mapper;
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> SignUser(CreateUserDTO userDto)
        {

            User user = _mapper.Map<User>(userDto);

            IdentityResult result = await _userManager.CreateAsync(user, userDto.Password);

            if (result.Succeeded) return Ok("User Signed!");
            throw new ApplicationException("Error while trying to sign user.");
         }

    }
}

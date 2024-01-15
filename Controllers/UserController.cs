using Microsoft.AspNetCore.Mvc;
using UserAPI.Data.DTOs;
using UserAPI.Services;

namespace UserAPI.Controllers
{
    //o papel do controlador é lidar com as requisições e não com a lógica por trás delas
    [ApiController]
    [Route("[Controller]")]
    public class UserController : ControllerBase
    {
        private UserService _userService;

        public UserController(UserService signService)
        {
            _userService = signService;
        }

        //permite que o usuario realize cadastro 
        [HttpPost("signIn")]
        public async Task<IActionResult> SignUser(CreateUserDTO userDto)
        {
            await _userService.SignIn(userDto);
            return Ok("User Signed!");
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync(LoginUserDTO userDto )
        {
            var token = await _userService.Login(userDto);
            return Ok(token);
        } 

    }
}

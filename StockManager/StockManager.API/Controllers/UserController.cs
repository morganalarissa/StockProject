using Microsoft.AspNetCore.Mvc;
using StockManager.API.Models;
using StockManager.Application.DTOs;
using StockManager.Application.Interfaces;
using StockManager.Domain.Account;

namespace StockManager.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IAuthenticate _authenticateService;
        private readonly IUserService _userService;

        public UserController(IAuthenticate authenticateService, IUserService userService)
        {
            _authenticateService = authenticateService;
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<ActionResult <UserToken>> Create(UserDTO userDTO)
        {
            if (userDTO == null) 
            {
                return BadRequest("Invalid data");
            }

            var emailExist = await _authenticateService.UserExists(userDTO.Email);

            if (emailExist) 
            {
                return BadRequest("Email already registred");
            }

            var user = await _userService.Create(userDTO);
            if (user == null) 
            {
                return BadRequest("Error when registering");
            }

            //var token = _authenticateService.GenerateToken(user.Id, user.Email);
            //return new UserToken
            //{
            //    Token = token,
            //};

            return Ok(new {message = "user successfully registered !!!" });
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserToken>> Select(LoginModel loginModel)
        {
            var exist = await _authenticateService.UserExists(loginModel.Email);
            if (!exist) 
            {
                return Unauthorized("User dont exist");
            }

            var result = await _authenticateService.AuthenticateAsync(loginModel.Email, loginModel.Password);
            if (!result)
            {
                return Unauthorized("User or password invalid");
            }
            var user = await _authenticateService.GetUserByEmail(loginModel.Email);

            var token = _authenticateService.GenerateToken(user.Id, user.Email);

            return new UserToken
            {
                Token = token,
            };
        }
    }
}

using System;
using IiotApi.Helpers;
using IiotApi.Models;
using IiotApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace IiotApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private IUserService userService;

        public UsersController(IUserService _userService)
        {
            userService = _userService;
        }

        [HttpPost("authenticate")]
        public IActionResult Authenticate(AuthenticateRequest model)
        {
            var response = userService.Authenticate(model);

            if (response == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(response);
        }

        [Authorize]
        [HttpGet]
        public IActionResult GetAll()
        {
            var users = userService.GetAll();
            return Ok(users);
        }
    }
}
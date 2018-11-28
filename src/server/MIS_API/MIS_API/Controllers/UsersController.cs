using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MIS_API.Dtos;
using MIS_API.Models;
using MIS_API.Services;

namespace MIS_API.Controllers
{
    [Authorize(Roles = "SU,Admin")]
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate(LoginDto login)
        {
            var user = _userService.Authenticate(login.Username, login.Password);

            if (user == null)
                return Ok(new ErrorModel{ Message = "Username or password is incorrect", HasError = true });

            return Ok(user.Token);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _userService.GetAll();
            return Ok(users);
        }
        [AllowAnonymous]
        [HttpPost("register/username={username}&password={password}")]
        public async Task<IActionResult> Register(string username, string password)
        {
            var userToCreate = new User
            {
                Username = username
            };

            await _userService.Register(userToCreate, password);

            return Ok();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MIS_API.Models;
using MIS_API.Repositories;

namespace MIS_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        //private readonly IAuthRepository _repo;
        //public AuthController(IAuthRepository repo)
        //{
        //    _repo = repo;
        //}

        //[HttpPost("register")]
        //public async Task<IActionResult> Register(string username, string password)
        //{
        //    var userToCreate = new User
        //    {
        //        Username = username
        //    };

        //    var createdUser = await _repo.Register(userToCreate, password);

        //    return Ok(createdUser);
        //}

        //[HttpGet("login")]
        //public async Task<IActionResult> Login(string username, string password)
        //{
        //    var user = await _repo.Login(username, password);

        //    return Ok(user);
        //}
    }
}
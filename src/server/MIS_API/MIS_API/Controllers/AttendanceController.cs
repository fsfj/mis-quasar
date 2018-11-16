using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MIS_API.Repositories;

namespace MIS_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttendanceController : ControllerBase
    {
        private readonly IAttendanceRepository _repo;
        public AttendanceController(IAttendanceRepository repo)
        {
            _repo = repo;
        }
        [HttpGet]
        [ApiExplorerSettings(GroupName = "v1")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _repo.GetAll());
        }

        [HttpGet("{id}")]
        [ApiExplorerSettings(GroupName = "v2")]
        public IActionResult Get(int id)
        {
            return Ok(1);
        }
    }

}
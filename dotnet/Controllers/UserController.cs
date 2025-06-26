using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using dotnet.Dtos;
using dotnet.Models;
using dotnet.Services.UserService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace dotnet.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;

        public UserController(IUserService service)
        {
            _service = service;
        }
        [Authorize]
        [HttpGet("allusers")]
        public async Task<ActionResult<ServiceResponse<List<GetUserDto>>>> GetAllUsers()
        {
            return Ok(await _service.GetAllUsers());
        }
        [Authorize]
        [HttpGet("data")]
        public async Task<ActionResult<ServiceResponse<GetUserDto>>> GetUserData()
        {
            return Ok(await _service.GetUserData());
        }
        [Authorize]
        [HttpPost("addnewdata")]
        public async Task<ActionResult<ServiceResponse<List<GetUserDto>>>> AddUserData(GetUserDto newUser)
        {
            return Ok(await _service.AddUserData(newUser));

        }
        [Authorize]
        [HttpPut("update")]
        public async Task<ActionResult<ServiceResponse<GetUserDto>>> UpdateUserData(GetUserDto updateUser)
        {
            return Ok(await _service.UpdateUserData(updateUser));
        }
    

        
    }
}
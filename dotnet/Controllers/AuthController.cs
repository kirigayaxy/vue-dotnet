using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace dotnet.Controllers
{
    [Route("[controller]")]
    public class AuthController : Controller
    {
        private readonly IAuthRepository _authRepository;
        public AuthController(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }
        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<ActionResult<ServiceResponse<int>>> Register([FromBody] UserRegisterDto request)
        {
            var response = await _authRepository.Register(
                new Users { UserName = request.UserName, Role = request.Role }, request.Password);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<ActionResult<ServiceResponse<string>>> Login([FromBody] UserLoginDto request)
        {
            var response = await _authRepository.Login(request.UserName, request.Password);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
    }
}
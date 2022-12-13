using DevopsAPI.Models.Dto.Request;
using DevopsAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DevopsAPI.Controller
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccount _account;

        public AccountController(IAccount account)
        {
            _account = account;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var result = await _account.GetByIdAsync(id);
            return result.IsSuccess
                ? Ok(result)
                : BadRequest(result);
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] RegisterDto dto)
        {
            var result = await _account.CreateAsync(dto);
            return result.IsSuccess
                ? CreatedAtAction("Create", result)
                : BadRequest(result);
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto dto)
        {
            var result = await _account.LoginAsync(dto);
            return result.IsSuccess
                ? Ok(result)
                : BadRequest(result);
        }

        [HttpGet("verify-email")]
        public async Task<IActionResult> VerifyEmail(string id, string verificationToken)
        {
            var result = await _account.VerifyEmailAsync(id, verificationToken);
            return result.IsSuccess
                ? Ok(result)
                : BadRequest(result);
        }


        [HttpPut("{id}/password")]
        public async Task<IActionResult> ChangePassword(string id, [FromBody] ChangePasswordDto dto)
        {
            var result = await _account.ChangePasswordAsync(id, dto);
            return result.IsSuccess
                ? Ok(result)
                : BadRequest(result);
        }


        [HttpPut("{id}/reactivate")]
        public async Task<IActionResult> Reactivate(string id)
        {
            var result = await _account.ReactivateAsync(id);
            return result.IsSuccess
                ? Ok(result)
                : BadRequest(result);
        }

        [HttpPut("{id}/deactivate")]
        public async Task<IActionResult> Deactivate(string id)
        {
            var result = await _account.DeactivateAsync(id);
            return result.IsSuccess
                ? Ok(result)
                : BadRequest(result);
        }

    }
}

using Mango.Services.AuthApi.Models.Dto;
using Mango.Services.AuthApi.Service.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Mango.Services.AuthApi.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthApiController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly ResponseDto _responseDto;

        public AuthApiController(IAuthService authService) 
        {
            _authService = authService;
            _responseDto = new();
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterationRequestDTO registerationRequestDTO)
        {
            var errorMsg = await _authService.Register(registerationRequestDTO);
            if (!string.IsNullOrEmpty(errorMsg)) 
            {
                _responseDto.IsSuccess = false;
                _responseDto.Message = errorMsg;

                return BadRequest(_responseDto);
            }

            return Ok();
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDTO loginRequestDTO)
        {
            var loginRes = await _authService.Login(loginRequestDTO);
            if(loginRes.User == null)
            {
                _responseDto.IsSuccess = false;
                _responseDto.Message = "Username or password is Invalid";
                return BadRequest(_responseDto);
            }
            _responseDto.Result = loginRes;
            return Ok(_responseDto);
        }

    }
}

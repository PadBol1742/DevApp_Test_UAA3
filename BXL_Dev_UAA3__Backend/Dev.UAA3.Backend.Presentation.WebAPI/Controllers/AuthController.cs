using Dev.UAA3.Backend.Domain.Models;
using Dev.UAA3.Backend.Domain.Services;
using Dev.UAA3.Backend.Presentation.WebAPI.Dto.Request;
using Dev.UAA3.Backend.Presentation.WebAPI.Dto.Response;
using Dev.UAA3.Backend.Presentation.WebAPI.Tools;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dev.UAA3.Backend.Presentation.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class AuthController : ControllerBase
    {
        private readonly IMemberService _memberService;
        private readonly TokenTool _tokenTool;
        public AuthController(IMemberService memberService, TokenTool tokenTool)
        {
            _memberService = memberService;
            _tokenTool = tokenTool;
        }

        [HttpPost("Login")]
        public IActionResult Login([FromBody] AuthLoginRequestDto loginDto)
        {
            Member member = _memberService.Login(loginDto.Email, loginDto.Password);

            return Ok(new AuthResponseDto()
            {
                Token = _tokenTool.GenerateJWT(member.Id)
            });
        }

        [HttpPost("Register")]
        public IActionResult Register([FromBody] AuthRegisterRequestDto registerDto)
        {
            Member member = _memberService.Register(registerDto.Email, registerDto.Password);

            return Ok(new AuthResponseDto()
            {
                Token = _tokenTool.GenerateJWT(member.Id)
            });
        }
    }
}

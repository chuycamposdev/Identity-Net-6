using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tickets.Application.Dtos.Authorization;
using Tickets.Application.Features.Account.Commands.ConfirmEmail;
using Tickets.Application.Interfaces.Account;
using System.IO;
using Tickets.Application.Features.Account.Commands.Login;
using Tickets.Application.Features.Account.Commands.RegisterUser;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class AccountController : BaseApiController
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login(SigninUserCommand request)
        {
            return Ok(await Mediator.Send(request));
        }

        [HttpPost("register-account")]
        public async Task<IActionResult> RegisterUser(RegisterUserCommand request)
        {
            return Ok(await Mediator.Send(request));
        }

        [HttpPost("refresh-token")]
        public async Task<IActionResult> RefreshToken(RefreshTokenDto refreshTokenDto)
        {
            var refreshToken = await _accountService.RefreshToken(refreshTokenDto);
            return Ok(refreshToken);
        }

        [HttpGet("confirmation-email")]
        public async Task<ContentResult> ConfirmEmailAccount([FromQuery] string email, [FromQuery] string confirmationToken)
        {
            try
            {
                var isEmailConfirmed = await Mediator.Send<bool>(new ConfirmEmailCommand
                {
                    ConfirmationToken = confirmationToken,
                    Email = email
                });

                string pathToRead = isEmailConfirmed ? "EmailConfirmed.html" : "EmailNotConfirmed.html";

                var htmlContent = System.IO.File.ReadAllText($"TemplatesAPI/{pathToRead}");
                return new ContentResult { Content = htmlContent, ContentType = "text/html" };
            }
            catch (Exception ex)
            {
                var htmlContent = System.IO.File.ReadAllText("TemplatesAPI/EmailNotConfirmed.html");
                return new ContentResult { Content = htmlContent, ContentType = "text/html" };
            }

        }
    }
}

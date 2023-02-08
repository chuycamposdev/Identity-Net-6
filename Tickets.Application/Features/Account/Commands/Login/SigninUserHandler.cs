using MediatR;
using Tickets.Application.Dtos.Authorization;
using Tickets.Application.Features.Account.Commands.Login;
using Tickets.Application.Interfaces.Account;
using Tickets.Application.Models;

namespace Tickets.Application.Features.Account.Login
{
    public class SigninUserHandler : IRequestHandler<SigninUserCommand, ResponseGenericModel<UserDto>>
    {
        private readonly IAccountService _accountService;

        public SigninUserHandler(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public async Task<ResponseGenericModel<UserDto>> Handle(SigninUserCommand request, CancellationToken cancellationToken)
        {
            var login = new LoginModel(request.Email, request.Password);
            var user = await _accountService.LoginAsync(login);
            return new ResponseGenericModel<UserDto>(user);
        }
    }
}

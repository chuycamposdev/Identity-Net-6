using MediatR;
using Tickets.Application.Abstractions.Messaging;
using Tickets.Application.Dtos.Authorization;
using Tickets.Application.Features.Account.Commands.Login;
using Tickets.Application.Interfaces.Account;
using Tickets.Application.Models;

namespace Tickets.Application.Features.Account.Login
{
    public class SigninUserHandler : IQueryHandler<SigninUserCommand, UserDto>
    {
        private readonly IAccountService _accountService;

        public SigninUserHandler(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public async Task<OperationResult<UserDto>> Handle(SigninUserCommand request, CancellationToken cancellationToken)
        {
            var login = new LoginModel(request.Email, request.Password);
            var user = await _accountService.LoginAsync(login);
            if (user == null)
                return OperationResult<UserDto>.Error("Login not valid");
            return OperationResult<UserDto>.Success(user);
        }
    }
}

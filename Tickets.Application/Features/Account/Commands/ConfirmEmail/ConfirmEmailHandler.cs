using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tickets.Application.Interfaces.Account;

namespace Tickets.Application.Features.Account.Commands.ConfirmEmail
{
    public class ConfirmEmailHandler : IRequestHandler<ConfirmEmailCommand, bool>
    {
        private readonly IAccountService _accountService;

        public ConfirmEmailHandler(IAccountService accountService)
        {
            _accountService = accountService;   
        }

        public async Task<bool> Handle(ConfirmEmailCommand request, CancellationToken cancellationToken)
        {
            return await _accountService.ConfirmateAccount(request.ConfirmationToken, request.Email);
        }
    }
}

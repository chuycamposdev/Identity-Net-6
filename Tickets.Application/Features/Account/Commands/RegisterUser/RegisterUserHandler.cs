using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tickets.Application.Dtos.Authorization;
using Tickets.Application.Facades;
using Tickets.Application.Interfaces.Account;
using Tickets.Application.Interfaces.Email;
using Tickets.Application.Models;

namespace Tickets.Application.Features.Account.Commands.RegisterUser
{
    public class RegisterUserHandler : IRequestHandler<RegisterUserCommand, ResponseModel>
    {
        private readonly IAccountService _accountService;
        private readonly EmailFacade _emailFacade;

        public RegisterUserHandler(IAccountService accountService, EmailFacade emailFacade)
        {
            _accountService = accountService;
            _emailFacade = emailFacade;
        }

        public async Task<ResponseModel> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var registerModel = new RegisterModel(request.FirstName, request.LastName, request.Email,
                                                    request.PhoneNumber, request.Password);

            string userId = await _accountService.RegisterAccountAsync(registerModel);
            string confirmationToken = await _accountService.GenerateConfirmationTokenAsync(userId);
            await _emailFacade.SendRegistrationEmailAsync(registerModel.Email, registerModel.FirstName, confirmationToken);

            return new ResponseModel();
        }
    }
}

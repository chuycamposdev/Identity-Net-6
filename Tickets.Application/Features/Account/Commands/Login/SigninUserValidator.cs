using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tickets.Application.Features.Account.Commands.Login
{
    public class SigninUserValidator : AbstractValidator<SigninUserCommand>
    {
        public SigninUserValidator()
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("{PropertyName} is required.")
                                    .NotNull().WithMessage("{PropertyName} is required.");

            RuleFor(x => x.Password).NotEmpty().WithMessage("{PropertyName} is required.")
                                    .NotNull().WithMessage("{PropertyName} is required.");
        }
    }
}

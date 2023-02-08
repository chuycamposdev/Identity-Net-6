using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tickets.Application.Features.Account.Commands.RegisterUser
{
    public class RegisterUserValidator : AbstractValidator<RegisterUserCommand>
    {
        public RegisterUserValidator()
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("{PropertyName} is required.")
                                   .NotNull().WithMessage("{PropertyName} is required.")
                                   .EmailAddress();

            RuleFor(x => x.Password).NotEmpty().WithMessage("{PropertyName} is required.")
                                    .NotNull().WithMessage("{PropertyName} is required.");

            RuleFor(x => x.FirstName).NotEmpty().WithMessage("{PropertyName} is required.")
                                   .NotNull().WithMessage("{PropertyName} is required.");

            RuleFor(x => x.LastName).NotEmpty().WithMessage("{PropertyName} is required.")
                                    .NotNull().WithMessage("{PropertyName} is required.");

            RuleFor(x => x.PhoneNumber).MinimumLength(10).WithMessage("{PropertyName} min length invalid")
                                        .NotEmpty().WithMessage("{PropertyName} is required.")
                                        .NotNull().WithMessage("{PropertyName} is required.");
        }
    }
}

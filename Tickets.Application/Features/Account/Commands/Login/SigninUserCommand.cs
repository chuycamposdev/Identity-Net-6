using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tickets.Application.Abstractions.Messaging;
using Tickets.Application.Dtos.Authorization;
using Tickets.Application.Models;

namespace Tickets.Application.Features.Account.Commands.Login
{
    public class SigninUserCommand :  IQuery<UserDto>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}

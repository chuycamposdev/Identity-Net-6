using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tickets.Application.Features.Account.Commands.ConfirmEmail
{
    public class ConfirmEmailCommand : IRequest<bool>
    {
        public string Email { get; set; }   
        public string ConfirmationToken { get; set; }
    }
}

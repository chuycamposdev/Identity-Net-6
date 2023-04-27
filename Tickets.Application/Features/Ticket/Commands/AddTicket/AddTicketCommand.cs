using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tickets.Application.Abstractions.Messaging;
using Tickets.Application.Models;

namespace Tickets.Application.Features.Ticket.Commands.AddTicket
{
    public class AddTicketCommand : ICommand
    {
        public string Nombre { get; set; }
    }
}

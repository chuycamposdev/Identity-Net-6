using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tickets.Application.Models;

namespace Tickets.Application.Features.Ticket.Commands.UpdateTicket
{
    public class UpdateTicketCommand : IRequest<OperationResult>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}

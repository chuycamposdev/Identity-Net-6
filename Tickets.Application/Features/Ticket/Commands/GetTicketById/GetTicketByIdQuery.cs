using Tickets.Application.Abstractions.Messaging;
using Tickets.Application.Dtos.Ticket;
using Tickets.Application.Models;

namespace Tickets.Application.Features.Ticket.Commands.GetTicketById
{
    public class GetTicketByIdQuery : IQuery<TicketDto>
    {
        public int Id { get; set; }
    }
}

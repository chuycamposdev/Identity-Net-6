
using Tickets.Application.Abstractions.Messaging;
using Tickets.Application.Dtos.Ticket;

namespace Tickets.Application.Features.Ticket.Queries.GetCommentsByTicketId
{
    public class GetCommentsByTicketIdQuery : IQuery<List<TicketCommentDto>>
    {
        public int TicketId { get; set; }
    }
}

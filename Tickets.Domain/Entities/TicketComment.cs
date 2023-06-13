using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tickets.Domain.Entities
{
    public class TicketComment
    {
        public int TicketCommentId { get; set; }
        public string Comment { get; set; } = null!;
        public int TicketId { get; set; }
        public Ticket Ticket { get; set; }
    }
}

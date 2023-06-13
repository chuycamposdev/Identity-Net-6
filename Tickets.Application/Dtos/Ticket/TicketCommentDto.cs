using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tickets.Application.Dtos.Ticket
{
    public class TicketCommentDto
    {
        public int TicketCommentId { get; set; }
        public string TicketName { get; set; }
        public string Comment { get; set; }
    }
}

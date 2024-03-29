﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tickets.Domain.Entities
{
    public class Ticket
    {
        public int TicketId { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaCreacion { get; set; }
        public List<TicketComment> TicketComments { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tickets.Application.Interfaces.Repositories;
using Tickets.Domain.Entities;

namespace Tickets.Infraestructure.Persistence.Repositories
{
    public class TicketCommentRepository : GenericRepository<TicketComment>, ITicketCommentRepository
    {

        public TicketCommentRepository(ApplicationContext context) :base(context)
        {
        }

    }
}

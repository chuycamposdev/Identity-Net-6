using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tickets.Domain.Entities;

namespace Tickets.Application.Interfaces.Repositories
{
    public interface ITicketRepository: IRepository<Ticket>
    {
    }
}

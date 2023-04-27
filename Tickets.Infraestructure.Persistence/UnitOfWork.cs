using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tickets.Application.Interfaces.Repositories;
using Tickets.Infraestructure.Persistence.Repositories;

namespace Tickets.Infraestructure.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationContext _applicationContext;

        public UnitOfWork(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public void Commit()
        {
            _applicationContext.SaveChanges();
        }
    }
}

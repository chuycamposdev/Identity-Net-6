using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Tickets.Application.Interfaces.Repositories
{
    public interface IRepository<T> 
    {
        T GetById(object id);

        public IEnumerable<T> GetByCondition(
        Expression<Func<T, bool>> filter = null,
        Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
        string includeProperties = "");

        void Insert(T entity);

        void Update(T entityToUpdate);
    }


}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LManagement.Data.Repository.IRepository {
    public interface IRepository<T> where T : class {
        IEnumerable<T> GetAll(Expression<Func<T, bool>>? expression = null);
        T GetBy(Expression<Func<T, bool>> expression);
        void AddToDatabase(T entity);
        void RemoveFromDatabase(T entity);
        void RemoveRangeFromDatabase(IEnumerable<T> entities);
    }
}

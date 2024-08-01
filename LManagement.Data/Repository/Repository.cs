using LManagement.Data.DBContext;
using LManagement.Data.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LManagement.Data.Repository {
    public class Repository<T> : IRepository<T> where T : class {

        private readonly LManagementDbContext _lManagementDbContext;
        internal DbSet<T> _dbSet;

        public Repository(LManagementDbContext _db) { 
            _lManagementDbContext = _db;
            _dbSet = _lManagementDbContext.Set<T>(); 
        }

        public void AddToDatabase(T entity) {
            _dbSet.Add(entity);
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>>? expression = null) {
            IQueryable<T> query = _dbSet;
            if (expression != null) {
                return query.Where(expression);
            }
            return query.ToList();
        }

        public T GetBy(Expression<Func<T, bool>> expression) {

            var query = _dbSet.Where(expression).FirstOrDefault();

            if (query != null) {
                return query;
            }

            return null;
        }

        public void RemoveFromDatabase(T entity) {
            _dbSet.Remove(entity);
        }

        public void RemoveRangeFromDatabase(IEnumerable<T> entities) {
            _dbSet.RemoveRange(entities);
        }
    }
}

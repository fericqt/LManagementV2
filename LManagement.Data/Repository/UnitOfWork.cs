using LManagement.Data.DBContext;
using LManagement.Data.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LManagement.Data.Repository {
    public class UnitOfWork : IUnitOfWork {

        private readonly LManagementDbContext _lManagementDbContext;
        public IUserRepo UserRepo { get; private set; }

        public UnitOfWork(LManagementDbContext _db) { 
            _lManagementDbContext = _db;
            UserRepo = new UserRepo(_db);
        }
        public void Save() {
            _lManagementDbContext.SaveChanges();
        }
    }
}

using LManagement.Data.DBContext;
using LManagement.Data.Repository.IRepository;
using LManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LManagement.Data.Repository {
    public class UserRepo : Repository<User>, IUserRepo {
        private LManagementDbContext _lManagementDbContext;
        public UserRepo(LManagementDbContext _db) : base(_db) {
            _lManagementDbContext = _db;
        }

        public void Update(User user) {
            _lManagementDbContext.Update(user);
        }
    }
}

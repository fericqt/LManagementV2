using LManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LManagement.Data.Repository.IRepository {
    public interface IUserRepo : IRepository<User> {
        void Update(User user);
    }
}

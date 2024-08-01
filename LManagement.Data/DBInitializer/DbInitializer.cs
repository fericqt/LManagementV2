using LManagement.Data.DBContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LManagement.Data.DBInitializer {
    public class DbInitializer : IDbInitializer {

        private readonly LManagementDbContext _lManagementDbContext;
        public DbInitializer(LManagementDbContext _db) {
            _lManagementDbContext = _db;
        }
        public void Initialize() {
            try {
                if(_lManagementDbContext.Database.GetPendingMigrations().Count() > 0) {
                    _lManagementDbContext.Database.Migrate();
                }
            }
            catch (Exception) {

            }
            return;
        }
    }
}

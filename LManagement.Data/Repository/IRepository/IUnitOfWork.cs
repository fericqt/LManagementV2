﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LManagement.Data.Repository.IRepository {
    public interface IUnitOfWork {
        IUserRepo UserRepo { get; }
        void Save();
    }
}

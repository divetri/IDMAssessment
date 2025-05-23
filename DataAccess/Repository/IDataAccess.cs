﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IDataAccess
    {
        ICustomerDataAccess Customer { get; }
        void BeginTransaction();
        void CommitTransaction();
        void RollbackTransaction();
    }
}

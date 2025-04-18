using DataAccess;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class DataAccessManager : IDataAccess
    {
        private readonly DataAccessContext _context;
        private readonly Lazy<ICustomerDataAccess> _customerDA;
        public DataAccessManager(DataAccessContext context)
        {
            _context = context;
            _customerDA = new Lazy<ICustomerDataAccess>(() => new CustomerDataAccess(context));
        }
        public ICustomerDataAccess Customer => _customerDA.Value;

        public void BeginTransaction() => _context.Database.BeginTransaction();

        public void CommitTransaction() => _context.Database.CommitTransaction();

        public void RollbackTransaction() => _context.Database.RollbackTransaction();
    }
}

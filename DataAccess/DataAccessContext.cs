using DomainObject;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repository
{
    public class DataAccessContext : DbContext
    {
        public DataAccessContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Customer>? Customers { get; set; }
    }
}
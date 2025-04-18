using DomainObject;

namespace DataAccess.Repository
{
    public interface ICustomerDataAccess
    {
        Customer Create(CustomerCreateRequest customer);
        IEnumerable<Customer> Select(CustomerRequest filter);
        Customer Update(CustomerUpdateRequest customer);
        bool Delete(CustomerDeleteRequest customer);
    }
}

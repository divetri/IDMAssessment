using DomainObject;
namespace BusinessFacade
{
    public interface ICustomerFacade
    {
        public IEnumerable<Customer> Select(CustomerRequest customer);
        public Customer Create(CustomerCreateRequest customer);
        public Customer Update(CustomerUpdateRequest customer);
        public bool Delete(CustomerDeleteRequest customer);
    }
}
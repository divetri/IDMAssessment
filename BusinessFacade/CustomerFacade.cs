using BusinessFacade;
using DataAccess.Repository;
using DomainObject;

namespace Services
{
    public class CustomerFacade : ICustomerFacade
    {
        private readonly IDataAccess _dataAccess;
        public CustomerFacade(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public IEnumerable<Customer> Select(CustomerRequest customer)
        {
            try
            {
                var customers = _dataAccess.Customer.Select(customer);
                return customers;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Customer Create(CustomerCreateRequest customer)
        {
            try
            {
                var result = _dataAccess.Customer.Create(customer);
                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Customer Update(CustomerUpdateRequest customer)
        {
            try
            {
                var result = _dataAccess.Customer.Update(customer);
                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public bool Delete(CustomerDeleteRequest customer)
        {
            try
            {
                var result = _dataAccess.Customer.Delete(customer);
                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}
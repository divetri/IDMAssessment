using BusinessFacade;
using DataAccess.Repository;

namespace Services
{
    public sealed class ServiceManager : IServiceManager
    {
        private readonly Lazy<ICustomerFacade> _customerFacade;
        public ServiceManager(IDataAccess dataAccess)
        {
            _customerFacade = new Lazy<ICustomerFacade>(() => new CustomerFacade(dataAccess));
        }
        public ICustomerFacade CustomerFacade => _customerFacade.Value;
    }
}

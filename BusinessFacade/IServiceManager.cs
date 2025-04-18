namespace BusinessFacade
{
    public interface IServiceManager
    {
        ICustomerFacade CustomerFacade { get; }
    }
}
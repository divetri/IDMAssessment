namespace DomainObject
{
    public class BasicResponse<T>
    {
        public string Message { get; set; } = string.Empty;
        public string TransactionId { get; set; } = Guid.NewGuid().ToString();
        public T? Data { get; set; }
    }
}

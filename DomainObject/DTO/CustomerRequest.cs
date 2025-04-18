using System.ComponentModel.DataAnnotations;

namespace DomainObject
{
    public class CustomerRequest
    {
        public int? CustomerId { get; set; }
        [MaxLength(50)]
        public string? CustomerCode { get; set; }
        [MaxLength(255)]
        public string? CustomerName { get; set; }
        [MaxLength(1000)]
        public string? CustomerAddress { get; set; } = string.Empty;
    }
    public class CustomerCreateRequest
    {
        [Required(ErrorMessage = "required field")]
        [MaxLength(50)]
        public string? CustomerCode { get; set; }
        [Required(ErrorMessage = "required field")]
        [MaxLength(255)]
        public string? CustomerName { get; set; }
        [MaxLength(1000)]
        public string? CustomerAddress { get; set; } = string.Empty;
        public int? CreatedBy { get; set; }
    }
    public class CustomerUpdateRequest
    {
        [Required(ErrorMessage = "required field")]
        public int? CustomerId { get; set; }
        [MaxLength(50)]
        public string? CustomerCode { get; set; }
        [MaxLength(255)]
        public string? CustomerName { get; set; }
        [MaxLength(1000)]
        public string? CustomerAddress { get; set; } = string.Empty;
        public int? ModifiedBy { get; set; }
    }

    public class CustomerDeleteRequest
    {
        [Required(ErrorMessage = "required field")]
        public int? CustomerId { get; set; }
    }
}
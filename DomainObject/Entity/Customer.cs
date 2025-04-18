using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DomainObject
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        [Required(ErrorMessage = "required field")]
        [MaxLength(50)]
        public string CustomerCode { get; set; }
        [Required(ErrorMessage = "required field")]
        [MaxLength(255)]
        public string CustomerName { get; set; }
        [MaxLength(1000)]
        public string CustomerAddress { get; set; } = string.Empty;
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedAt { get; set; }
    }
}

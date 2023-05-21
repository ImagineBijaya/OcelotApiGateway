using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerService.Context
{
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int  CustomerId { get; set; }
       
        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string? CustomerName { get; set; }
        public string? CustomerEmail { get; set; }  
        public string? CustomerPhone { get; set; } 
        public string? CustomerCity { get; set; } 
       
    }
}

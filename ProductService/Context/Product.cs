using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductService.Context
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductId { get; set; }
        public string? ProductName { get; set; } 
        public string? ProductUnit { get; set; }
        public string ProductPrice { get; set; } ="0"!;

    }
}

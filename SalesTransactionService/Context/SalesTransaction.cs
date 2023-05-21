using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SalesTransactionService.Context
{
    public class SalesTransaction
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SalesTransactionId { get; set; }
        public int ProductId { get; set; }
        public int CustomerId { get; set; }
        public float Quantity { get; set; }
        public bool IsInvoiced { get; set; }
        
    }
}

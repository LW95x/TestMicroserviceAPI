using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MicroserviceAPI.Orders
{
    public class Order
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        [Range(0.01, 100000.00, ErrorMessage = "Price must be between £0.01 and £100,000.")]
        public decimal Price { get; set; }

        public Order(string title, decimal price)
        {
            Title = title;
            Price = price;
        }
    }
}

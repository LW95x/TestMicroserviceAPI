using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MicroserviceAPI.Payments
{
    public class Payment
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        [MaxLength(100)]
        public string Address { get; set; }
        [Required]
        [MaxLength(100)]
        public string CardProvider { get; set; }


        public Payment(string name, string address, string cardProvider)
        {
            Name = name;
            Address = address;
            CardProvider = cardProvider;
        }
    }
}

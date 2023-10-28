using System.ComponentModel.DataAnnotations;

namespace ShoppingCart.services.CoupenAPI.Models
{
    public class Coupen
    {
        [Key]
        public int CoupenId { get; set; }
        [Required]
        public string? CoupenCode { get; set; }
        [Required]
        public decimal DiscountAmount { get; set; }
        public int MinAmount { get; set; }

    }
}

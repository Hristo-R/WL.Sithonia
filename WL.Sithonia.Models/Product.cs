namespace WL.Sithonia.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Product
    {
        public int ProductId { get; set; }

        [Required]
        [MaxLength(100)]
        public string ProductName { get; set; }
        
        [Required]
        [Range(0.01, 10000.00)]
        public decimal Price { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ProductsAPI.Domain.DataTransferObject
{
    public class ProductRequest
    {
        
        [Required]
        public string? Name { get; set; }
        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "O valor do preço deve ser maior que 0.")]
        public decimal Price { get; set; }
        [Required]
        public string? Description { get; set; }
    }
}

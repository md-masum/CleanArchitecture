using System.ComponentModel.DataAnnotations;

namespace Application.Requests.Products
{
    public class ProductToCreateDto
    {
        [Required]
        [StringLength(250)]
        public string Name { get; set; }
        
        [Required]
        [StringLength(100)]
        public string Style { get; set; }
        public float Price { get; set; }
        public byte Stock { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;
using Application.Common.Mappings;
using Domain.Entities.Product;

namespace Application.Requests.Products
{
    public class ProductToUpdateDto : IMapFrom<Product>
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
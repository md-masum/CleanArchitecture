using Application.Common.Mappings;
using Domain.Entities.Product;

namespace Application.Requests.Products
{
    public class ProductToReturnDto : IMapFrom<Product>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public byte Stock { get; set; }
    }
}
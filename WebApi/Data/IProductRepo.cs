using System.Collections.Generic;
using Domain.Entities.Product;

namespace WebApi.Data
{
    public interface IProductRepo
    {
        bool SaveChanges();
        IEnumerable<Product> GetProducts();
        Product GetProductById(int id);
        void CreateProduct(Product product);
        void DeleteProduct(Product product);
    }
}
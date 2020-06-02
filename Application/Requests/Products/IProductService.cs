using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Common.Results;
using Domain.Entities.Product;

namespace Application.Requests.Products
{
    public interface IProductService : IDisposable
    {
        Task<IList<Product>> GetProducts();
        Task<Product> GetProductById(int id);
        Task<Result> CreateProduct(Product product);
        Task<Result> DeleteProduct(int id);
    }
}
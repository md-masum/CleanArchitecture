using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Common.Results;
using Application.Requests.Products;
using Domain.Entities.Product;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext _context;

        public ProductService(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task<IList<Product>> GetProducts()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> GetProductById(int id)
        {
            return await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Result> CreateProduct(Product product)
        {
            await _context.AddAsync(product);
            var result = await _context.SaveChangesAsync();
            
            return result > 0 ? Result.Success() : Result.Failure(new List<string> {"can't save product"});
        }

        public async Task<Result> DeleteProduct(int id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);

            if (product == null) return Result.Failure(new List<string> {"can't delete product"});
            _context.Remove(product);
            await _context.SaveChangesAsync();
            return Result.Success();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Entities.Product;
using Infrastructure.Persistence;

namespace WebApi.Data
{
    public class ProductRepo : IProductRepo
    {
        private readonly ApplicationDbContext _context;

        public ProductRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool SaveChanges()
        {
            return _context.SaveChanges() > 0;
        }

        public IEnumerable<Product> GetProducts()
        {
            return _context.Products.ToList();
        }

        public Product GetProductById(int id)
        {
            return _context.Products.FirstOrDefault(p => p.Id == id);
        }

        public void CreateProduct(Product product)
        {
            if (product == null)
            {
                throw new ArgumentNullException(nameof(product));
            }

            _context.Add(product);
        }

        public void DeleteProduct(Product product)
        {
            _context.Remove((object) product);
        }
    }
}
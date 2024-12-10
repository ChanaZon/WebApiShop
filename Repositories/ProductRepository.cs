using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class ProductRepository : IProductRepository
    {
        MyShopContext _context;
        public ProductRepository(MyShopContext context)
        {
            _context = context;
        }

        //public async Task<Product> AddProductAsync(Product product)
        //{
        //    await _context.Products.AddAsync(product);
        //    await _context.SaveChangesAsync();
        //    return product;
        //}

        public async Task<List<Product>> GetProducts()
        {

            return await _context.Products.ToListAsync<Product>();

        }

        public async Task<Product> GetProductById(int id)
        {

            return await _context.Products.FirstOrDefaultAsync<Product>(p => p.ProductId == id);

        }

        //public async Task<Product> UpdateProductAsync(int id, Product productToUpdate)
        //{
        //    if (productToUpdate == null)
        //    {
        //        return null;
        //    }
        //    _context.Update(productToUpdate);
        //    await _context.SaveChangesAsync();
        //    return productToUpdate;
        //}

        //public async void DeleteProductAsync(int id)
        //{
        //    if (id != null)
        //    {
        //        _context.Products.Remove();
        //        await _context.SaveChangesAsync();
        //    }
        //}

    }
}

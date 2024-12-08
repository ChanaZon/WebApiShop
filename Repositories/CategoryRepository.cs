using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        MyShopContext _context;
        public CategoryRepository(MyShopContext context)
        {
            _context = context;
        }

        //public async Task<Product> AddProductAsync(Product product)
        //{
        //    await _context.Products.AddAsync(product);
        //    await _context.SaveChangesAsync();
        //    return product;
        //}

        public async Task<List<Category>> GetCategories()
        {

            return await _context.Categories.ToListAsync<Category>();

        }

        public async Task<Category> GetCategoryById(int id)
        {

            return await _context.Categories.FirstOrDefaultAsync<Category>(p => p.CategoryId == id);

        }
    }
}

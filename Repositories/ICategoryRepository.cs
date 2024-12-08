﻿using Entities.Models;

namespace Repositories
{
    public interface ICategoryRepository
    {
        Task<List<Category>> GetCategories();
        Task<Category> GetCategoryById(int id);
    }
}
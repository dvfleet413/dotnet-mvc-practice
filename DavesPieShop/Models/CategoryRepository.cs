using System;
using System.Collections.Generic;

namespace DavesPieShop.Models
{
    // This class is a little simpler than the PieRepository class - look there for more comments about what's happening
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _appDbContext;

        public CategoryRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Category> AllCategories => _appDbContext.Categories;
    }
}

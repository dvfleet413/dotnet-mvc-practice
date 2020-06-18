using System;
using System.Collections.Generic;

namespace DavesPieShop.Models
{
    // this class contains hard coded mock data that will be replaced when database is connected
    public class MockCategoryRepository : ICategoryRepository
    {
        public IEnumerable<Category> AllCategories =>
            new List<Category>
            {
                new Category{CategoryId=1, CategoryName="Fruit pies", Description="All Fruity Pies" };
                new Category{CategoryId=2, CategoryName="Cheese cakes", Description="Cheesy all the way" };
                new Category{CategoryId=3, CategoryName="Seasonal Pies", Description="Get in the mood for a seasonal pie" };
            };

    }
}

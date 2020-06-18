using System;
using System.Collections.Generic;

namespace DavesPieShop.Models
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> AllCategories { get; }
    }
}

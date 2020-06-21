using System;
using System.Collections.Generic;

namespace DavesPieShop.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        // this establishes a has many relationship
        // in pie model there is public int CategoryId and public Category Category
        public List<Pie> Pies { get; set; }
    }
}

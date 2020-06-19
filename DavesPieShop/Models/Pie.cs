using System;
namespace DavesPieShop.Models
{
    public class Pie
    {
        public int PieId { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public string AllergyInformation { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public string ImageThumbnailUrl { get; set; }
        public bool IsPieOfTheWeek { get; set; }
        public bool InStock { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        // The following is added after the initial migration
        // All we need to do is add a migration (`$ add-migration AddNoteToPie` `$ update-database`) and EF Core takes care of everything! 
        public string Notes { get; set; }
    }
}

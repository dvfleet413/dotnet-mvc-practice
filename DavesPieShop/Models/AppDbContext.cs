using System;
using Microsoft.EntityFrameworkCore;

namespace DavesPieShop.Models
{
    // DbContext sits between our app and the actual database, allows for smooth, code-first approach to database interaction
    public class AppDbContext : DbContext
    {
        // Db Context must have an instance of DbContext options for it to execute, we do that with the following constructor
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        // We need to indicate which entities Db Context will manage (behind the scenes this maps to tables in the actual database)
        public DbSet<Pie> Pies { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}

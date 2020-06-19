using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DavesPieShop.Models
{
    // Pie Repository implements the IPieRepository Interface
    public class PieRepository : IPieRepository
    {
        private readonly AppDbContext _appDbContext;

        // Because we registered AppDbContext in our Startup class, it will be managed by DI container and we can have access to it in our constructor, below
        // Pretty cool...we can create this contructor to just look for an arg of type AppDbContext from constructor injection and assign it to the local field _appDbContext
        public PieRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        // Implementation of IPieRepository - these are the methods that use LINQ to actually get the data we need from the database
        public IEnumerable<Pie> AllPies
        {
            get
            {
                return _appDbContext.Pies.Include(c => c.Category);
            }
        }

        public IEnumerable<Pie> PiesOfTheWeek
        {
            get
            {
                return _appDbContext.Pies.Include(c => c.Category).Where(p => p.IsPieOfTheWeek);
            }
        }

        public Pie GetPieById(int pieId)
        {
            {
                return _appDbContext.Pies.FirstOrDefault(p => p.PieId == pieId);
            }
        }
    }
}

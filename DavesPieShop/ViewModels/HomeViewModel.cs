using System;
using System.Collections.Generic;
using DavesPieShop.Models;

namespace DavesPieShop.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Pie> PiesOfTheWeek { get; set; }
    }
}

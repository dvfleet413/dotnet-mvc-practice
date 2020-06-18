using System;
using System.Collections.Generic;
using DavesPieShop.Models;

namespace DavesPieShop.ViewModels
{
    public class PiesListViewModel
    {
        public IEnumerable<Pie> Pies { get; set; }
        public string CurrentCategory { get; set; }
    }
}

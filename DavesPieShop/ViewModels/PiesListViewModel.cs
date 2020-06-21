using System;
using System.Collections.Generic;
using DavesPieShop.Models;

namespace DavesPieShop.ViewModels
{
    // View Models are used to wrap the data you'll need in a view, in this case an IEnumerable of Pies, along with the Category.
    // Now all the pies and the current category are available in the views
    public class PiesListViewModel
    {
        public IEnumerable<Pie> Pies { get; set; }
        public string CurrentCategory { get; set; }
    }
}

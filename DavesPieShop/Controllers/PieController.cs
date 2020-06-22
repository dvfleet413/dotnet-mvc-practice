using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DavesPieShop.Models;
using DavesPieShop.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DavesPieShop.Controllers
{
    public class PieController : Controller
    {
        // These are the fields for the class
        // We will use these to make sure our controller has access to the models it needs
        private readonly IPieRepository _pieRepository;
        private readonly ICategoryRepository _categoryRepository;

        // This is the constructor method for the controller.
        // The arguments (repository interfaces) will be automatically injected by the ConfigureServices method, since we addedthe necessary Scoped services
        public PieController(IPieRepository pieRepository, ICategoryRepository categoryRepository)
        {
            // by assigning these fields to the injected repositories, we now have access to the models in the controller
            _pieRepository = pieRepository;
            _categoryRepository = categoryRepository;
        }

        //ViewResult is a built in type of .NET Core MVC
        public ViewResult List(string category)
        {
            IEnumerable<Pie> pies;
            string currentCategory;

            if (string.IsNullOrEmpty(category))
            {
                pies = _pieRepository.AllPies.OrderBy(p => p.PieId);
                currentCategory = "All pies";
            }
            else
            {
                pies = _pieRepository.AllPies.Where(p => p.Category.CategoryName == category)
                    .OrderBy(p => p.PieId);
                currentCategory = _categoryRepository.AllCategories.FirstOrDefault(c => c.CategoryName == category)?.CategoryName;
            }

            // View is a built in method of .NET Core MVC for rendering views.  Data is passed in as an argument
            // How does controller know which view? It looks for './Views/{ControllerName}/{ActionName}'
            // In this case './Views/Pie/list'
            // ViewBag allows us to add data to the view from the controller - in controller ViewBag.Message = "foobar', in View with Razor syntax @ViewBag.Message
            // ViewBag isn't used all that much because it's too dynamic
            // More common to pass data into View method, then define a @model variable in the view
            // Also can create a View Model class that wraps all the data needed in the view

            return View(new PiesListViewModel
            {
                Pies = pies,
                CurrentCategory = currentCategory
            });
        }

        public IActionResult Details(int id)
        {
            var pie = _pieRepository.GetPieById(id);
            if (pie == null)
            {
                return NotFound();
            }
            return View(pie);
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DavesPieShop.Models;
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
        public ViewResult List()
        {
            // View is a built in method of .NET Core MVC for rendering views.  Data is passed in as an argument
            return View(_pieRepository.AllPies);
        }

    }
}

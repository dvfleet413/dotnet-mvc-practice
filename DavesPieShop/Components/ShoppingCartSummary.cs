using System;
using DavesPieShop.Models;
using DavesPieShop.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DavesPieShop.Components
{
    // ViewComponents give us access to more than just view data...This class acts like a mini controller
    public class ShoppingCartSummary : ViewComponent
    {
        private readonly ShoppingCart _shoppingCart;

        // we get an instance of the ShoppingCart Model trhough dependency injection in the following constructor
        // this works because we've added the scoped service of <ShoppingCart> with the lamba that calls GetCart() in the Startup class

        // this constructor is the secret sauce of using ViewComponent as opposed to Partial Views.  It gives us access to the Shopping Cart, which makes it possible to do a lot of cool things
        public ShoppingCartSummary(ShoppingCart shoppingCart)
        {
            _shoppingCart = shoppingCart;
        }

        public IViewComponentResult Invoke()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;

            var ShoppingCartViewModel = new ShoppingCartViewModel
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
            };
            return View(ShoppingCartViewModel);
        }
    }
}

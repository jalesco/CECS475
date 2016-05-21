using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ch24ShoppingCartMVC.Models;

namespace Ch24ShoppingCartMVC.Controllers
{
    public class CheckoutController : Controller
    {
        //Declaration
        private CartModel cart = new CartModel();

        [HttpGet]
        public ViewResult Index()
        {
            //Get all items in the cart, and store them in a new CartViewModel object
            CartViewModel model = (CartViewModel)TempData["cart"]; //allows the data in the cart to persist. Storing the CartViewModel cart into a TempData object
            //if the model is null, then call the method GetCart
            if (model == null)
            {
                model = cart.GetCart();
            }
            //Passing model to View
            return View(model);
        }

        [HttpGet]
        public ViewResult PaymentMade()
        {
            return View();
        }
    }
}

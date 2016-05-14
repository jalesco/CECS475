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
        //
        // GET: /Checkout/
        private CartModel cart = new CartModel();

        [HttpGet]
        public RedirectToRouteResult Index()
        {
            return RedirectToAction("CheckoutPage/");
        }//end Index

        [HttpGet] //just retrieving the data from the server
        public ViewResult CheckoutPage()
        {
            CartViewModel model = (CartViewModel)TempData["cart"];
            //if the model is null, then call the method GetCart
            if (model == null)
            {
                model = cart.GetCart();
            }
            //Passing model to View
            return View(model);
        } //end List()

        [HttpPost]
        public RedirectToRouteResult CheckoutPage(OrderViewModel order)
        {
            CartViewModel model = cart.GetCart(order.SelectedProduct.ProductID);
            //Assign the quantity of the selected product to the quantity of the added product
            model.AddedProduct.Quantity = order.SelectedProduct.Quantity;
            //Call the method AddtoCart
            cart.AddToCart(model);
            //Assign model to the TempData
            TempData["cart"] = model;
            return RedirectToAction("CheckoutPage", "Checkout");
        }//end List
        




    }//end class
}//end namespace

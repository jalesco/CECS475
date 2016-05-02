using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcMovie.Controllers
{
    public class HelloWorldController : Controller
    {
        /*
        **Controller notes:
        //Index() is the default method called when there is no URL specified

        //URL set in App_Start/RouteConfig.cs

        //Ex of setting URL:
        /*
         routes.MapRoute(
            name: "Default",
            url: "{controller}/{action_method}/{id}",
            defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
        );
         * 
         * This is called sending data through ROUTE DATA
         * 
         * Controllers are the ones that handle input and have methods to do something with those inputs
        */


        // GET: HelloWorld

        /*
         1) View() is calling a view template file to generate an HTML response in the browser   
         * If there is no specific view specified, then the Index.cshtml will be called within the controller's view folder 
         */

        public ActionResult Index()
        {
            return View();
        }//end Index()




        // GET: /HelloWorld/Welcome/ 
        //With parameters: /HelloWorld/Welcome?name=...&numOfTimes=...
        // The "?" is the separator in the URL, then the list of query strings follow. '&' character separates query strings. 

        //Note: The way this method is returning makes this more secure since it protects the string from malicious input
        //numOfTimes will default to one if there is no parameter passed        
        public ActionResult Welcome(string name, int numTimes=1)
        {
            //ViewBag has no pre-defined properties, and it is a dynamic object so you can add whatever you want. 
            ViewBag.Message = "Hello: " + name;
            ViewBag.NumTimes = numTimes;
            return View();
        } //end Welcome()
    }//end class
}//end namespace
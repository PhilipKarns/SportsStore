using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;
using SportsStore.WebUI.Models;

namespace SportsStore.WebUI.Controllers
{
    public class CartController : Controller
    {
        private IProductRepository repository;

        public CartController(IProductRepository repo)
        {
            repository = repo;
        }

        /// <summary>
        /// Index method for the shopping card page
        /// </summary>
        /// <param name="returnUrl">Url for the continue shopping button, taking user back to products page</param>
        /// <returns>returns the current cart state and products page url</returns>        
        public ViewResult Index(string returnUrl)
        {
            return View(new CartIndexViewModel
            {
                Cart = GetCart(),
                ReturnUrl = returnUrl
            });
        }

        /// <summary>
        /// Method to add an item to an existing or new cart. parameters are passed from the view form when submit button is selected 
        /// </summary>
        /// <param name="productId">product id of the product being added to the cart</param>
        /// <param name="returnUrl">url of the products page, which will be applied to the continue shopping button of the cart index page</param>
        /// <returns></returns>
        public RedirectToRouteResult AddToCart(int productId, string returnUrl)
        {
            Product product = repository.Products
                .FirstOrDefault(p => p.ProductID == productId);

            if (product != null)
            {
                GetCart().AddItem(product, 1);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        /// <summary>
        /// Method to remove all of a product from a cart
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="returnUrl"></param>
        /// <returns></returns>
        public RedirectToRouteResult RemoveFromCart(int productId, string returnUrl)
        {
            Product product = repository.Products
                .FirstOrDefault(p => p.ProductID == productId);

            if(product != null)
            {
                GetCart().RemoveLine(product);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        /// <summary>
        /// gets the current cart session showing items in cart, or creates a new cart
        /// </summary>
        /// <returns>returns the new or existing cart state</returns>
        private Cart GetCart()
        {
            //retrieve a session object
            Cart cart = (Cart)Session["Cart"];
            if (cart == null)
            {
                cart = new Cart();
                //add an object to the session state
                Session["Cart"] = cart;
            }
            return cart;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;

namespace SportsStore.WebUI.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private IProductRepository repository;

        public AdminController (IProductRepository repo)
        {
            this.repository = repo;
        }

        // GET: Admin
        public ViewResult Index()
        {
            return View(repository.Products);
        }

        public ViewResult Edit(int productId)
        {
            Product product = repository.Products
                .FirstOrDefault(p => p.ProductID == productId);
            return View(product);
        }

        //method to Edit product details. See the cshtml file for the message implementation
        [HttpPost]
        public ActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                repository.SaveProduct(product);
                TempData["message"] = string.Format("{0} has been saved", product.Name);
                return RedirectToAction("Index");
            }
            else
            {
                //there is something wrong with the values
                return View(product);
            }
        }

        public ActionResult Create(Product product)
        {
            return View("Edit", new Product());
        }

        [HttpPost]
        public ActionResult Delete(int productID)
        {
            Product deletedProduct = repository.DeleteProduct(productID);
            if (deletedProduct != null)
            {
                TempData["message"] = string.Format("{0} was deleted", deletedProduct.Name);
            }
            return RedirectToAction("Index");
        }
    }
}
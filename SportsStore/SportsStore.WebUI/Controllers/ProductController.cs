using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace SportsStore.WebUI.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository repository;
        
        // 4 products per page
        public int PageSize = 4;

        public ProductController(IProductRepository productRepository)
        {
            this.repository = productRepository;
        }

        public ViewResult List(int page = 1)
        {
            //get the Products from the DB
            return View(repository.Products
                //order by primary key
                .OrderBy(p => p.ProductID)
                //skip over the products that occur before the start of the current page
                .Skip((page - 1) * PageSize)
                //take(show) the number of products specified by the PageSize field
                .Take(PageSize));
        }
    }
}
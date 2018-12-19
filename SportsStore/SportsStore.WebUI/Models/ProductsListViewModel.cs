using SportsStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportsStore.WebUI.Models
{
    public class ProductsListViewModel
    {
        /// <summary>
        /// Gets or sets the collection of products
        /// </summary>
        public IEnumerable<Product> Products { get; set; }

        /// <summary>
        /// Gets or sets the properties of the PagingInfo model
        /// </summary>
        public PagingInfo PagingInfo { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SportsStore.Domain.Entities;

namespace SportsStore.WebUI.Models
{
    public class CartIndexViewModel
   {
        /// <summary>
        /// gets or sets the items in the cart(current cart state)
        /// </summary>
        public Cart Cart { get; set; }

        /// <summary>
        /// gets or sets the return Url when the continue shopping button is selected
        /// </summary>
        public string ReturnUrl { get; set; }
    }
}
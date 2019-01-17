using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsStore.Domain.Entities
{
    public class Cart
    {
        private List<CartLine> lineCollection = new List<CartLine>();

        //add products to cart
        public void AddItem(Product product, int quantity)
        {
            //find the item in the cart that matches the product parameter, which came from the repository in the AddToCart method of the controller
            CartLine line = lineCollection
                .Where(p => p.Product.ProductID == product.ProductID)
                .FirstOrDefault();

            //if the item wasn't already in the cart, add it. If it was in the cart, increase the quantity by 1
            if (line == null)
            {
                lineCollection.Add(new CartLine { Product = product, Quantity = quantity });
            }
            else
            {
                line.Quantity += quantity;
            }
        }

        //removes all of a selected product from the cart
        public void RemoveLine(Product product)
        {
            lineCollection.RemoveAll(l => l.Product.ProductID == product.ProductID);
        }

        //compute total cost
        public decimal ComputeTotalValue()
        {
            return lineCollection.Sum(e => e.Product.Price * e.Quantity);
        }

        //removes all of the products in the cart
        public void Clear()
        {
            lineCollection.Clear();
        }

        //gets all items in the cart
        public IEnumerable<CartLine> Lines
        {
            get { return lineCollection; }
        }
    }

    //class for products and quantities in the cart
    public class CartLine
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}

using SportsStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsStore.Domain.Abstract
{
    public interface IProductRepository
    {
        IEnumerable<Product> Products { get; }

        //interface for the method that's implemented in the Entity framework EFProductRepository.cs class
        void SaveProduct(Product product);
    }
}

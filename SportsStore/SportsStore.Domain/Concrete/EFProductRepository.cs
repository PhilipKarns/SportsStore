using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;
using System.Collections.Generic;

namespace SportsStore.Domain.Concrete
{
    //in this repo layer, we first implement the IProductRepository interface
    public class EFProductRepository : IProductRepository
    {
        //then use an instance of EFDbContext to retrieve data from the DB using EF
        private EFDbContext context = new EFDbContext();

        public IEnumerable<Product> Products
        {
            get { return context.Products; }
        }
    }
}

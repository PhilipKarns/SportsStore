using SportsStore.Domain.Entities;
using System.Data.Entity;

namespace SportsStore.Domain.Concrete
{
    //this class defines a property for each table in the DB that we want to work with
    public class EFDbContext : DbContext
    {
        //the name of the property specifies the table, and the type parameter of the DbSet specifies the model type the Entity Framework should use 
        //to represent rows in the Products table
        public DbSet<Product> Products { get; set; }
    }
}

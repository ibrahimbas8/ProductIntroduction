using Microsoft.EntityFrameworkCore;
using ProductPromotion.Entities;
using System.Collections.Generic;

namespace ProductPromotion.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}

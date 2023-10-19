using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProductsApplication.Models;

namespace ProductsApplication.Data
{
    public class ProductsApplicationContext : DbContext
    {
        public ProductsApplicationContext (DbContextOptions<ProductsApplicationContext> options)
            : base(options)
        {
        }

        public DbSet<ProductsApplication.Models.Products> Products { get; set; } = default!;
    }
}

using AspNetCore.WA1.Api.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCore.WA1.Api.Models.Data
{
    public class CoreWA1DbContext:DbContext
    {
        public CoreWA1DbContext(DbContextOptions<CoreWA1DbContext> options):base(options)
        {

        }

        public DbSet<Category> Category { get; set; }
        public DbSet<Product> Product { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}

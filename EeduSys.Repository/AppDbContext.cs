using EduSys.Core.Models;
using EeduSys.Repository.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EeduSys.Repository
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options) 
        {
                
        }
        public DbSet<Catagory> Catagories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductFeature> ProductFeatures { get; set; }
        protected override void OnModelCreating (ModelBuilder modelBuilder)
        {
           
            //modelBuilder.Entity<Catagory>().HasKey(o => o.Id).HasName("CatagoryId");

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
          
            //modelBuilder.ApplyConfiguration(new ProductConfiguration());
            //modelBuilder.ApplyConfiguration(new CatagoryConfiguration());
            //modelBuilder.ApplyConfiguration(new ProductFeatureConfiguration());
        } 
    }
}

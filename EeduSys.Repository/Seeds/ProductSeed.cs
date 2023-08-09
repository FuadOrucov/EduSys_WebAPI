using EduSys.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EeduSys.Repository.Seeds
{
    public class ProductSeed : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(

                new Product
                {
                    Id=1,
                    CatagoryId=1,
                    Name="Computer",
                    Price=850,
                    Stock=25,
                    CreateData=DateTime.Now
                },
                 new Product
                 {
                     Id = 2,
                     CatagoryId = 2,
                     Name = "T-Shirt",
                     Price = 50,
                     Stock = 400,
                     CreateData = DateTime.Now
                 },
                  new Product
                  {
                      Id = 3,
                      CatagoryId = 3,
                      Name = "Cat food",
                      Price = 25,
                      Stock = 1000,
                      CreateData = DateTime.Now
                  }



                );
        }
    }
}

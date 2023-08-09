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
    public class CatagorySeed : IEntityTypeConfiguration<Catagory>
    {
        public void Configure(EntityTypeBuilder<Catagory> builder)
        {
            builder.HasData(

                new Catagory { Id = 1, Name = "Electronics" },
                new Catagory { Id = 2, Name = "Fashion" },
                new Catagory { Id = 3, Name = "Pets" }

                );
        }
    }
}

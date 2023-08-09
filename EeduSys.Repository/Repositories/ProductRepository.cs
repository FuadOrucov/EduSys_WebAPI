using EduSys.Core.Models;
using EduSys.Core.Repositories;
using EeduSys.Repository;
using EeduSys.Repository.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduSys.Repository.Repositories
{
    public class ProductRepository: GenericRepository<Product>,IProductRepository
    {

        public ProductRepository( AppDbContext context): base(context)
        {

        }
        public async Task<List<Product>> GetProductWithCatagory()
        {
            return await _context.Products.Include(o => o.Catagory).ToListAsync();
            
        }
    }
}

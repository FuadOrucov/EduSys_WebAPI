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
    public class CatagoryRepository: GenericRepository<Catagory>, ICatagoryRepository
    {
        public CatagoryRepository(AppDbContext context) : base(context)
        {

        }

        public async  Task<Catagory> GetSingleCatagoryByIdWithProductsAsync(int catagoryId)
        {
            return await _context.Catagories.Include(o => o.Products).Where(o => o.Id == catagoryId).SingleOrDefaultAsync();
            
        }
    }
}

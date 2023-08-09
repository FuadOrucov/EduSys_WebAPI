using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduSys.Core.DTOs
{
    public class CatagoryWithProductDto: CatagoryDto
    {
        public List<ProductDto> Products { get; set; }
    }
}

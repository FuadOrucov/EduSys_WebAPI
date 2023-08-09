using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduSys.Core.Models
{
    public class Catagory:BaseEntitiy
    {

        public string Name { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduSys.Core.Models
{
    public abstract class BaseEntitiy
    {
        public int Id { get; set; }
        public DateTime CreateData { get; set; }
        public DateTime? UpdateData { get; set; }
    }
}

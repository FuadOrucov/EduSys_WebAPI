using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduSys.Service.Exceptions
{
    public class NotFoundExceptoin: Exception
    {
        public NotFoundExceptoin(string message): base(message) 
        {

        }
    }
}

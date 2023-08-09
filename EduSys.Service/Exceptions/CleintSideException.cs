using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduSys.Service.Exceptions
{
    public class CleintSideException: Exception
    {
        public CleintSideException(string message): base(message)   
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace General
{
    public struct ExpirableParameter
    {
        public object ObjParameter { get; set; }
        public DateTime DteExpiry { get; set; }
        public string StrHostName { get; set; }
    }
}

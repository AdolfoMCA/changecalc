using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace changecalc
{
    public class items
    {
        public int numdenom { get; set; }
        public int number { get; set; }
    }

 

    public class cResponse
    {
        public bool valid { get; set; }
        public string message { get; set; } 
        public List<items> changelist = new List<items>();

    }
}

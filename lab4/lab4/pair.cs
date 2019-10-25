using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4
{
    public class pair
    {
        public double x { get; set; }
        public double y { get; set; }
        public pair(double _x, double _y)
        {
            x = _x;
            y = _y;
        }
        public pair()
        {
            x = 0;
            y = 0;
        }
    }

}

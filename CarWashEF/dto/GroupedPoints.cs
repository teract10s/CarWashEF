using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWashEF.dto
{
    public class GroupedPoint
    {
        public int NumberOfPoints { get; set; }
        public int Count { get; set; }

        public string ToString()
        {
            return "Grouped point:"
                + "\n\t Points: " + NumberOfPoints
                + "\n\t Have " + Count + " users";
        }
    }
}

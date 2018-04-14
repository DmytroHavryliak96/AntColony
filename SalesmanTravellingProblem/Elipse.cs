using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesmanTravellingProblem
{
    public class Elipse
    {
        public int width, height;
        public int x1, y1;
        public int cityNumber;
        public string drawString;
         
        public Elipse(int width, int height, int x, int y, int city)
        {
            this.width = width;
            this.height = height;
            x1 = x;
            y1 = y;
            cityNumber = city;
            drawString = cityNumber.ToString();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesmanTravellingProblem
{
    public class DrawStringLine
    {
        public int x, y, x2, y2;
        public string DrawString;
        public int xf, yf;
        public DrawStringLine(int x1, int y1, int x2, int y2)
        {
            x = x1;
            y = y1;
            this.x2 = x2;
            this.y2 = y2;

            xf = (x1 + x2) / 2;
            yf = (y1 + y2) / 2;
            int dist = (int)Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
            DrawString = dist.ToString();
        }
    }
}

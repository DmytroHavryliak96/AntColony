using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesmanTravellingProblem
{
    public class Generator
    {
        private Random rnd;

        public Generator()
        {
            rnd = new Random();
        }

        public int[] GeneratePoint()
        {
            int x = rnd.Next(20, 650);
            int y = rnd.Next(20, 400);

            int[] arr = new int[] { x, y };
            return arr;
        }
        
       // public int
        
    }
}

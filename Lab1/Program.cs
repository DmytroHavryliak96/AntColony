using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            int cities = 10;
            int ants = 4;

            AntColony colony = new AntColony(cities, ants);
            int[] trail = colony.FindBestTrail();
            Console.ReadLine();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesmanTravellingProblem
{
    public class VisualGraph
    {
        public List<Point> points;
        public Generator generator;
        public List<Elipse> circles;
        public List<DrawStringLine> lines;
        private int cityNumbers;

        public double[][] dists;

       

        public VisualGraph(int numCities)
        {
            cityNumbers = numCities;
            generator = new Generator();
            points = new List<Point>();
            circles = new List<Elipse>();
            lines = new List<DrawStringLine>();
            dists = new double[numCities][];
            for (int i = 0; i < numCities; i++)
                dists[i] = new double[numCities];
        }

        public void ConstructGraph()
        {
            for(int i = 0; i < cityNumbers; i++)
            {
                int[] coord = generator.GeneratePoint();
                Point p = new Point(coord[0], coord[1], i);
                points.Add(p);
                Elipse e = new Elipse(20, 20, coord[0], coord[1], i);
                circles.Add(e);
            }

            FillDistances();

        }


        public int Distance(int x1, int y1, int x2, int y2)
        {
            int dist = (int)Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
            return dist;
        }

        private void FillDistances()
        {
            for(int i = 0; i < cityNumbers; i++)
            {
                for(int j = 0; j < cityNumbers; j++)
                {
                    Point pX = points.Find(p => p.cityNumber == i);
                    Point pY = points.Find(p => p.cityNumber == j);

                    dists[i][j] = Distance(pX.x1, pX.y1, pY.x1, pY.y1) / 100.0;
                    if (i != j)
                    {
                        DrawStringLine line = new DrawStringLine(pX.x1, pX.y1, pY.x1, pY.y1);
                        lines.Add(line);
                    }
                }
            }
        }


    }
}

using Lab1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesmanTravellingProblem
{
    public partial class Form1 : Form
    {
        int numCities;
        int numAnts;
        VisualGraph graph;
        Results res = new Results();
        public Form1()
        {
            numCities = 5;
            numAnts = 2;
            InitializeComponent();
        }

        public void form1_paint(object sender, PaintEventArgs e)
        {
            numCities = Convert.ToInt32(this.cities.Text);
            Font drawFont = new Font("Arial", 8);
            SolidBrush drawbrush = new SolidBrush(Color.Black);
            SolidBrush drawbrushLine = new SolidBrush(Color.Red);

            graph = new VisualGraph(numCities);
            graph.ConstructGraph();


            for(int i = 0; i < numCities; i++)
            {
                var el = graph.circles[i];
                e.Graphics.DrawEllipse(Pens.Black, el.x1, el.y1, el.width, el.height);
                e.Graphics.DrawString(el.drawString, drawFont, drawbrush, el.x1, el.y1);
            }


            for(int i  = 0; i < graph.lines.Count; i++)
            {
                var line = graph.lines[i];
                e.Graphics.DrawLine(Pens.Red, line.x, line.y, line.x2, line.y2);
                e.Graphics.DrawString(line.DrawString, drawFont, drawbrush, line.xf, line.yf);
            }



            res.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox1.Refresh();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int cities = numCities;
            int ants = Convert.ToInt32(this.ants.Text);

            AntColony colony = new AntColony(cities, ants, graph.dists);
            int[] trail = colony.FindBestTrail();

            var bestTrails = colony.ConvertTrails();
            var bestIterations = colony.ConvertIter();

            res = new Results();
            
            for(int i = 0; i < bestTrails.Count; i++)
            {
                res.AddBestTrail(bestTrails[i], bestIterations[i]);
            }

            res.AddBestTrail("  ", "  ");

           
            string str = "";
            for (int i = 0; i < trail.Length; i++)
                str += trail[i].ToString() + " -> ";
            str += (colony.bestLength * 100).ToString();
                
            res.AddBestTrail(str, colony.bestIteration.ToString());

            res.ShowDialog();

            
        }
    }
}

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
    public partial class Results : Form
    {
        DataTable trails;
        public Results()
        {
            InitializeComponent();
            trails = new DataTable();
            dataGridView1.DataSource = trails;
            trails.Columns.Add("best trail");
            trails.Columns.Add("iteration");
        }

        public void AddBestTrail(string trail, string iteration)
        {
            DataRow row = trails.NewRow();
            row["best trail"] = trail;
            row["iteration"] = iteration;
            trails.Rows.Add(row);
        }
        
    }
}

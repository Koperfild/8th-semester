using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SAPR_Laba1
{
    public partial class Graph : Form
    {
        public Graph() { }
        public Graph(Data data)
        {
            InitializeComponent();
            Editing.GraphEditor graphEditor = new Editing.GraphEditor();
            SuspendLayout();
            this.Controls.Add(graphEditor);
            graphEditor.AddNodeType("Ellipse", Microsoft.Msagl.Drawing.Shape.Ellipse, Microsoft.Msagl.Drawing.Color.Transparent, Microsoft.Msagl.Drawing.Color.Black, 10, "user data",
                                    "New Node");
            graphEditor.Viewer.NeedToCalculateLayout = true;
            graphEditor.Graph = BuildGraph(data);
            graphEditor.Viewer.NeedToCalculateLayout = false;
            graphEditor.Width = this.Width;
            graphEditor.Height = this.Height;
            //helpButton.BringToFront();
            graphEditor.Viewer.LayoutAlgorithmSettingsButtonVisible = false;
            ResumeLayout();
        }

        private Microsoft.Msagl.Drawing.Graph BuildGraph(Data data)
        {
            Microsoft.Msagl.Drawing.Graph g = new Microsoft.Msagl.Drawing.Graph();
            for (int i = 0; i < data.IncidenceMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < data.IncidenceMatrix.GetLength(1); j++)
                {
                    if (data.IncidenceMatrix[i, j] == 1)
                    {
                        g.AddEdge(i.ToString(), j.ToString());
                    }
                }

            }
            return g;
        }
    }
}

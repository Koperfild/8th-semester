using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using Microsoft.Office.Interop.Excel;
using Microsoft.Msagl;
using Microsoft.Msagl.GraphViewerGdi;
using Microsoft.Msagl.Drawing;
using System.Windows.Shapes;

namespace SAPR_Laba1
{
    public partial class Form1 : Form
    {
        public System.Windows.Forms.NumericUpDown BeginNodeNumber
        {
            get { return beginNodeNumber; }
        }
        public System.Windows.Forms.NumericUpDown P
        {
            get { return p; }
        }
        public System.Windows.Forms.DataGridView DataGridView
        {
            get { return dataGridView; }
        }
        public System.Windows.Forms.BindingSource BindingSource1
        {
            get { return bindingSource1; }
            set { bindingSource1 = value; }
        }
        public System.Windows.Forms.Button Button1
        {
            get { return button1; }
        }
        public Mommo.Data.ArrayDataView Arr
        {
            get { return arr; }
            set { arr = value; }
        }

        public Form1()
        {
            InitializeComponent();
            data = new Data();
            //Привязка данных к data
            string[] columnNumbers = new string[data.IncidenceMatrix.GetLength(1)];
            for (int i = 0; i < columnNumbers.Length; i++)
                columnNumbers[i] = i.ToString();
            arr = new Mommo.Data.ArrayDataView(data.IncidenceMatrix, columnNumbers);
            //BindingSource1 = new BindingSource();
            //BindingSource1.DataSource = arr;
            //Привязываем матрицу инцидентности к dataGridView
            DataGridView.DataSource = arr;//BindingSource1;
            //Привязываем номер начального узла (на форме) к свойству beginNodeNumber
            BeginNodeNumber.DataBindings.Add("Value", this.data, "beginNodeNumber");


            this.beginNodeNumber.Maximum = DataGridView.ColumnCount - 1;
            foreach (DataGridViewRow row in this.DataGridView.Rows)
            {
                row.HeaderCell.Value = (row.Index + 1).ToString();
            }
            // Resize the master DataGridView columns to fit the newly loaded data.
            this.DataGridView.AutoResizeColumns();

            // Configure the details DataGridView so that its columns automatically
            // adjust their widths when the data changes.
            this.DataGridView.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.AllCells;

            /*
            Microsoft.Msagl.GraphViewerGdi.GViewer viewer = BuildGraph();
            this.SuspendLayout();

            this.Controls.Add(viewer);
            this.ResumeLayout();
            */
            /*Thread thrd = new Thread(() =>
            {
                Random rnd = new Random(11020);
                this.DataGridView.Rows[this.dataGridView.RowCount].Cells[this.dataGridView.ColumnCount].Style.BackColor = Color.Aquamarine;
                Thread.Sleep(700);
            });
            thrd.Start();
            */
        }
        private Microsoft.Msagl.GraphViewerGdi.GViewer BuildGraph()
        {
            Microsoft.Msagl.GraphViewerGdi.GViewer viewer = new Microsoft.Msagl.GraphViewerGdi.GViewer();
            //Microsoft.Msagl.Drawing.Graph graph = new Microsoft.Msagl.Drawing.Graph("graph");
            Microsoft.Msagl.Core.Layout.GeometryGraph graph = new Microsoft.Msagl.Core.Layout.GeometryGraph();
            bool nodeExist = false;


            //Составляем список всех узлов
            List<Microsoft.Msagl.Core.Layout.Node> nodes = new List<Microsoft.Msagl.Core.Layout.Node>();
            for (int i = 0; i < this.dataGridView.Rows.Count; i++)
            {
                nodes.Add(new Microsoft.Msagl.Core.Layout.Node(Microsoft.Msagl.Core.Geometry.Curves.CurveFactory.CreateEllipse(10, 10, new Microsoft.Msagl.Core.Geometry.Point()), i.ToString());
            }
            for (int i = 0; i < this.dataGridView.Rows.Count; i++)
            {
                for (int j = 0; j < this.dataGridView.Columns.Count; j++)
                {
                    if (this.dataGridView.Rows[i].Cells[j].Value.ToString() == "1")
                    {
                        Microsoft.Msagl.Core.Layout.Edge edge = new Microsoft.Msagl.Core.Layout.Edge(nodes[i], nodes[j]);
                        graph.add
                        if (!nodeExist)
                        {
                            Microsoft.Msagl.Core.Layout.Node n0 = new Microsoft.Msagl.Core.Layout.Node(Microsoft.Msagl.Core.Geometry.Curves.CurveFactory.CreateEllipse(10, 10, new Microsoft.Msagl.Core.Geometry.Point()), "a");
                            //Microsoft.Msagl.Drawing.Node node = new Node("jjj") {i {//= new Node("ф") { new System.Windows.Shapes.Ellipse() { Height = 10, Width = 10 }, new System.Drawing.Point())};
                        }
                        graph.AddEdge(i.ToString(), j.ToString());
                    }
                }
            }
            graph.AddEdge
            foreach(var node in graph.Nodes)
            {
                node.Height = 10.0;
                node.Width = 10.0;
            }
            viewer.Graph = graph;
            return viewer;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string error = null;
            if (this.p.Value <= 0)
                error = "Wrong max count of graph symbols per page";
            else if (this.beginNodeNumber.Value < 0 || this.beginNodeNumber.Value >= this.dataGridView.ColumnCount)
                error = "Not specified beginNode";
            else if (this.dataGridView.ColumnCount != this.dataGridView.RowCount)
                error = "Incidence matrix is not square";

            if (error != null)
                MessageBox.Show(error, "Try again");
            else {
                try
                {
                    AlgorithmScheme algo = new AlgorithmScheme(data.IncidenceMatrix, (int)BeginNodeNumber.Value, (int)P.Value);
                    ResultForm fres = new ResultForm();
                    fres.Show();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Try again!");
                }
            }
        }

        private void dataGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridViewCellStyle style = new DataGridViewCellStyle();
            style.Alignment = DataGridViewContentAlignment.MiddleRight;

            //*** Add row number to each row
            foreach (DataGridViewRow row in DataGridView.Rows)
            {
                row.HeaderCell.Value = (row.Index + 1).ToString();
                row.HeaderCell.Style = style;
                row.Resizable = DataGridViewTriState.False;
            }
            DataGridView.ResumeLayout();
        }

        private void beginNodeNumber_ValueChanged(object sender, EventArgs e)
        {
            var obj = sender as NumericUpDown;
            if (obj.Value >= this.DataGridView.ColumnCount)
                MessageBox.Show("Invalid start node number", "Try again!");
        }

        private void SaveInMatrixFormat()//SaveBtn_Click(object sender, EventArgs e)
        {
            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter("IncidenceMatrix.txt"))
            {
                file.WriteLine(this.dataGridView.Rows.Count.ToString());
                foreach (DataGridViewRow row in this.dataGridView.Rows)
                {
                    foreach (DataGridViewCell cell in row.Cells)
                        file.Write(cell.Value.ToString() + " ");
                    file.WriteLine();
                }

            }
        }
        private void SaveInLineFormat()
        {
            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter("GraphInLines.txt"))
            {
                                   
                file.WriteLine(this.dataGridView.Rows.Count.ToString());
                int count = 0;
                for (int i = 0; i < dataGridView.Rows.Count; i++)
                {
                    for (int j = 0; j < dataGridView.Columns.Count; j++)
                    {
                        if (dataGridView.Rows[i].Cells[j].Value.ToString() == "1")
                            file.Write(i.ToString() + " ");
                    }
                    file.WriteLine();
                }
            }
        }

        private void ReadBtn_Click()// object sender, EventArgs e)
        {
            using (System.IO.StreamReader file =
            new System.IO.StreamReader("IncidenceMatrix.txt"))
            {
                string line;
                line = file.ReadLine();
                int[,] matrix;
                int matrixSize;
                if (int.TryParse(line, out matrixSize))
                {
                    matrix = new int[matrixSize, matrixSize];
                    int count = 0;
                    while ((line = file.ReadLine()) != null && count < matrixSize)
                    {
                        string[] vals = line.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
                        for (int i = 0; i < vals.Length; i++)
                        {
                            matrix[count, i] = int.Parse(vals[i]);
                        }
                        count += 1;
                    }
                    string[] columnNumbers = new string[matrix.GetLength(0)];
                    for (int i = 0; i < columnNumbers.Length; i++)
                        columnNumbers[i] = (i + 1).ToString();
                    this.data.IncidenceMatrix = matrix;
                    this.arr = new Mommo.Data.ArrayDataView(matrix, columnNumbers);
                    this.dataGridView.DataSource = this.arr;
                    //bindingSource1.DataSource = this.arr;// new Mommo.Data.ArrayDataView(matrix, columnNumbers);
                }
            }

        }

        private void readLineFormat()//button2_Click(object sender, EventArgs e)
        {
            using (System.IO.StreamReader file =
            new System.IO.StreamReader("inputByYarik&Co.txt"))
            {
                string line;

                int[,] matrix;
                int matrixSize = int.Parse(file.ReadLine());

                matrix = new int[matrixSize, matrixSize];
                int count = 0;
                while ((line = file.ReadLine()) != null && count < matrixSize)
                {
                    string[] vals = line.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
                    //Если пустая строчка, значит, из данного узла нет исходящих дуг в другие узлы
                    if (vals.Length == 0)
                    {
                        continue;
                    }
                    for (int i = 0; i < vals.Length; i++)
                    {
                        int edinichka = int.Parse(vals[i]) - 1;
                        matrix[count, edinichka] = 1;
                    }
                    count += 1;
                }
                string[] columnNumbers = new string[matrix.GetLength(0)];
                for (int i = 0; i < columnNumbers.Length; i++)
                    columnNumbers[i] = (i + 1).ToString();
                this.data.IncidenceMatrix = matrix;//this.arr = new Mommo.Data.ArrayDataView(matrix, columnNumbers);
                this.arr = new Mommo.Data.ArrayDataView(this.data.IncidenceMatrix, columnNumbers);
                this.dataGridView.DataSource = this.arr;
                //this.arr.Reset(); //Хз почему не работает ресет
                //bindingSource1.DataSource = this.arr;// new Mommo.Data.ArrayDataView(matrix, columnNumbers);

            }
        }

        private void resultstofile_Click(object sender, EventArgs e)
        {
            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter("results.txt"))
            {
                for (int i = 0; i < AlgorithmScheme.pages.Count; i++)
                {
                    file.WriteLine("Страница № " + AlgorithmScheme.pages[i].number.ToString() + "\n");
                    for (int j = 0; j < AlgorithmScheme.pages[i].graphSymbols.Count; j++)
                        file.WriteLine("Узел " + AlgorithmScheme.pages[i].graphSymbols[j].ID + "   Kcv = " + AlgorithmScheme.pages[i].graphSymbols[j].Kcv.ToString("0.000") + "\n");
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (this.radioButton1.Checked == true)
                ReadBtn_Click();
            else
                readLineFormat();
            Graph graphForm = new Graph();
            Microsoft.Msagl.GraphViewerGdi.GViewer viewer = BuildGraph();
            graphForm.SuspendLayout();
            viewer.Dock = System.Windows.Forms.DockStyle.Fill;
            graphForm.Controls.Add(viewer);
            graphForm.ResumeLayout();
            graphForm.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (this.radioButton3.Checked == true)
                SaveInMatrixFormat();
            else
                SaveInLineFormat();
        }
        /*SaveAs не хочет сохранять
private void uploadrestoExcel_Click(object sender, EventArgs e)
{
Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
app.Visible = false;
app.Workbooks.Add();
Worksheet worksheet = (Worksheet)app.ActiveSheet;
int index = 1;
worksheet.Cells[1, 1] = "GraphSymbol";
worksheet.Cells[1, 2] = "Kcv";
for (int i=0;i < AlgorithmScheme.pages.Count;i++)
{
worksheet.Cells[index, 1] = AlgorithmScheme.pages[i].number;
index += 1;
for (int j = 0; j < AlgorithmScheme.pages[i].graphSymbols.Count; j++)
{
worksheet.Cells[index, 1] = AlgorithmScheme.pages[i].graphSymbols[j].ID;
worksheet.Cells[index, 2] = AlgorithmScheme.pages[i].graphSymbols[j].Kcv;
index++;
}
}
worksheet.SaveAs("E:\\GitHub\\8th-semester-SAPR-Laba1\\САПР Лаба1\\bin\\Debug\\results.xlsx", Microsoft.Office.Interop.Excel.XlFileFormat.xlExcel12, Type.Missing, Type.Missing,
false, false);
app.Quit();
}
*/

    }
}

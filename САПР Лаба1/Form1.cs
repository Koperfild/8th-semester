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
            data = new Data(this);
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
            BeginNodeNumber.DataBindings.Add("Value", this, "data.beginNodeNumber");


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

            /*Thread thrd = new Thread(() =>
            {
                Random rnd = new Random(11020);
                this.DataGridView.Rows[this.dataGridView.RowCount].Cells[this.dataGridView.ColumnCount].Style.BackColor = Color.Aquamarine;
                Thread.Sleep(700);
            });
            thrd.Start();
            */
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string error = null;
            if (this.p.Value < 0)
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
                    ResultForm fres = new ResultForm(algo);
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

        private void SaveBtn_Click(object sender, EventArgs e)
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

        private void ReadBtn_Click(object sender, EventArgs e)
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

        private void button2_Click(object sender, EventArgs e)
        {
            using (System.IO.StreamReader file =
            new System.IO.StreamReader("inputByYarik&Co.txt"))
            {
                string line;

                int[,] matrix;
                int matrixSize = 30;

                matrix = new int[matrixSize, matrixSize];
                int count = 0;
                while ((line = file.ReadLine()) != null && count < matrixSize)
                {
                    string[] vals = line.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
                    for (int i = 0; i < vals.Length; i++)
                    {
                        int edinichka = int.Parse(vals[i])-1;
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
    }
}

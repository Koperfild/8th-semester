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
        public Data Data
        {
            get { return data; }
        }
        public Form1()
        {
            InitializeComponent();
            data = new Data(this);
            foreach(DataGridViewRow row in this.DataGridView.Rows)
            {
                row.HeaderCell.Value = row.Index.ToString();
            }
            // Resize the master DataGridView columns to fit the newly loaded data.
            this.DataGridView.AutoResizeColumns();

            // Configure the details DataGridView so that its columns automatically
            // adjust their widths when the data changes.
            this.DataGridView.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.AllCells;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try {
                AlgorithmScheme algo = new AlgorithmScheme(Data.IncidenceMatrix, (int)BeginNodeNumber.Value, (int)P.Value);
                ResultForm fres = new ResultForm(algo);
                fres.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Try again!");
            }
        }

        private void dataGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridViewCellStyle style = new DataGridViewCellStyle();
            style.Alignment = DataGridViewContentAlignment.MiddleRight;

            //*** Add row number to each row
            foreach (DataGridViewRow row in DataGridView.Rows)
            {
                row.HeaderCell.Value = row.Index.ToString();
                row.HeaderCell.Style = style;
                row.Resizable = DataGridViewTriState.False;
            }
            DataGridView.ResumeLayout();
        }
    }
}

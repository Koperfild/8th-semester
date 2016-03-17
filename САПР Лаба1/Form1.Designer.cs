using Mommo;

namespace SAPR_Laba1
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.beginNodeNumber = new System.Windows.Forms.NumericUpDown();
            this.beginNodelbl = new System.Windows.Forms.Label();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.p = new System.Windows.Forms.NumericUpDown();
            this.GraphSymbolsCountLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ReadBtn = new System.Windows.Forms.Button();
            this.SaveBtn = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.beginNodeNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.p)).BeginInit();
            this.SuspendLayout();
            // 
            // beginNodeNumber
            // 
            this.beginNodeNumber.BackColor = System.Drawing.Color.Fuchsia;
            this.beginNodeNumber.Font = new System.Drawing.Font("Impact", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.beginNodeNumber.Location = new System.Drawing.Point(255, 542);
            this.beginNodeNumber.Margin = new System.Windows.Forms.Padding(4);
            this.beginNodeNumber.Name = "beginNodeNumber";
            this.beginNodeNumber.Size = new System.Drawing.Size(160, 28);
            this.beginNodeNumber.TabIndex = 0;
            this.beginNodeNumber.ValueChanged += new System.EventHandler(this.beginNodeNumber_ValueChanged);
            // 
            // beginNodelbl
            // 
            this.beginNodelbl.AutoSize = true;
            this.beginNodelbl.Font = new System.Drawing.Font("Impact", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.beginNodelbl.Location = new System.Drawing.Point(252, 496);
            this.beginNodelbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.beginNodelbl.Name = "beginNodelbl";
            this.beginNodelbl.Size = new System.Drawing.Size(198, 21);
            this.beginNodelbl.TabIndex = 1;
            this.beginNodelbl.Text = "Начальный граф символ";
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dataGridView.Location = new System.Drawing.Point(9, 28);
            this.dataGridView.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersWidth = 77;
            this.dataGridView.Size = new System.Drawing.Size(886, 468);
            this.dataGridView.TabIndex = 2;
            this.dataGridView.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dataGridView_DataBindingComplete);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Fuchsia;
            this.button1.Font = new System.Drawing.Font("Impact", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(663, 519);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(124, 66);
            this.button1.TabIndex = 3;
            this.button1.Text = "Work bitch";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // p
            // 
            this.p.BackColor = System.Drawing.Color.Fuchsia;
            this.p.Font = new System.Drawing.Font("Impact", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.p.Location = new System.Drawing.Point(31, 542);
            this.p.Name = "p";
            this.p.Size = new System.Drawing.Size(120, 28);
            this.p.TabIndex = 4;
            this.p.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // GraphSymbolsCountLabel
            // 
            this.GraphSymbolsCountLabel.AutoSize = true;
            this.GraphSymbolsCountLabel.Font = new System.Drawing.Font("Impact", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GraphSymbolsCountLabel.Location = new System.Drawing.Point(28, 496);
            this.GraphSymbolsCountLabel.Name = "GraphSymbolsCountLabel";
            this.GraphSymbolsCountLabel.Size = new System.Drawing.Size(146, 42);
            this.GraphSymbolsCountLabel.TabIndex = 5;
            this.GraphSymbolsCountLabel.Text = "Max graph symbols\n count per page";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(10, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(240, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "Матрица инцидентности";
            // 
            // ReadBtn
            // 
            this.ReadBtn.Location = new System.Drawing.Point(471, 519);
            this.ReadBtn.Name = "ReadBtn";
            this.ReadBtn.Size = new System.Drawing.Size(75, 23);
            this.ReadBtn.TabIndex = 7;
            this.ReadBtn.Text = "Read matrix from file";
            this.ReadBtn.UseVisualStyleBackColor = true;
            this.ReadBtn.Click += new System.EventHandler(this.ReadBtn_Click);
            // 
            // SaveBtn
            // 
            this.SaveBtn.Location = new System.Drawing.Point(471, 561);
            this.SaveBtn.Name = "SaveBtn";
            this.SaveBtn.Size = new System.Drawing.Size(75, 23);
            this.SaveBtn.TabIndex = 8;
            this.SaveBtn.Text = "Save to File";
            this.SaveBtn.UseVisualStyleBackColor = true;
            this.SaveBtn.Click += new System.EventHandler(this.SaveBtn_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(821, 514);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 9;
            this.button2.Text = "cheat input";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Chartreuse;
            this.ClientSize = new System.Drawing.Size(908, 596);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.SaveBtn);
            this.Controls.Add(this.ReadBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.GraphSymbolsCountLabel);
            this.Controls.Add(this.p);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.beginNodelbl);
            this.Controls.Add(this.beginNodeNumber);
            this.ForeColor = System.Drawing.Color.Black;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.beginNodeNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.p)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown beginNodeNumber;
        private System.Windows.Forms.Label beginNodelbl;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.Button button1;
        private Mommo.Data.ArrayDataView arr;
        private Data data;
        private System.Windows.Forms.NumericUpDown p;
        private System.Windows.Forms.Label GraphSymbolsCountLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button SaveBtn;
        private System.Windows.Forms.Button ReadBtn;
        private System.Windows.Forms.Button button2;
    }
}


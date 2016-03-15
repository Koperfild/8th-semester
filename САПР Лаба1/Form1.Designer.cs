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
            ((System.ComponentModel.ISupportInitialize)(this.beginNodeNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.p)).BeginInit();
            this.SuspendLayout();
            // 
            // beginNodeNumber
            // 
            this.beginNodeNumber.Location = new System.Drawing.Point(275, 623);
            this.beginNodeNumber.Margin = new System.Windows.Forms.Padding(4);
            this.beginNodeNumber.Name = "beginNodeNumber";
            this.beginNodeNumber.Size = new System.Drawing.Size(160, 22);
            this.beginNodeNumber.TabIndex = 0;
            // 
            // beginNodelbl
            // 
            this.beginNodelbl.AutoSize = true;
            this.beginNodelbl.Location = new System.Drawing.Point(272, 577);
            this.beginNodelbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.beginNodelbl.Name = "beginNodelbl";
            this.beginNodelbl.Size = new System.Drawing.Size(170, 17);
            this.beginNodelbl.TabIndex = 1;
            this.beginNodelbl.Text = "Начальный граф символ";
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(30, 66);
            this.dataGridView.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(886, 468);
            this.dataGridView.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(713, 659);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(124, 66);
            this.button1.TabIndex = 3;
            this.button1.Text = "Work bitch";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // p
            // 
            this.p.Location = new System.Drawing.Point(51, 623);
            this.p.Name = "p";
            this.p.Size = new System.Drawing.Size(120, 22);
            this.p.TabIndex = 4;
            // 
            // GraphSymbolsCountLabel
            // 
            this.GraphSymbolsCountLabel.AutoSize = true;
            this.GraphSymbolsCountLabel.Location = new System.Drawing.Point(48, 577);
            this.GraphSymbolsCountLabel.Name = "GraphSymbolsCountLabel";
            this.GraphSymbolsCountLabel.Size = new System.Drawing.Size(129, 34);
            this.GraphSymbolsCountLabel.TabIndex = 5;
            this.GraphSymbolsCountLabel.Text = "Max graph symbols\n count per page";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1284, 827);
            this.Controls.Add(this.GraphSymbolsCountLabel);
            this.Controls.Add(this.p);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.beginNodelbl);
            this.Controls.Add(this.beginNodeNumber);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
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
    }
}


namespace Manufactory
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.addOrder_button = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.actualDataGridView = new System.Windows.Forms.DataGridView();
            this.pastDataGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.actualDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pastDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // addOrder_button
            // 
            this.addOrder_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 28F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addOrder_button.Location = new System.Drawing.Point(482, 8);
            this.addOrder_button.Margin = new System.Windows.Forms.Padding(2);
            this.addOrder_button.Name = "addOrder_button";
            this.addOrder_button.Size = new System.Drawing.Size(61, 51);
            this.addOrder_button.TabIndex = 0;
            this.addOrder_button.Text = "+";
            this.addOrder_button.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.label1.Location = new System.Drawing.Point(8, 118);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(237, 29);
            this.label1.TabIndex = 1;
            this.label1.Text = "Актуальные заказы";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.label2.Location = new System.Drawing.Point(8, 288);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(211, 29);
            this.label2.TabIndex = 2;
            this.label2.Text = "Прошлые заказы";
            // 
            // actual_dataGridView
            // 
            this.actualDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.actualDataGridView.Location = new System.Drawing.Point(13, 150);
            this.actualDataGridView.Name = "actual_dataGridView";
            this.actualDataGridView.Size = new System.Drawing.Size(453, 126);
            this.actualDataGridView.TabIndex = 3;
            // 
            // dataGridView1
            // 
            this.pastDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.pastDataGridView.Location = new System.Drawing.Point(13, 329);
            this.pastDataGridView.Name = "past_dataGridView";
            this.pastDataGridView.Size = new System.Drawing.Size(453, 168);
            this.pastDataGridView.TabIndex = 4;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(551, 509);
            this.Controls.Add(this.pastDataGridView);
            this.Controls.Add(this.actualDataGridView);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.addOrder_button);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form2";
            this.Text = "Form2";
            //this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.actualDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pastDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button addOrder_button;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView actualDataGridView;
        private System.Windows.Forms.DataGridView pastDataGridView;
    }
}
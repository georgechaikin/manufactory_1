namespace Manufactory
{
    partial class OrderListForm
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
            this.components = new System.ComponentModel.Container();
            this.pastGridview = new System.Windows.Forms.DataGridView();
            this.actualGridView = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.newAddBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pastGridview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.actualGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.newAddBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // pastGridview
            // 
            this.pastGridview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.pastGridview.Location = new System.Drawing.Point(24, 37);
            this.pastGridview.Name = "pastGridview";
            this.pastGridview.Size = new System.Drawing.Size(764, 150);
            this.pastGridview.TabIndex = 0;
            // 
            // actualGridView
            // 
            this.actualGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.actualGridView.Location = new System.Drawing.Point(24, 243);
            this.actualGridView.Name = "actualGridView";
            this.actualGridView.Size = new System.Drawing.Size(764, 150);
            this.actualGridView.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.label2.Location = new System.Drawing.Point(307, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(187, 25);
            this.label2.TabIndex = 4;
            this.label2.Text = "Прошлые Заказы";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.label1.Location = new System.Drawing.Point(307, 215);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(212, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "Актуальные Заказы";
            // 
            // newAddBindingSource
            // 
            this.newAddBindingSource.DataSource = typeof(Manufactory.NewAdd);
            // 
            // OrderListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.actualGridView);
            this.Controls.Add(this.pastGridview);
            this.Name = "OrderListForm";
            this.Text = "OrderListForm";
            ((System.ComponentModel.ISupportInitialize)(this.pastGridview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.actualGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.newAddBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource newAddBindingSource;
        private System.Windows.Forms.DataGridView pastGridview;
        private System.Windows.Forms.DataGridView actualGridView;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}
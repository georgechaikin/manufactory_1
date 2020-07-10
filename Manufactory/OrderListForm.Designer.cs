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
            this.pastGridView = new System.Windows.Forms.DataGridView();
            this.actualGridView = new System.Windows.Forms.DataGridView();
            this.lastOrdersLabel = new System.Windows.Forms.Label();
            this.actualOrdersLabel = new System.Windows.Forms.Label();
            this.newAddBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pastGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.actualGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.newAddBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // pastGridView
            // 
            this.pastGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.pastGridView.Location = new System.Drawing.Point(24, 37);
            this.pastGridView.Name = "pastGridView";
            this.pastGridView.Size = new System.Drawing.Size(764, 150);
            this.pastGridView.TabIndex = 0;
            // 
            // actualGridView
            // 
            this.actualGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.actualGridView.Location = new System.Drawing.Point(24, 243);
            this.actualGridView.Name = "actualGridView";
            this.actualGridView.Size = new System.Drawing.Size(764, 150);
            this.actualGridView.TabIndex = 1;
            // 
            // lastOrdersLabel
            // 
            this.lastOrdersLabel.AutoSize = true;
            this.lastOrdersLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.lastOrdersLabel.Location = new System.Drawing.Point(307, 9);
            this.lastOrdersLabel.Name = "lastOrdersLabel";
            this.lastOrdersLabel.Size = new System.Drawing.Size(187, 25);
            this.lastOrdersLabel.TabIndex = 4;
            this.lastOrdersLabel.Text = "Прошлые Заказы";
            // 
            // actualOrdersLabel
            // 
            this.actualOrdersLabel.AutoSize = true;
            this.actualOrdersLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.actualOrdersLabel.Location = new System.Drawing.Point(307, 215);
            this.actualOrdersLabel.Name = "actualOrdersLabel";
            this.actualOrdersLabel.Size = new System.Drawing.Size(212, 25);
            this.actualOrdersLabel.TabIndex = 3;
            this.actualOrdersLabel.Text = "Актуальные Заказы";
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
            this.Controls.Add(this.lastOrdersLabel);
            this.Controls.Add(this.actualOrdersLabel);
            this.Controls.Add(this.actualGridView);
            this.Controls.Add(this.pastGridView);
            this.Name = "OrderListForm";
            this.Text = "OrderListForm";
            ((System.ComponentModel.ISupportInitialize)(this.pastGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.actualGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.newAddBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource newAddBindingSource;
        private System.Windows.Forms.DataGridView pastGridView;
        private System.Windows.Forms.DataGridView actualGridView;
        private System.Windows.Forms.Label lastOrdersLabel;
        private System.Windows.Forms.Label actualOrdersLabel;
    }
}
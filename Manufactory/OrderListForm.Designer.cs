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
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pastGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.actualGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.newAddBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // pastGridView
            // 
            this.pastGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.pastGridView.Location = new System.Drawing.Point(9, 339);
            this.pastGridView.Name = "pastGridView";
            this.pastGridView.Size = new System.Drawing.Size(885, 226);
            this.pastGridView.TabIndex = 0;
            // 
            // actualGridView
            // 
            this.actualGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.actualGridView.Location = new System.Drawing.Point(9, 38);
            this.actualGridView.Name = "actualGridView";
            this.actualGridView.Size = new System.Drawing.Size(885, 235);
            this.actualGridView.TabIndex = 1;
            // 
            // lastOrdersLabel
            // 
            this.lastOrdersLabel.AutoSize = true;
            this.lastOrdersLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.lastOrdersLabel.Location = new System.Drawing.Point(381, 294);
            this.lastOrdersLabel.Name = "lastOrdersLabel";
            this.lastOrdersLabel.Size = new System.Drawing.Size(187, 25);
            this.lastOrdersLabel.TabIndex = 4;
            this.lastOrdersLabel.Text = "Прошлые Заказы";
            // 
            // actualOrdersLabel
            // 
            this.actualOrdersLabel.AutoSize = true;
            this.actualOrdersLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.actualOrdersLabel.Location = new System.Drawing.Point(346, 12);
            this.actualOrdersLabel.Name = "actualOrdersLabel";
            this.actualOrdersLabel.Size = new System.Drawing.Size(212, 25);
            this.actualOrdersLabel.TabIndex = 3;
            this.actualOrdersLabel.Text = "Актуальные Заказы";
            // 
            // newAddBindingSource
            // 
            this.newAddBindingSource.DataSource = typeof(Manufactory.NewAdd);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 28F);
            this.button1.Location = new System.Drawing.Point(957, 38);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(65, 59);
            this.button1.TabIndex = 5;
            this.button1.Text = "+";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.openNewAddForm);
            // 
            // OrderListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1102, 573);
            this.Controls.Add(this.button1);
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
        private System.Windows.Forms.Button button1;
    }
}
namespace Manufactory
{
    partial class AddOrderForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.productAmount_textBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.productType_textBox = new System.Windows.Forms.TextBox();
            this.productName_textBox = new System.Windows.Forms.TextBox();
            this.client_textBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.productSize_textBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.productCost_textBox = new System.Windows.Forms.TextBox();
            this.addOrder_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(16, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Заказчик";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(11, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Изделие";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 131);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Наименование";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(43, 172);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Кол-во.";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // productAmount_textBox
            // 
            this.productAmount_textBox.Location = new System.Drawing.Point(93, 172);
            this.productAmount_textBox.Name = "productAmount_textBox";
            this.productAmount_textBox.Size = new System.Drawing.Size(271, 20);
            this.productAmount_textBox.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(1, 222);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 20);
            this.label5.TabIndex = 7;
            this.label5.Text = "Материал";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(58, 266);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Вид ";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // productType_textBox
            // 
            this.productType_textBox.Location = new System.Drawing.Point(93, 263);
            this.productType_textBox.Name = "productType_textBox";
            this.productType_textBox.Size = new System.Drawing.Size(271, 20);
            this.productType_textBox.TabIndex = 11;
            // 
            // productName_textBox
            // 
            this.productName_textBox.Location = new System.Drawing.Point(93, 124);
            this.productName_textBox.Name = "productName_textBox";
            this.productName_textBox.Size = new System.Drawing.Size(271, 20);
            this.productName_textBox.TabIndex = 9;
            // 
            // client_textBox
            // 
            this.client_textBox.Location = new System.Drawing.Point(93, 41);
            this.client_textBox.Name = "client_textBox";
            this.client_textBox.Size = new System.Drawing.Size(271, 20);
            this.client_textBox.TabIndex = 8;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(33, 316);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(54, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Размеры";
            // 
            // productSize_textBox
            // 
            this.productSize_textBox.Location = new System.Drawing.Point(93, 316);
            this.productSize_textBox.Name = "productSize_textBox";
            this.productSize_textBox.Size = new System.Drawing.Size(271, 20);
            this.productSize_textBox.TabIndex = 12;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(25, 367);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(62, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "Стоимость";
            // 
            // productCost_textBox
            // 
            this.productCost_textBox.Location = new System.Drawing.Point(93, 367);
            this.productCost_textBox.Name = "productCost_textBox";
            this.productCost_textBox.Size = new System.Drawing.Size(271, 20);
            this.productCost_textBox.TabIndex = 13;
            // 
            // addOrder_button
            // 
            this.addOrder_button.Location = new System.Drawing.Point(29, 419);
            this.addOrder_button.Name = "addOrder_button";
            this.addOrder_button.Size = new System.Drawing.Size(334, 52);
            this.addOrder_button.TabIndex = 14;
            this.addOrder_button.Text = "Добавить";
            this.addOrder_button.UseVisualStyleBackColor = true;
            this.addOrder_button.Click += new System.EventHandler(this.addOrder_button_Click);
            // 
            // AddOrderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(507, 635);
            this.Controls.Add(this.addOrder_button);
            this.Controls.Add(this.productCost_textBox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.productSize_textBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.client_textBox);
            this.Controls.Add(this.productName_textBox);
            this.Controls.Add(this.productType_textBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.productAmount_textBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "AddOrderForm";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox productAmount_textBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox productType_textBox;
        private System.Windows.Forms.TextBox productName_textBox;
        private System.Windows.Forms.TextBox client_textBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox productSize_textBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox productCost_textBox;
        private System.Windows.Forms.Button addOrder_button;
    }
}


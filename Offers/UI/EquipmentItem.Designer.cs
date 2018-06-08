namespace Offers.UI
{
    partial class EquipmentItem
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lb_name = new System.Windows.Forms.Label();
            this.tb_count = new System.Windows.Forms.NumericUpDown();
            this.tb_price = new System.Windows.Forms.TextBox();
            this.tb_amount = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.tb_count)).BeginInit();
            this.SuspendLayout();
            // 
            // lb_name
            // 
            this.lb_name.AutoSize = true;
            this.lb_name.Location = new System.Drawing.Point(12, 19);
            this.lb_name.Name = "lb_name";
            this.lb_name.Size = new System.Drawing.Size(35, 13);
            this.lb_name.TabIndex = 0;
            this.lb_name.Text = "label1";
            // 
            // tb_count
            // 
            this.tb_count.Location = new System.Drawing.Point(407, 24);
            this.tb_count.Name = "tb_count";
            this.tb_count.Size = new System.Drawing.Size(50, 20);
            this.tb_count.TabIndex = 1;
            this.tb_count.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.tb_count.ValueChanged += new System.EventHandler(this.tb_count_ValueChanged);
            this.tb_count.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_count_KeyPress);
            this.tb_count.Leave += new System.EventHandler(this.tb_count_Leave);
            // 
            // tb_price
            // 
            this.tb_price.Location = new System.Drawing.Point(339, 24);
            this.tb_price.Name = "tb_price";
            this.tb_price.Size = new System.Drawing.Size(58, 20);
            this.tb_price.TabIndex = 2;
            this.tb_price.TextChanged += new System.EventHandler(this.tb_price_TextChanged);
            this.tb_price.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_price_KeyPress);
            this.tb_price.Leave += new System.EventHandler(this.tb_price_Leave);
            // 
            // tb_amount
            // 
            this.tb_amount.Location = new System.Drawing.Point(464, 24);
            this.tb_amount.Name = "tb_amount";
            this.tb_amount.Size = new System.Drawing.Size(57, 20);
            this.tb_amount.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(336, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Цена за 1 шт";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(416, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Кол-во";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(484, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Итого";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(531, 30);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(50, 13);
            this.linkLabel1.TabIndex = 7;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Удалить";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // EquipmentItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tb_amount);
            this.Controls.Add(this.tb_price);
            this.Controls.Add(this.tb_count);
            this.Controls.Add(this.lb_name);
            this.Name = "EquipmentItem";
            this.Size = new System.Drawing.Size(590, 51);
            ((System.ComponentModel.ISupportInitialize)(this.tb_count)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lb_name;
        private System.Windows.Forms.NumericUpDown tb_count;
        private System.Windows.Forms.TextBox tb_price;
        private System.Windows.Forms.TextBox tb_amount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.LinkLabel linkLabel1;
    }
}

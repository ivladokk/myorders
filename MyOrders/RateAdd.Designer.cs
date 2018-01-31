namespace MyOrders
{
    partial class RateAdd
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
            this.lb1 = new System.Windows.Forms.Label();
            this.cb_from = new System.Windows.Forms.ComboBox();
            this.cb_to = new System.Windows.Forms.ComboBox();
            this.tb_scale = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_value = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_save = new System.Windows.Forms.Button();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 0;
            // 
            // lb1
            // 
            this.lb1.AutoSize = true;
            this.lb1.Location = new System.Drawing.Point(104, 15);
            this.lb1.Name = "lb1";
            this.lb1.Size = new System.Drawing.Size(13, 13);
            this.lb1.TabIndex = 1;
            this.lb1.Text = "к";
            // 
            // cb_from
            // 
            this.cb_from.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_from.FormattingEnabled = true;
            this.cb_from.Location = new System.Drawing.Point(12, 12);
            this.cb_from.Name = "cb_from";
            this.cb_from.Size = new System.Drawing.Size(86, 21);
            this.cb_from.TabIndex = 2;
            // 
            // cb_to
            // 
            this.cb_to.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_to.FormattingEnabled = true;
            this.cb_to.Location = new System.Drawing.Point(123, 12);
            this.cb_to.Name = "cb_to";
            this.cb_to.Size = new System.Drawing.Size(86, 21);
            this.cb_to.TabIndex = 3;
            // 
            // tb_scale
            // 
            this.tb_scale.Location = new System.Drawing.Point(12, 56);
            this.tb_scale.Name = "tb_scale";
            this.tb_scale.Size = new System.Drawing.Size(39, 21);
            this.tb_scale.TabIndex = 4;
            this.tb_scale.Text = "1";
            this.tb_scale.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_scale_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Колич-во";
            // 
            // tb_value
            // 
            this.tb_value.Location = new System.Drawing.Point(123, 56);
            this.tb_value.Name = "tb_value";
            this.tb_value.Size = new System.Drawing.Size(86, 21);
            this.tb_value.TabIndex = 6;
            this.tb_value.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_value_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(120, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Курс";
            // 
            // btn_save
            // 
            this.btn_save.Location = new System.Drawing.Point(11, 82);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(75, 23);
            this.btn_save.TabIndex = 8;
            this.btn_save.Text = "Сохранить";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // btn_cancel
            // 
            this.btn_cancel.Location = new System.Drawing.Point(133, 82);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_cancel.TabIndex = 9;
            this.btn_cancel.Text = "Отмена";
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // RateAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(220, 116);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tb_value);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tb_scale);
            this.Controls.Add(this.cb_to);
            this.Controls.Add(this.cb_from);
            this.Controls.Add(this.lb1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "RateAdd";
            this.Text = "RateAdd";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lb1;
        private System.Windows.Forms.ComboBox cb_from;
        private System.Windows.Forms.ComboBox cb_to;
        private System.Windows.Forms.TextBox tb_scale;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_value;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Button btn_cancel;
    }
}
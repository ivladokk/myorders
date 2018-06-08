namespace CalculationModule.UI
{
    partial class CalculationItemForm
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
            this.tb_name = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_value = new System.Windows.Forms.RichTextBox();
            this.lb_items = new System.Windows.Forms.ListBox();
            this.lb_constants = new System.Windows.Forms.ListBox();
            this.btn_save = new System.Windows.Forms.Button();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.lb_attrs = new System.Windows.Forms.ListBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // tb_name
            // 
            this.tb_name.Location = new System.Drawing.Point(12, 25);
            this.tb_name.Name = "tb_name";
            this.tb_name.Size = new System.Drawing.Size(259, 21);
            this.tb_name.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Название";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Формула";
            // 
            // tb_value
            // 
            this.tb_value.Location = new System.Drawing.Point(12, 65);
            this.tb_value.Name = "tb_value";
            this.tb_value.Size = new System.Drawing.Size(509, 134);
            this.tb_value.TabIndex = 3;
            this.tb_value.Text = "";
            // 
            // lb_items
            // 
            this.lb_items.FormattingEnabled = true;
            this.lb_items.Location = new System.Drawing.Point(12, 205);
            this.lb_items.Name = "lb_items";
            this.lb_items.Size = new System.Drawing.Size(180, 134);
            this.lb_items.TabIndex = 4;
            this.lb_items.DoubleClick += new System.EventHandler(this.lb_items_DoubleClick);
            // 
            // lb_constants
            // 
            this.lb_constants.FormattingEnabled = true;
            this.lb_constants.Location = new System.Drawing.Point(198, 205);
            this.lb_constants.Name = "lb_constants";
            this.lb_constants.Size = new System.Drawing.Size(160, 134);
            this.lb_constants.TabIndex = 5;
            this.lb_constants.DoubleClick += new System.EventHandler(this.lb_constants_DoubleClick);
            // 
            // btn_save
            // 
            this.btn_save.Location = new System.Drawing.Point(12, 346);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(125, 23);
            this.btn_save.TabIndex = 6;
            this.btn_save.Text = "ОК";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // btn_cancel
            // 
            this.btn_cancel.Location = new System.Drawing.Point(396, 345);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(125, 23);
            this.btn_cancel.TabIndex = 7;
            this.btn_cancel.Text = "Отмена";
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // lb_attrs
            // 
            this.lb_attrs.FormattingEnabled = true;
            this.lb_attrs.Location = new System.Drawing.Point(364, 205);
            this.lb_attrs.Name = "lb_attrs";
            this.lb_attrs.Size = new System.Drawing.Size(157, 134);
            this.lb_attrs.TabIndex = 8;
            this.lb_attrs.DoubleClick += new System.EventHandler(this.lb_attrs_DoubleClick);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(278, 28);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(55, 17);
            this.checkBox1.TabIndex = 9;
            this.checkBox1.Text = "сумма";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(364, 29);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(79, 17);
            this.checkBox2.TabIndex = 10;
            this.checkBox2.Text = "округлять";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // CalculationItemForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(533, 385);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.lb_attrs);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.lb_constants);
            this.Controls.Add(this.lb_items);
            this.Controls.Add(this.tb_value);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tb_name);
            this.Name = "CalculationItemForm";
            this.Text = "CalculationItemForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tb_name;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox tb_value;
        private System.Windows.Forms.ListBox lb_items;
        private System.Windows.Forms.ListBox lb_constants;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.ListBox lb_attrs;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox2;
    }
}
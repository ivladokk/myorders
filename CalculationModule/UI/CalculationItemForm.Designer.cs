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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.lb_dynamics = new System.Windows.Forms.ListBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tb_name
            // 
            this.tb_name.Location = new System.Drawing.Point(6, 14);
            this.tb_name.Name = "tb_name";
            this.tb_name.Size = new System.Drawing.Size(259, 21);
            this.tb_name.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Название";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Формула";
            // 
            // tb_value
            // 
            this.tb_value.Location = new System.Drawing.Point(6, 16);
            this.tb_value.Name = "tb_value";
            this.tb_value.Size = new System.Drawing.Size(808, 50);
            this.tb_value.TabIndex = 3;
            this.tb_value.Text = "";
            // 
            // lb_items
            // 
            this.lb_items.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_items.FormattingEnabled = true;
            this.lb_items.Location = new System.Drawing.Point(0, 0);
            this.lb_items.Name = "lb_items";
            this.lb_items.ScrollAlwaysVisible = true;
            this.lb_items.Size = new System.Drawing.Size(203, 260);
            this.lb_items.TabIndex = 4;
            this.lb_items.DoubleClick += new System.EventHandler(this.lb_items_DoubleClick);
            // 
            // lb_constants
            // 
            this.lb_constants.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_constants.FormattingEnabled = true;
            this.lb_constants.Location = new System.Drawing.Point(0, 0);
            this.lb_constants.Name = "lb_constants";
            this.lb_constants.ScrollAlwaysVisible = true;
            this.lb_constants.Size = new System.Drawing.Size(203, 260);
            this.lb_constants.TabIndex = 5;
            this.lb_constants.DoubleClick += new System.EventHandler(this.lb_constants_DoubleClick);
            // 
            // btn_save
            // 
            this.btn_save.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_save.Location = new System.Drawing.Point(3, 401);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(203, 23);
            this.btn_save.TabIndex = 6;
            this.btn_save.Text = "ОК";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // btn_cancel
            // 
            this.btn_cancel.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_cancel.Location = new System.Drawing.Point(630, 401);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(203, 23);
            this.btn_cancel.TabIndex = 7;
            this.btn_cancel.Text = "Отмена";
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // lb_attrs
            // 
            this.lb_attrs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_attrs.FormattingEnabled = true;
            this.lb_attrs.Location = new System.Drawing.Point(0, 0);
            this.lb_attrs.Name = "lb_attrs";
            this.lb_attrs.ScrollAlwaysVisible = true;
            this.lb_attrs.Size = new System.Drawing.Size(203, 260);
            this.lb_attrs.TabIndex = 8;
            this.lb_attrs.DoubleClick += new System.EventHandler(this.lb_attrs_DoubleClick);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(268, 18);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(55, 17);
            this.checkBox1.TabIndex = 9;
            this.checkBox1.Text = "сумма";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(329, 18);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(79, 17);
            this.checkBox2.TabIndex = 10;
            this.checkBox2.Text = "округлять";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.panel6, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel5, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel4, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btn_save, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.btn_cancel, 3, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(836, 444);
            this.tableLayoutPanel1.TabIndex = 11;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.lb_dynamics);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(630, 135);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(203, 260);
            this.panel6.TabIndex = 6;
            // 
            // lb_dynamics
            // 
            this.lb_dynamics.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_dynamics.FormattingEnabled = true;
            this.lb_dynamics.Location = new System.Drawing.Point(0, 0);
            this.lb_dynamics.Name = "lb_dynamics";
            this.lb_dynamics.ScrollAlwaysVisible = true;
            this.lb_dynamics.Size = new System.Drawing.Size(203, 260);
            this.lb_dynamics.TabIndex = 12;
            this.lb_dynamics.DoubleClick += new System.EventHandler(this.lb_dynamics_DoubleClick);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.lb_attrs);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(421, 135);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(203, 260);
            this.panel5.TabIndex = 5;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.lb_constants);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(212, 135);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(203, 260);
            this.panel4.TabIndex = 4;
            // 
            // panel1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel1, 4);
            this.panel1.Controls.Add(this.tb_value);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 47);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(830, 82);
            this.panel1.TabIndex = 1;
            // 
            // panel2
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel2, 4);
            this.panel2.Controls.Add(this.checkBox1);
            this.panel2.Controls.Add(this.checkBox2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.tb_name);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(830, 38);
            this.panel2.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lb_items);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 135);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(203, 260);
            this.panel3.TabIndex = 3;
            // 
            // CalculationItemForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(836, 444);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "CalculationItemForm";
            this.Text = "CalculationItemForm";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

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
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.ListBox lb_dynamics;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
    }
}
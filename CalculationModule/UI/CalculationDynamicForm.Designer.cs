namespace CalculationModule.UI
{
    partial class CalculationDynamicForm
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
            this.tb_express = new System.Windows.Forms.TextBox();
            this.btn_save = new System.Windows.Forms.Button();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.lb_attrs = new System.Windows.Forms.ListBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lb_constants = new System.Windows.Forms.ListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lb_items = new System.Windows.Forms.ListBox();
            this.lb_dynamics = new System.Windows.Forms.ListBox();
            this.panel6 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel6.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tb_name
            // 
            this.tb_name.Location = new System.Drawing.Point(6, 14);
            this.tb_name.Name = "tb_name";
            this.tb_name.Size = new System.Drawing.Size(317, 21);
            this.tb_name.TabIndex = 0;
            // 
            // tb_express
            // 
            this.tb_express.Location = new System.Drawing.Point(7, 16);
            this.tb_express.Multiline = true;
            this.tb_express.Name = "tb_express";
            this.tb_express.Size = new System.Drawing.Size(432, 59);
            this.tb_express.TabIndex = 3;
            // 
            // btn_save
            // 
            this.btn_save.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_save.Location = new System.Drawing.Point(3, 381);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(160, 23);
            this.btn_save.TabIndex = 4;
            this.btn_save.Text = "Сохранить";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // btn_cancel
            // 
            this.btn_cancel.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_cancel.Location = new System.Drawing.Point(501, 381);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(162, 23);
            this.btn_cancel.TabIndex = 5;
            this.btn_cancel.Text = "Отмена";
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.lb_attrs);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(335, 129);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(160, 246);
            this.panel5.TabIndex = 5;
            // 
            // lb_attrs
            // 
            this.lb_attrs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_attrs.FormattingEnabled = true;
            this.lb_attrs.Location = new System.Drawing.Point(0, 0);
            this.lb_attrs.Name = "lb_attrs";
            this.lb_attrs.ScrollAlwaysVisible = true;
            this.lb_attrs.Size = new System.Drawing.Size(160, 246);
            this.lb_attrs.TabIndex = 8;
            this.lb_attrs.DoubleClick += new System.EventHandler(this.lb_attrs_DoubleClick);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.lb_constants);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(169, 129);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(160, 246);
            this.panel4.TabIndex = 4;
            // 
            // lb_constants
            // 
            this.lb_constants.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_constants.FormattingEnabled = true;
            this.lb_constants.Location = new System.Drawing.Point(0, 0);
            this.lb_constants.Name = "lb_constants";
            this.lb_constants.ScrollAlwaysVisible = true;
            this.lb_constants.Size = new System.Drawing.Size(160, 246);
            this.lb_constants.TabIndex = 5;
            this.lb_constants.DoubleClick += new System.EventHandler(this.lb_constants_DoubleClick);
            // 
            // panel1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel1, 4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.tb_express);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 45);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(660, 78);
            this.panel1.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Формула";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lb_items);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 129);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(160, 246);
            this.panel3.TabIndex = 3;
            // 
            // lb_items
            // 
            this.lb_items.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_items.FormattingEnabled = true;
            this.lb_items.Location = new System.Drawing.Point(0, 0);
            this.lb_items.Name = "lb_items";
            this.lb_items.ScrollAlwaysVisible = true;
            this.lb_items.Size = new System.Drawing.Size(160, 246);
            this.lb_items.TabIndex = 4;
            this.lb_items.DoubleClick += new System.EventHandler(this.lb_items_DoubleClick);
            // 
            // lb_dynamics
            // 
            this.lb_dynamics.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_dynamics.FormattingEnabled = true;
            this.lb_dynamics.Location = new System.Drawing.Point(0, 0);
            this.lb_dynamics.Name = "lb_dynamics";
            this.lb_dynamics.ScrollAlwaysVisible = true;
            this.lb_dynamics.Size = new System.Drawing.Size(162, 246);
            this.lb_dynamics.TabIndex = 12;
            this.lb_dynamics.DoubleClick += new System.EventHandler(this.lb_dynamics_DoubleClick);
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.lb_dynamics);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(501, 129);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(162, 246);
            this.panel6.TabIndex = 6;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.panel6, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.btn_save, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.btn_cancel, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.panel5, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel4, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(666, 420);
            this.tableLayoutPanel1.TabIndex = 12;
            // 
            // panel2
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel2, 4);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.tb_name);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(660, 36);
            this.panel2.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Название";
            // 
            // CalculationDynamicForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(666, 420);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "CalculationDynamicForm";
            this.Text = "CalculationDynamicForm";
            this.panel5.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox tb_name;
        private System.Windows.Forms.TextBox tb_express;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.ListBox lb_attrs;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.ListBox lb_constants;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.ListBox lb_dynamics;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ListBox lb_items;
        private System.Windows.Forms.Label label3;
    }
}
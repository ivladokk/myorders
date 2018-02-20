using System;
using System.Windows.Forms;

namespace MyOrders
{
    partial class Payments
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Payments));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.добавитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.изменитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отразитьНаБалансеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ConvertToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.предварительныйРасчетToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.показатьПредварительныйРасчетToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_NextWeek = new DevExpress.XtraEditors.SimpleButton();
            this.tb_CurrentWeek = new System.Windows.Forms.TextBox();
            this.btn_PrevWeek = new DevExpress.XtraEditors.SimpleButton();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.ConvertToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.добавитьВПредварительныйРасчетToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.показатьПредварительныйРасчетToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lb_balance = new System.Windows.Forms.ToolStripStatusLabel();
            this.удалитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.удалитьToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.отменитьПроводкуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отменитьПроводкуToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.contextMenuStrip2.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(31)))), ((int)(((byte)(53)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView1.Location = new System.Drawing.Point(3, 3);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White;
            this.dataGridView1.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.DarkGray;
            this.dataGridView1.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ShowEditingIcon = false;
            this.dataGridView1.ShowRowErrors = false;
            this.dataGridView1.Size = new System.Drawing.Size(1015, 236);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseDoubleClick);
            this.dataGridView1.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseDown);
            this.dataGridView1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dataGridView1_KeyPress);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.добавитьToolStripMenuItem,
            this.изменитьToolStripMenuItem,
            this.удалитьToolStripMenuItem,
            this.отразитьНаБалансеToolStripMenuItem,
            this.ConvertToolStripMenuItem,
            this.предварительныйРасчетToolStripMenuItem,
            this.показатьПредварительныйРасчетToolStripMenuItem,
            this.отменитьПроводкуToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(278, 180);
            // 
            // добавитьToolStripMenuItem
            // 
            this.добавитьToolStripMenuItem.Name = "добавитьToolStripMenuItem";
            this.добавитьToolStripMenuItem.Size = new System.Drawing.Size(277, 22);
            this.добавитьToolStripMenuItem.Text = "Добавить";
            this.добавитьToolStripMenuItem.Click += new System.EventHandler(this.добавитьToolStripMenuItem_Click);
            // 
            // изменитьToolStripMenuItem
            // 
            this.изменитьToolStripMenuItem.Name = "изменитьToolStripMenuItem";
            this.изменитьToolStripMenuItem.Size = new System.Drawing.Size(277, 22);
            this.изменитьToolStripMenuItem.Text = "Изменить";
            this.изменитьToolStripMenuItem.Click += new System.EventHandler(this.изменитьToolStripMenuItem_Click);
            // 
            // отразитьНаБалансеToolStripMenuItem
            // 
            this.отразитьНаБалансеToolStripMenuItem.Name = "отразитьНаБалансеToolStripMenuItem";
            this.отразитьНаБалансеToolStripMenuItem.Size = new System.Drawing.Size(277, 22);
            this.отразитьНаБалансеToolStripMenuItem.Text = "Отразить на балансе";
            this.отразитьНаБалансеToolStripMenuItem.Click += new System.EventHandler(this.отразитьНаБалансеToolStripMenuItem_Click);
            // 
            // ConvertToolStripMenuItem
            // 
            this.ConvertToolStripMenuItem.Name = "ConvertToolStripMenuItem";
            this.ConvertToolStripMenuItem.Size = new System.Drawing.Size(277, 22);
            this.ConvertToolStripMenuItem.Text = "Конвертировать..";
            // 
            // предварительныйРасчетToolStripMenuItem
            // 
            this.предварительныйРасчетToolStripMenuItem.Name = "предварительныйРасчетToolStripMenuItem";
            this.предварительныйРасчетToolStripMenuItem.Size = new System.Drawing.Size(277, 22);
            this.предварительныйРасчетToolStripMenuItem.Text = "Добавить в предварительный расчет";
            this.предварительныйРасчетToolStripMenuItem.Click += new System.EventHandler(this.предварительныйРасчетToolStripMenuItem_Click);
            // 
            // показатьПредварительныйРасчетToolStripMenuItem
            // 
            this.показатьПредварительныйРасчетToolStripMenuItem.Name = "показатьПредварительныйРасчетToolStripMenuItem";
            this.показатьПредварительныйРасчетToolStripMenuItem.Size = new System.Drawing.Size(277, 22);
            this.показатьПредварительныйРасчетToolStripMenuItem.Text = "Показать предварительный расчет";
            this.показатьПредварительныйРасчетToolStripMenuItem.Click += new System.EventHandler(this.показатьПредварительныйРасчетToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.panel1.Controls.Add(this.btn_NextWeek);
            this.panel1.Controls.Add(this.tb_CurrentWeek);
            this.panel1.Controls.Add(this.btn_PrevWeek);
            this.panel1.Location = new System.Drawing.Point(422, 494);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(147, 39);
            this.panel1.TabIndex = 6;
            // 
            // btn_NextWeek
            // 
            this.btn_NextWeek.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.btn_NextWeek.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_NextWeek.ImageOptions.Image")));
            this.btn_NextWeek.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btn_NextWeek.Location = new System.Drawing.Point(95, 8);
            this.btn_NextWeek.Name = "btn_NextWeek";
            this.btn_NextWeek.Size = new System.Drawing.Size(32, 21);
            this.btn_NextWeek.TabIndex = 3;
            this.btn_NextWeek.Click += new System.EventHandler(this.btn_NextWeek_Click);
            // 
            // tb_CurrentWeek
            // 
            this.tb_CurrentWeek.Location = new System.Drawing.Point(57, 8);
            this.tb_CurrentWeek.Name = "tb_CurrentWeek";
            this.tb_CurrentWeek.Size = new System.Drawing.Size(32, 20);
            this.tb_CurrentWeek.TabIndex = 4;
            // 
            // btn_PrevWeek
            // 
            this.btn_PrevWeek.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.btn_PrevWeek.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_PrevWeek.ImageOptions.Image")));
            this.btn_PrevWeek.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btn_PrevWeek.Location = new System.Drawing.Point(16, 8);
            this.btn_PrevWeek.Name = "btn_PrevWeek";
            this.btn_PrevWeek.Size = new System.Drawing.Size(35, 21);
            this.btn_PrevWeek.TabIndex = 2;
            this.btn_PrevWeek.Click += new System.EventHandler(this.btn_PrevWeek_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 505);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Текущая неделя:";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.dataGridView2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.dataGridView1, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(-2, 1);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1021, 485);
            this.tableLayoutPanel1.TabIndex = 8;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView2.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView2.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.ContextMenuStrip = this.contextMenuStrip2;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(31)))), ((int)(((byte)(53)))));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView2.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView2.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView2.Location = new System.Drawing.Point(3, 245);
            this.dataGridView2.MultiSelect = false;
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView2.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridView2.RowHeadersVisible = false;
            this.dataGridView2.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White;
            this.dataGridView2.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.DarkGray;
            this.dataGridView2.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView2.ShowEditingIcon = false;
            this.dataGridView2.ShowRowErrors = false;
            this.dataGridView2.Size = new System.Drawing.Size(1015, 237);
            this.dataGridView2.TabIndex = 1;
            this.dataGridView2.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellClick);
            this.dataGridView2.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView2_CellMouseDoubleClick);
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem2,
            this.удалитьToolStripMenuItem1,
            this.toolStripMenuItem3,
            this.ConvertToolStripMenuItem2,
            this.добавитьВПредварительныйРасчетToolStripMenuItem,
            this.показатьПредварительныйРасчетToolStripMenuItem1,
            this.отменитьПроводкуToolStripMenuItem1});
            this.contextMenuStrip2.Name = "contextMenuStrip1";
            this.contextMenuStrip2.Size = new System.Drawing.Size(278, 202);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(277, 22);
            this.toolStripMenuItem1.Text = "Добавить";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(277, 22);
            this.toolStripMenuItem2.Text = "Изменить";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(277, 22);
            this.toolStripMenuItem3.Text = "Отразить на балансе";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.toolStripMenuItem3_Click);
            // 
            // ConvertToolStripMenuItem2
            // 
            this.ConvertToolStripMenuItem2.Name = "ConvertToolStripMenuItem2";
            this.ConvertToolStripMenuItem2.Size = new System.Drawing.Size(277, 22);
            this.ConvertToolStripMenuItem2.Text = "Конвертировать..";
            // 
            // добавитьВПредварительныйРасчетToolStripMenuItem
            // 
            this.добавитьВПредварительныйРасчетToolStripMenuItem.Name = "добавитьВПредварительныйРасчетToolStripMenuItem";
            this.добавитьВПредварительныйРасчетToolStripMenuItem.Size = new System.Drawing.Size(277, 22);
            this.добавитьВПредварительныйРасчетToolStripMenuItem.Text = "Добавить в предварительный расчет";
            this.добавитьВПредварительныйРасчетToolStripMenuItem.Click += new System.EventHandler(this.добавитьВПредварительныйРасчетToolStripMenuItem_Click);
            // 
            // показатьПредварительныйРасчетToolStripMenuItem1
            // 
            this.показатьПредварительныйРасчетToolStripMenuItem1.Name = "показатьПредварительныйРасчетToolStripMenuItem1";
            this.показатьПредварительныйРасчетToolStripMenuItem1.Size = new System.Drawing.Size(277, 22);
            this.показатьПредварительныйРасчетToolStripMenuItem1.Text = "Показать предварительный расчет";
            this.показатьПредварительныйРасчетToolStripMenuItem1.Click += new System.EventHandler(this.показатьПредварительныйРасчетToolStripMenuItem1_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lb_balance});
            this.statusStrip1.Location = new System.Drawing.Point(0, 535);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1020, 22);
            this.statusStrip1.TabIndex = 9;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lb_balance
            // 
            this.lb_balance.Name = "lb_balance";
            this.lb_balance.Size = new System.Drawing.Size(113, 17);
            this.lb_balance.Text = "Остатки на сегодня";
            // 
            // удалитьToolStripMenuItem
            // 
            this.удалитьToolStripMenuItem.Name = "удалитьToolStripMenuItem";
            this.удалитьToolStripMenuItem.Size = new System.Drawing.Size(277, 22);
            this.удалитьToolStripMenuItem.Text = "Удалить";
            this.удалитьToolStripMenuItem.Click += new System.EventHandler(this.удалитьToolStripMenuItem_Click);
            // 
            // удалитьToolStripMenuItem1
            // 
            this.удалитьToolStripMenuItem1.Name = "удалитьToolStripMenuItem1";
            this.удалитьToolStripMenuItem1.Size = new System.Drawing.Size(277, 22);
            this.удалитьToolStripMenuItem1.Text = "Удалить";
            this.удалитьToolStripMenuItem1.Click += new System.EventHandler(this.удалитьToolStripMenuItem1_Click);
            // 
            // отменитьПроводкуToolStripMenuItem
            // 
            this.отменитьПроводкуToolStripMenuItem.Name = "отменитьПроводкуToolStripMenuItem";
            this.отменитьПроводкуToolStripMenuItem.Size = new System.Drawing.Size(277, 22);
            this.отменитьПроводкуToolStripMenuItem.Text = "Отменить проводку";
            this.отменитьПроводкуToolStripMenuItem.Click += new System.EventHandler(this.отменитьПроводкуToolStripMenuItem_Click);
            // 
            // отменитьПроводкуToolStripMenuItem1
            // 
            this.отменитьПроводкуToolStripMenuItem1.Name = "отменитьПроводкуToolStripMenuItem1";
            this.отменитьПроводкуToolStripMenuItem1.Size = new System.Drawing.Size(277, 22);
            this.отменитьПроводкуToolStripMenuItem1.Text = "Отменить проводку";
            this.отменитьПроводкуToolStripMenuItem1.Click += new System.EventHandler(this.отменитьПроводкуToolStripMenuItem1_Click);
            // 
            // Payments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1020, 557);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Name = "Payments";
            this.Text = "Payments";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.contextMenuStrip2.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        
        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.SimpleButton btn_NextWeek;
        private System.Windows.Forms.TextBox tb_CurrentWeek;
        private DevExpress.XtraEditors.SimpleButton btn_PrevWeek;
        
        private Label label1;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem добавитьToolStripMenuItem;
        private ToolStripMenuItem изменитьToolStripMenuItem;
        private TableLayoutPanel tableLayoutPanel1;
        private DataGridView dataGridView2;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel lb_balance;
        private ToolStripMenuItem отразитьНаБалансеToolStripMenuItem;
        private ContextMenuStrip contextMenuStrip2;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem toolStripMenuItem2;
        private ToolStripMenuItem toolStripMenuItem3;
        private ToolStripMenuItem ConvertToolStripMenuItem;
        private ToolStripMenuItem ConvertToolStripMenuItem2;
        private ToolStripMenuItem предварительныйРасчетToolStripMenuItem;
        private ToolStripMenuItem показатьПредварительныйРасчетToolStripMenuItem;
        private ToolStripMenuItem добавитьВПредварительныйРасчетToolStripMenuItem;
        private ToolStripMenuItem показатьПредварительныйРасчетToolStripMenuItem1;
        private ToolStripMenuItem удалитьToolStripMenuItem;
        private ToolStripMenuItem удалитьToolStripMenuItem1;
        private ToolStripMenuItem отменитьПроводкуToolStripMenuItem;
        private ToolStripMenuItem отменитьПроводкуToolStripMenuItem1;
    }
}
namespace CalculationModule
{
    partial class ProductsImport
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
            this.btn_refresh = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VendorCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.View = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Unit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GoodsGroup = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TNVEDCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Duty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TNVEDValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Owner = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Certificate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Declaration = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_import = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_refresh
            // 
            this.btn_refresh.Location = new System.Drawing.Point(12, 5);
            this.btn_refresh.Name = "btn_refresh";
            this.btn_refresh.Size = new System.Drawing.Size(113, 23);
            this.btn_refresh.TabIndex = 0;
            this.btn_refresh.Text = "Импорт из Excell";
            this.btn_refresh.UseVisualStyleBackColor = true;
            this.btn_refresh.Click += new System.EventHandler(this.btn_refresh_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Code,
            this.VendorCode,
            this.ProductName,
            this.View,
            this.Unit,
            this.GoodsGroup,
            this.TNVEDCode,
            this.Duty,
            this.TNVEDValue,
            this.Owner,
            this.Certificate,
            this.Declaration});
            this.dataGridView1.Location = new System.Drawing.Point(0, 34);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(429, 443);
            this.dataGridView1.TabIndex = 1;
            // 
            // Code
            // 
            this.Code.HeaderText = "Код";
            this.Code.Name = "Code";
            // 
            // VendorCode
            // 
            this.VendorCode.HeaderText = "Артикул";
            this.VendorCode.Name = "VendorCode";
            // 
            // ProductName
            // 
            this.ProductName.HeaderText = "Наименование";
            this.ProductName.Name = "ProductName";
            // 
            // View
            // 
            this.View.HeaderText = "Вид";
            this.View.Name = "View";
            // 
            // Unit
            // 
            this.Unit.HeaderText = "Ед. изм.";
            this.Unit.Name = "Unit";
            // 
            // GoodsGroup
            // 
            this.GoodsGroup.HeaderText = "Группа товаров";
            this.GoodsGroup.Name = "GoodsGroup";
            // 
            // TNVEDCode
            // 
            this.TNVEDCode.HeaderText = "Код ТНВЭД";
            this.TNVEDCode.Name = "TNVEDCode";
            // 
            // Duty
            // 
            this.Duty.HeaderText = "пошлина";
            this.Duty.Name = "Duty";
            // 
            // TNVEDValue
            // 
            this.TNVEDValue.HeaderText = "Ставка НДС";
            this.TNVEDValue.Name = "TNVEDValue";
            // 
            // Owner
            // 
            this.Owner.HeaderText = "Владелец";
            this.Owner.Name = "Owner";
            // 
            // Certificate
            // 
            this.Certificate.HeaderText = "Сертификат соответствия";
            this.Certificate.Name = "Certificate";
            // 
            // Declaration
            // 
            this.Declaration.HeaderText = "декларация соответствия";
            this.Declaration.Name = "Declaration";
            // 
            // btn_import
            // 
            this.btn_import.Location = new System.Drawing.Point(346, 5);
            this.btn_import.Name = "btn_import";
            this.btn_import.Size = new System.Drawing.Size(75, 23);
            this.btn_import.TabIndex = 2;
            this.btn_import.Text = "Сохранить";
            this.btn_import.UseVisualStyleBackColor = true;
            this.btn_import.Click += new System.EventHandler(this.btn_import_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(149, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(113, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Импорт из файла";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ProductsImport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(429, 477);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btn_import);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btn_refresh);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ProductsImport";
            this.Text = "ProductsImport";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_refresh;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btn_import;
        private System.Windows.Forms.DataGridViewTextBoxColumn Code;
        private System.Windows.Forms.DataGridViewTextBoxColumn VendorCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn View;
        private System.Windows.Forms.DataGridViewTextBoxColumn Unit;
        private System.Windows.Forms.DataGridViewTextBoxColumn GoodsGroup;
        private System.Windows.Forms.DataGridViewTextBoxColumn TNVEDCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn Duty;
        private System.Windows.Forms.DataGridViewTextBoxColumn TNVEDValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn Owner;
        private System.Windows.Forms.DataGridViewTextBoxColumn Certificate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Declaration;
        private System.Windows.Forms.Button button1;
    }
}
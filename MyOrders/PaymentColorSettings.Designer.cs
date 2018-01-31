namespace MyOrders
{
    partial class PaymentColorSettings
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
            this.cb_Colors = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_Add = new DevExpress.XtraEditors.SimpleButton();
            this.btn_Edit = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.btn_Save = new DevExpress.XtraEditors.SimpleButton();
            this.label4 = new System.Windows.Forms.Label();
            this.tb_ColorName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ce_ColorValue = new DevExpress.XtraEditors.ColorEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_Value = new System.Windows.Forms.TextBox();
            this.btn_delete = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ce_ColorValue.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // cb_Colors
            // 
            this.cb_Colors.FormattingEnabled = true;
            this.cb_Colors.Location = new System.Drawing.Point(13, 28);
            this.cb_Colors.Name = "cb_Colors";
            this.cb_Colors.Size = new System.Drawing.Size(259, 21);
            this.cb_Colors.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Цвет/Значение";
            // 
            // btn_Add
            // 
            this.btn_Add.Location = new System.Drawing.Point(13, 64);
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(75, 23);
            this.btn_Add.TabIndex = 2;
            this.btn_Add.Text = "Добавить";
            this.btn_Add.Click += new System.EventHandler(this.btn_Add_Click);
            // 
            // btn_Edit
            // 
            this.btn_Edit.Location = new System.Drawing.Point(106, 64);
            this.btn_Edit.Name = "btn_Edit";
            this.btn_Edit.Size = new System.Drawing.Size(75, 23);
            this.btn_Edit.TabIndex = 3;
            this.btn_Edit.Text = "Изменить";
            this.btn_Edit.Click += new System.EventHandler(this.btn_Edit_Click);
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.btn_Save);
            this.groupControl1.Controls.Add(this.label4);
            this.groupControl1.Controls.Add(this.tb_ColorName);
            this.groupControl1.Controls.Add(this.label3);
            this.groupControl1.Controls.Add(this.ce_ColorValue);
            this.groupControl1.Controls.Add(this.label2);
            this.groupControl1.Controls.Add(this.tb_Value);
            this.groupControl1.Location = new System.Drawing.Point(0, 105);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(285, 198);
            this.groupControl1.TabIndex = 4;
            this.groupControl1.Text = "Настройки цвета";
            // 
            // btn_Save
            // 
            this.btn_Save.Location = new System.Drawing.Point(95, 163);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(75, 23);
            this.btn_Save.TabIndex = 7;
            this.btn_Save.Text = "Сохранить";
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 110);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Имя цвета";
            // 
            // tb_ColorName
            // 
            this.tb_ColorName.Location = new System.Drawing.Point(12, 126);
            this.tb_ColorName.Name = "tb_ColorName";
            this.tb_ColorName.Size = new System.Drawing.Size(266, 21);
            this.tb_ColorName.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Цвет";
            // 
            // ce_ColorValue
            // 
            this.ce_ColorValue.EditValue = System.Drawing.Color.Empty;
            this.ce_ColorValue.Location = new System.Drawing.Point(12, 81);
            this.ce_ColorValue.Name = "ce_ColorValue";
            this.ce_ColorValue.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ce_ColorValue.Size = new System.Drawing.Size(263, 20);
            this.ce_ColorValue.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Значение";
            // 
            // tb_Value
            // 
            this.tb_Value.Location = new System.Drawing.Point(12, 41);
            this.tb_Value.Name = "tb_Value";
            this.tb_Value.Size = new System.Drawing.Size(266, 21);
            this.tb_Value.TabIndex = 0;
            // 
            // btn_delete
            // 
            this.btn_delete.Location = new System.Drawing.Point(197, 64);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(75, 23);
            this.btn_delete.TabIndex = 5;
            this.btn_delete.Text = "Удалить";
            this.btn_delete.Click += new System.EventHandler(this.btn_delete_Click);
            // 
            // PaymentColorSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 303);
            this.Controls.Add(this.btn_delete);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.btn_Edit);
            this.Controls.Add(this.btn_Add);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cb_Colors);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "PaymentColorSettings";
            this.Text = "PaymentColorSettings";
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ce_ColorValue.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cb_Colors;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.SimpleButton btn_Add;
        private DevExpress.XtraEditors.SimpleButton btn_Edit;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tb_ColorName;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.ColorEdit ce_ColorValue;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_Value;
        private DevExpress.XtraEditors.SimpleButton btn_Save;
        private DevExpress.XtraEditors.SimpleButton btn_delete;
    }
}
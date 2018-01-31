namespace MyOrders
{
    partial class EditPaymentForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditPaymentForm));
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.cb_PaymentType = new System.Windows.Forms.ComboBox();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.de_PaymentDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cb_Currency = new System.Windows.Forms.ComboBox();
            this.tb_Sum = new System.Windows.Forms.TextBox();
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.btn_AddAgent = new DevExpress.XtraEditors.SimpleButton();
            this.cb_Contragent = new DevExpress.XtraEditors.LookUpEdit();
            this.groupControl4 = new DevExpress.XtraEditors.GroupControl();
            this.tb_Comments = new System.Windows.Forms.TextBox();
            this.groupControl5 = new DevExpress.XtraEditors.GroupControl();
            this.cb_PaymentStatus = new System.Windows.Forms.ComboBox();
            this.btn_Save = new DevExpress.XtraEditors.SimpleButton();
            this.btn_Cancel = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl6 = new DevExpress.XtraEditors.GroupControl();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tb_Acc = new System.Windows.Forms.TextBox();
            this.tb_CreditNum = new System.Windows.Forms.TextBox();
            this.groupControl7 = new DevExpress.XtraEditors.GroupControl();
            this.de_ControlDate = new System.Windows.Forms.DateTimePicker();
            this.groupControl8 = new DevExpress.XtraEditors.GroupControl();
            this.cb_Color = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cb_Contragent.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl8)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.cb_PaymentType);
            this.groupControl1.Location = new System.Drawing.Point(5, 3);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(390, 54);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "Приход/Расход";
            // 
            // cb_PaymentType
            // 
            this.cb_PaymentType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_PaymentType.FormattingEnabled = true;
            this.cb_PaymentType.Location = new System.Drawing.Point(8, 24);
            this.cb_PaymentType.Name = "cb_PaymentType";
            this.cb_PaymentType.Size = new System.Drawing.Size(373, 21);
            this.cb_PaymentType.TabIndex = 0;
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.de_PaymentDate);
            this.groupControl2.Controls.Add(this.label3);
            this.groupControl2.Controls.Add(this.label2);
            this.groupControl2.Controls.Add(this.label1);
            this.groupControl2.Controls.Add(this.cb_Currency);
            this.groupControl2.Controls.Add(this.tb_Sum);
            this.groupControl2.Location = new System.Drawing.Point(4, 197);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(391, 68);
            this.groupControl2.TabIndex = 1;
            this.groupControl2.Text = "Платёж";
            // 
            // de_PaymentDate
            // 
            this.de_PaymentDate.Location = new System.Drawing.Point(259, 36);
            this.de_PaymentDate.Name = "de_PaymentDate";
            this.de_PaymentDate.Size = new System.Drawing.Size(123, 21);
            this.de_PaymentDate.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(256, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Дата";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Сумма";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(153, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Валюта";
            // 
            // cb_Currency
            // 
            this.cb_Currency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Currency.FormattingEnabled = true;
            this.cb_Currency.Location = new System.Drawing.Point(153, 36);
            this.cb_Currency.Name = "cb_Currency";
            this.cb_Currency.Size = new System.Drawing.Size(80, 21);
            this.cb_Currency.TabIndex = 1;
            // 
            // tb_Sum
            // 
            this.tb_Sum.Location = new System.Drawing.Point(9, 36);
            this.tb_Sum.Name = "tb_Sum";
            this.tb_Sum.Size = new System.Drawing.Size(112, 21);
            this.tb_Sum.TabIndex = 0;
            this.tb_Sum.Text = "0.00";
            this.tb_Sum.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_Sum_KeyPress);
            // 
            // groupControl3
            // 
            this.groupControl3.Controls.Add(this.btn_AddAgent);
            this.groupControl3.Controls.Add(this.cb_Contragent);
            this.groupControl3.Location = new System.Drawing.Point(5, 131);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Size = new System.Drawing.Size(390, 60);
            this.groupControl3.TabIndex = 2;
            this.groupControl3.Text = "Контрагент";
            // 
            // btn_AddAgent
            // 
            this.btn_AddAgent.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.btn_AddAgent.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_AddAgent.ImageOptions.Image")));
            this.btn_AddAgent.Location = new System.Drawing.Point(360, 23);
            this.btn_AddAgent.Name = "btn_AddAgent";
            this.btn_AddAgent.Size = new System.Drawing.Size(21, 21);
            this.btn_AddAgent.TabIndex = 1;
            this.btn_AddAgent.Click += new System.EventHandler(this.btn_AddAgent_Click);
            // 
            // cb_Contragent
            // 
            this.cb_Contragent.Location = new System.Drawing.Point(8, 24);
            this.cb_Contragent.Name = "cb_Contragent";
            // 
            // 
            // 
            this.cb_Contragent.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cb_Contragent.Size = new System.Drawing.Size(346, 20);
            this.cb_Contragent.TabIndex = 0;
            // 
            // groupControl4
            // 
            this.groupControl4.Controls.Add(this.tb_Comments);
            this.groupControl4.Location = new System.Drawing.Point(4, 393);
            this.groupControl4.Name = "groupControl4";
            this.groupControl4.Size = new System.Drawing.Size(390, 99);
            this.groupControl4.TabIndex = 3;
            this.groupControl4.Text = "Примечания";
            // 
            // tb_Comments
            // 
            this.tb_Comments.Location = new System.Drawing.Point(9, 23);
            this.tb_Comments.Multiline = true;
            this.tb_Comments.Name = "tb_Comments";
            this.tb_Comments.Size = new System.Drawing.Size(373, 70);
            this.tb_Comments.TabIndex = 1;
            // 
            // groupControl5
            // 
            this.groupControl5.Controls.Add(this.cb_PaymentStatus);
            this.groupControl5.Location = new System.Drawing.Point(4, 498);
            this.groupControl5.Name = "groupControl5";
            this.groupControl5.Size = new System.Drawing.Size(390, 58);
            this.groupControl5.TabIndex = 4;
            this.groupControl5.Text = "Статус платежа";
            // 
            // cb_PaymentStatus
            // 
            this.cb_PaymentStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_PaymentStatus.FormattingEnabled = true;
            this.cb_PaymentStatus.Location = new System.Drawing.Point(9, 23);
            this.cb_PaymentStatus.Name = "cb_PaymentStatus";
            this.cb_PaymentStatus.Size = new System.Drawing.Size(373, 21);
            this.cb_PaymentStatus.TabIndex = 1;
            // 
            // btn_Save
            // 
            this.btn_Save.Location = new System.Drawing.Point(13, 565);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(123, 40);
            this.btn_Save.TabIndex = 5;
            this.btn_Save.Text = "Сохранить";
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_Cancel.Location = new System.Drawing.Point(263, 565);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(123, 40);
            this.btn_Cancel.TabIndex = 6;
            this.btn_Cancel.Text = "Отмена";
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // groupControl6
            // 
            this.groupControl6.Controls.Add(this.label5);
            this.groupControl6.Controls.Add(this.label4);
            this.groupControl6.Controls.Add(this.tb_Acc);
            this.groupControl6.Controls.Add(this.tb_CreditNum);
            this.groupControl6.Location = new System.Drawing.Point(5, 271);
            this.groupControl6.Name = "groupControl6";
            this.groupControl6.Size = new System.Drawing.Size(389, 116);
            this.groupControl6.TabIndex = 7;
            this.groupControl6.Text = "Договор";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 64);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "№ счета";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "№ спецификации";
            // 
            // tb_Acc
            // 
            this.tb_Acc.Location = new System.Drawing.Point(10, 82);
            this.tb_Acc.Name = "tb_Acc";
            this.tb_Acc.Size = new System.Drawing.Size(371, 21);
            this.tb_Acc.TabIndex = 1;
            // 
            // tb_CreditNum
            // 
            this.tb_CreditNum.Location = new System.Drawing.Point(10, 40);
            this.tb_CreditNum.Name = "tb_CreditNum";
            this.tb_CreditNum.Size = new System.Drawing.Size(371, 21);
            this.tb_CreditNum.TabIndex = 0;
            // 
            // groupControl7
            // 
            this.groupControl7.Controls.Add(this.de_ControlDate);
            this.groupControl7.Location = new System.Drawing.Point(5, 64);
            this.groupControl7.Name = "groupControl7";
            this.groupControl7.Size = new System.Drawing.Size(183, 61);
            this.groupControl7.TabIndex = 8;
            this.groupControl7.Text = "Контрольная дата";
            // 
            // de_ControlDate
            // 
            this.de_ControlDate.Location = new System.Drawing.Point(8, 29);
            this.de_ControlDate.Name = "de_ControlDate";
            this.de_ControlDate.Size = new System.Drawing.Size(145, 21);
            this.de_ControlDate.TabIndex = 6;
            // 
            // groupControl8
            // 
            this.groupControl8.Controls.Add(this.cb_Color);
            this.groupControl8.Location = new System.Drawing.Point(194, 64);
            this.groupControl8.Name = "groupControl8";
            this.groupControl8.Size = new System.Drawing.Size(200, 61);
            this.groupControl8.TabIndex = 9;
            this.groupControl8.Text = "Цвет";
            this.groupControl8.Paint += new System.Windows.Forms.PaintEventHandler(this.groupControl8_Paint);
            // 
            // cb_Color
            // 
            this.cb_Color.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Color.FormattingEnabled = true;
            this.cb_Color.Location = new System.Drawing.Point(6, 28);
            this.cb_Color.Name = "cb_Color";
            this.cb_Color.Size = new System.Drawing.Size(186, 21);
            this.cb_Color.TabIndex = 0;
            // 
            // EditPaymentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btn_Cancel;
            this.ClientSize = new System.Drawing.Size(398, 619);
            this.Controls.Add(this.groupControl8);
            this.Controls.Add(this.groupControl7);
            this.Controls.Add(this.groupControl6);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_Save);
            this.Controls.Add(this.groupControl5);
            this.Controls.Add(this.groupControl4);
            this.Controls.Add(this.groupControl3);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.groupControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "EditPaymentForm";
            this.Text = "EditPaymentForm";
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cb_Contragent.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl8)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private System.Windows.Forms.ComboBox cb_PaymentType;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cb_Currency;
        private System.Windows.Forms.TextBox tb_Sum;
        private DevExpress.XtraEditors.GroupControl groupControl3;
        private DevExpress.XtraEditors.SimpleButton btn_AddAgent;
        private DevExpress.XtraEditors.LookUpEdit cb_Contragent;
        private DevExpress.XtraEditors.GroupControl groupControl4;
        private System.Windows.Forms.TextBox tb_Comments;
        private DevExpress.XtraEditors.GroupControl groupControl5;
        private System.Windows.Forms.ComboBox cb_PaymentStatus;
        private DevExpress.XtraEditors.SimpleButton btn_Save;
        private DevExpress.XtraEditors.SimpleButton btn_Cancel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker de_PaymentDate;
        private DevExpress.XtraEditors.GroupControl groupControl6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tb_Acc;
        private System.Windows.Forms.TextBox tb_CreditNum;
        private DevExpress.XtraEditors.GroupControl groupControl7;
        private System.Windows.Forms.DateTimePicker de_ControlDate;
        private DevExpress.XtraEditors.GroupControl groupControl8;
        private System.Windows.Forms.ComboBox cb_Color;
    }
}
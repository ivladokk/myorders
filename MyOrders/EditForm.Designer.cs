using System;
using System.ComponentModel;
using System.Linq;

namespace MyOrders
{
    partial class EditForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditForm));
            this.label6 = new System.Windows.Forms.Label();
            this.dt_ControlDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dt_OrderDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_AcceptNum = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cb_Status = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tb_PlaceCount = new System.Windows.Forms.TextBox();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.btn_Save = new DevExpress.XtraEditors.SimpleButton();
            this.cb_Contragent = new DevExpress.XtraEditors.LookUpEdit();
            this.cb_Provider = new DevExpress.XtraEditors.LookUpEdit();
            this.btn_AddAgent = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.flyoutPanel1 = new DevExpress.Utils.FlyoutPanel();
            this.flyoutPanelControl1 = new DevExpress.Utils.FlyoutPanelControl();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.tb_NumberKP = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cb_Contragent.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cb_Provider.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.flyoutPanel1)).BeginInit();
            this.flyoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.flyoutPanelControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 135);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(102, 13);
            this.label6.TabIndex = 34;
            this.label6.Text = "Контрольная дата";
            // 
            // dt_ControlDate
            // 
            this.dt_ControlDate.Location = new System.Drawing.Point(12, 150);
            this.dt_ControlDate.Name = "dt_ControlDate";
            this.dt_ControlDate.Size = new System.Drawing.Size(153, 21);
            this.dt_ControlDate.TabIndex = 35;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(230, 136);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 13);
            this.label2.TabIndex = 25;
            this.label2.Text = "Дата поставки по СО";
            // 
            // dt_OrderDate
            // 
            this.dt_OrderDate.Location = new System.Drawing.Point(230, 151);
            this.dt_OrderDate.Name = "dt_OrderDate";
            this.dt_OrderDate.Size = new System.Drawing.Size(153, 21);
            this.dt_OrderDate.TabIndex = 26;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 175);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(123, 13);
            this.label3.TabIndex = 27;
            this.label3.Text = "Номер подтверждения";
            // 
            // tb_AcceptNum
            // 
            this.tb_AcceptNum.Location = new System.Drawing.Point(12, 190);
            this.tb_AcceptNum.Name = "tb_AcceptNum";
            this.tb_AcceptNum.Size = new System.Drawing.Size(153, 21);
            this.tb_AcceptNum.TabIndex = 28;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(230, 99);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 29;
            this.label4.Text = "Статус";
            // 
            // cb_Status
            // 
            this.cb_Status.FormattingEnabled = true;
            this.cb_Status.Location = new System.Drawing.Point(229, 113);
            this.cb_Status.Name = "cb_Status";
            this.cb_Status.Size = new System.Drawing.Size(153, 21);
            this.cb_Status.TabIndex = 30;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(230, 175);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(121, 13);
            this.label5.TabIndex = 31;
            this.label5.Text = "Количество грузомест";
            // 
            // tb_PlaceCount
            // 
            this.tb_PlaceCount.Location = new System.Drawing.Point(230, 190);
            this.tb_PlaceCount.Name = "tb_PlaceCount";
            this.tb_PlaceCount.Size = new System.Drawing.Size(54, 21);
            this.tb_PlaceCount.TabIndex = 32;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.btn_Save);
            this.groupControl1.Controls.Add(this.label6);
            this.groupControl1.Controls.Add(this.tb_PlaceCount);
            this.groupControl1.Controls.Add(this.dt_ControlDate);
            this.groupControl1.Controls.Add(this.label5);
            this.groupControl1.Controls.Add(this.cb_Status);
            this.groupControl1.Controls.Add(this.label4);
            this.groupControl1.Controls.Add(this.label2);
            this.groupControl1.Controls.Add(this.tb_AcceptNum);
            this.groupControl1.Controls.Add(this.dt_OrderDate);
            this.groupControl1.Controls.Add(this.label3);
            this.groupControl1.Controls.Add(this.cb_Contragent);
            this.groupControl1.Controls.Add(this.cb_Provider);
            this.groupControl1.Controls.Add(this.btn_AddAgent);
            this.groupControl1.Location = new System.Drawing.Point(2, 4);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(453, 285);
            this.groupControl1.TabIndex = 36;
            this.groupControl1.Text = "Параметры заказа";
            // 
            // btn_Save
            // 
            this.btn_Save.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.btn_Save.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_Save.ImageOptions.Image")));
            this.btn_Save.Location = new System.Drawing.Point(12, 215);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(431, 36);
            this.btn_Save.TabIndex = 39;
            this.btn_Save.Text = "Сохранить";
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // cb_Contragent
            // 
            this.cb_Contragent.Location = new System.Drawing.Point(10, 35);
            this.cb_Contragent.Name = "cb_Contragent";
            // 
            // 
            // 
            this.cb_Contragent.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cb_Contragent.Size = new System.Drawing.Size(346, 20);
            this.cb_Contragent.TabIndex = 0;
            // 
            // cb_Provider
            // 
            this.cb_Provider.Location = new System.Drawing.Point(10, 75);
            this.cb_Provider.Name = "cb_Provider";
            // 
            // 
            // 
            this.cb_Provider.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cb_Provider.Size = new System.Drawing.Size(346, 20);
            this.cb_Provider.TabIndex = 0;
            // 
            // btn_AddAgent
            // 
            this.btn_AddAgent.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.btn_AddAgent.Location = new System.Drawing.Point(360, 35);
            this.btn_AddAgent.Name = "btn_AddAgent";
            this.btn_AddAgent.Size = new System.Drawing.Size(21, 21);
            this.btn_AddAgent.TabIndex = 1;
            this.btn_AddAgent.Text = "+";
            this.btn_AddAgent.Click += new System.EventHandler(this.btn_AddAgent_Click);
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.flowLayoutPanel1);
            this.groupControl2.Location = new System.Drawing.Point(2, 295);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(453, 261);
            this.groupControl2.TabIndex = 37;
            this.groupControl2.Text = "Грузы";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Controls.Add(this.flyoutPanel1);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(2, 20);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(449, 239);
            this.flowLayoutPanel1.TabIndex = 0;
            this.flowLayoutPanel1.WrapContents = false;
            // 
            // flyoutPanel1
            // 
            this.flyoutPanel1.Controls.Add(this.flyoutPanelControl1);
            this.flyoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.flyoutPanel1.Name = "flyoutPanel1";
            this.flyoutPanel1.OwnerControl = this.flowLayoutPanel1;
            this.flyoutPanel1.Size = new System.Drawing.Size(443, 213);
            this.flyoutPanel1.TabIndex = 0;
            // 
            // flyoutPanelControl1
            // 
            this.flyoutPanelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flyoutPanelControl1.FlyoutPanel = this.flyoutPanel1;
            this.flyoutPanelControl1.Location = new System.Drawing.Point(0, 0);
            this.flyoutPanelControl1.Name = "flyoutPanelControl1";
            this.flyoutPanelControl1.Size = new System.Drawing.Size(443, 213);
            this.flyoutPanelControl1.TabIndex = 0;
            // 
            // simpleButton1
            // 
            this.simpleButton1.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.simpleButton1.Location = new System.Drawing.Point(14, 260);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(98, 23);
            this.simpleButton1.TabIndex = 38;
            this.simpleButton1.Text = "Добавить груз";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // tb_NumberKP
            // 
            this.tb_NumberKP.Location = new System.Drawing.Point(14, 117);
            this.tb_NumberKP.Name = "tb_NumberKP";
            this.tb_NumberKP.Size = new System.Drawing.Size(153, 21);
            this.tb_NumberKP.TabIndex = 39;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(19, 103);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 13);
            this.label7.TabIndex = 40;
            this.label7.Text = "Номер КП";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 41;
            this.label1.Text = "Клиент";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(14, 64);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 13);
            this.label8.TabIndex = 42;
            this.label8.Text = "Поставщик";
            // 
            // EditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(457, 561);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tb_NumberKP);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.groupControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "EditForm";
            this.Text = "EditForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EditForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cb_Contragent.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cb_Provider.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.flyoutPanel1)).EndInit();
            this.flyoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.flyoutPanelControl1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dt_ControlDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dt_OrderDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb_AcceptNum;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cb_Status;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tb_PlaceCount;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private DevExpress.XtraEditors.SimpleButton btn_Save;
        private DevExpress.XtraEditors.LookUpEdit cb_Contragent;
        private DevExpress.XtraEditors.LookUpEdit cb_Provider;
        private DevExpress.XtraEditors.SimpleButton btn_AddAgent;
        private System.Windows.Forms.TextBox tb_NumberKP;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label8;
        public DevExpress.Utils.FlyoutPanel flyoutPanel1;
        public DevExpress.Utils.FlyoutPanelControl flyoutPanelControl1;
    }
}
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
            this.label1 = new System.Windows.Forms.Label();
            this.tb_Provider = new System.Windows.Forms.TextBox();
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
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.flyoutPanel1 = new DevExpress.Utils.FlyoutPanel();
            this.flyoutPanelControl1 = new DevExpress.Utils.FlyoutPanelControl();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.flyoutPanel1)).BeginInit();
            this.flyoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.flyoutPanelControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 63);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(102, 13);
            this.label6.TabIndex = 34;
            this.label6.Text = "Контрольная дата";
            // 
            // dt_ControlDate
            // 
            this.dt_ControlDate.Location = new System.Drawing.Point(12, 82);
            this.dt_ControlDate.Name = "dt_ControlDate";
            this.dt_ControlDate.Size = new System.Drawing.Size(153, 21);
            this.dt_ControlDate.TabIndex = 35;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 23;
            this.label1.Text = "Поставщик";
            // 
            // tb_Provider
            // 
            this.tb_Provider.Location = new System.Drawing.Point(12, 39);
            this.tb_Provider.Name = "tb_Provider";
            this.tb_Provider.Size = new System.Drawing.Size(153, 21);
            this.tb_Provider.TabIndex = 24;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(230, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 13);
            this.label2.TabIndex = 25;
            this.label2.Text = "Дата поставки";
            // 
            // dt_OrderDate
            // 
            this.dt_OrderDate.Location = new System.Drawing.Point(230, 79);
            this.dt_OrderDate.Name = "dt_OrderDate";
            this.dt_OrderDate.Size = new System.Drawing.Size(153, 21);
            this.dt_OrderDate.TabIndex = 26;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(123, 13);
            this.label3.TabIndex = 27;
            this.label3.Text = "Номер подтверждения";
            // 
            // tb_AcceptNum
            // 
            this.tb_AcceptNum.Location = new System.Drawing.Point(12, 122);
            this.tb_AcceptNum.Name = "tb_AcceptNum";
            this.tb_AcceptNum.Size = new System.Drawing.Size(153, 21);
            this.tb_AcceptNum.TabIndex = 28;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(230, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 29;
            this.label4.Text = "Статус";
            // 
            // cb_Status
            // 
            this.cb_Status.FormattingEnabled = true;
            this.cb_Status.Location = new System.Drawing.Point(230, 39);
            this.cb_Status.Name = "cb_Status";
            this.cb_Status.Size = new System.Drawing.Size(153, 21);
            this.cb_Status.TabIndex = 30;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(230, 106);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(121, 13);
            this.label5.TabIndex = 31;
            this.label5.Text = "Количество грузомест";
            // 
            // tb_PlaceCount
            // 
            this.tb_PlaceCount.Location = new System.Drawing.Point(230, 123);
            this.tb_PlaceCount.Name = "tb_PlaceCount";
            this.tb_PlaceCount.Size = new System.Drawing.Size(54, 21);
            this.tb_PlaceCount.TabIndex = 32;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.btn_Save);
            this.groupControl1.Controls.Add(this.label1);
            this.groupControl1.Controls.Add(this.label6);
            this.groupControl1.Controls.Add(this.tb_PlaceCount);
            this.groupControl1.Controls.Add(this.dt_ControlDate);
            this.groupControl1.Controls.Add(this.label5);
            this.groupControl1.Controls.Add(this.cb_Status);
            this.groupControl1.Controls.Add(this.tb_Provider);
            this.groupControl1.Controls.Add(this.label4);
            this.groupControl1.Controls.Add(this.label2);
            this.groupControl1.Controls.Add(this.tb_AcceptNum);
            this.groupControl1.Controls.Add(this.dt_OrderDate);
            this.groupControl1.Controls.Add(this.label3);
            this.groupControl1.Location = new System.Drawing.Point(2, 4);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(453, 191);
            this.groupControl1.TabIndex = 36;
            this.groupControl1.Text = "Параметры заказа";
            // 
            // btn_Save
            // 
            this.btn_Save.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.btn_Save.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_Save.ImageOptions.Image")));
            this.btn_Save.Location = new System.Drawing.Point(12, 149);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(431, 36);
            this.btn_Save.TabIndex = 39;
            this.btn_Save.Text = "Сохранить";
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.flowLayoutPanel1);
            this.groupControl2.Location = new System.Drawing.Point(2, 235);
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
            this.simpleButton1.Location = new System.Drawing.Point(7, 201);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(98, 23);
            this.simpleButton1.TabIndex = 38;
            this.simpleButton1.Text = "Добавить груз";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // EditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(457, 505);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.groupControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "EditForm";
            this.Text = "EditForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EditForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.flyoutPanel1)).EndInit();
            this.flyoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.flyoutPanelControl1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dt_ControlDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_Provider;
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
        public DevExpress.Utils.FlyoutPanel flyoutPanel1;
        public DevExpress.Utils.FlyoutPanelControl flyoutPanelControl1;
        private DevExpress.XtraEditors.SimpleButton btn_Save;
    }
}
namespace Offers.UI.MasterPage
{
    partial class Page1
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label2 = new System.Windows.Forms.Label();
            this.tb_name = new System.Windows.Forms.TextBox();
            this.cb_Contragent = new DevExpress.XtraEditors.LookUpEdit();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.cb_Contragent.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(171, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Введите название предложения";
            // 
            // tb_name
            // 
            this.tb_name.Location = new System.Drawing.Point(3, 25);
            this.tb_name.Name = "tb_name";
            this.tb_name.Size = new System.Drawing.Size(335, 20);
            this.tb_name.TabIndex = 3;
            // 
            // cb_Contragent
            // 
            this.cb_Contragent.Location = new System.Drawing.Point(3, 80);
            this.cb_Contragent.Name = "cb_Contragent";
            // 
            // 
            // 
            this.cb_Contragent.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cb_Contragent.Size = new System.Drawing.Size(335, 20);
            this.cb_Contragent.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(123, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Выберите контрагента";
            // 
            // Page1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tb_name);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cb_Contragent);
            this.Name = "Page1";
            this.Size = new System.Drawing.Size(353, 262);
            ((System.ComponentModel.ISupportInitialize)(this.cb_Contragent.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_name;
        private DevExpress.XtraEditors.LookUpEdit cb_Contragent;
        private System.Windows.Forms.Label label3;
    }
}

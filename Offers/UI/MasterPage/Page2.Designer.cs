namespace Offers.UI.MasterPage
{
    partial class Page2
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
            this.cb_manufacter = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_subject_rus = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_subject = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tb_num = new System.Windows.Forms.TextBox();
            this.tb_text_rus = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tb_text = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cb_manufacter
            // 
            this.cb_manufacter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_manufacter.FormattingEnabled = true;
            this.cb_manufacter.Location = new System.Drawing.Point(3, 20);
            this.cb_manufacter.Name = "cb_manufacter";
            this.cb_manufacter.Size = new System.Drawing.Size(399, 21);
            this.cb_manufacter.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "От кого:";
            // 
            // tb_subject_rus
            // 
            this.tb_subject_rus.Location = new System.Drawing.Point(3, 66);
            this.tb_subject_rus.Name = "tb_subject_rus";
            this.tb_subject_rus.Size = new System.Drawing.Size(399, 20);
            this.tb_subject_rus.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Тема:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Тема (eng):";
            // 
            // tb_subject
            // 
            this.tb_subject.Location = new System.Drawing.Point(3, 109);
            this.tb_subject.Name = "tb_subject";
            this.tb_subject.Size = new System.Drawing.Size(399, 20);
            this.tb_subject.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 132);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Номер предложения";
            // 
            // tb_num
            // 
            this.tb_num.Location = new System.Drawing.Point(3, 148);
            this.tb_num.Name = "tb_num";
            this.tb_num.Size = new System.Drawing.Size(148, 20);
            this.tb_num.TabIndex = 7;
            // 
            // tb_text_rus
            // 
            this.tb_text_rus.Location = new System.Drawing.Point(3, 191);
            this.tb_text_rus.Multiline = true;
            this.tb_text_rus.Name = "tb_text_rus";
            this.tb_text_rus.Size = new System.Drawing.Size(270, 137);
            this.tb_text_rus.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 175);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Текст:";
            // 
            // tb_text
            // 
            this.tb_text.Location = new System.Drawing.Point(304, 191);
            this.tb_text.Multiline = true;
            this.tb_text.Name = "tb_text";
            this.tb_text.Size = new System.Drawing.Size(270, 137);
            this.tb_text.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(305, 175);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Текст (eng):";
            // 
            // Page2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tb_text);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tb_text_rus);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tb_num);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tb_subject);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tb_subject_rus);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cb_manufacter);
            this.Name = "Page2";
            this.Size = new System.Drawing.Size(610, 331);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cb_manufacter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_subject_rus;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb_subject;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tb_num;
        private System.Windows.Forms.TextBox tb_text_rus;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tb_text;
        private System.Windows.Forms.Label label6;
    }
}

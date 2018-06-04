namespace Offers.UI
{
    partial class EquipmentEdit
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
            this.tb_code = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tb_desc_rus = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tb_name_rus = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tb_desc_eng = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tb_name_eng = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cb_manufacters = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tb_price = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label8 = new System.Windows.Forms.Label();
            this.tb_img = new System.Windows.Forms.TextBox();
            this.btn_img = new System.Windows.Forms.Button();
            this.btn_save = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tb_code
            // 
            this.tb_code.Location = new System.Drawing.Point(313, 26);
            this.tb_code.Name = "tb_code";
            this.tb_code.Size = new System.Drawing.Size(140, 21);
            this.tb_code.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Наименование";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tb_desc_rus);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.tb_name_rus);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 58);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(292, 258);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Описание на русском языке";
            // 
            // tb_desc_rus
            // 
            this.tb_desc_rus.Location = new System.Drawing.Point(9, 71);
            this.tb_desc_rus.Multiline = true;
            this.tb_desc_rus.Name = "tb_desc_rus";
            this.tb_desc_rus.Size = new System.Drawing.Size(277, 178);
            this.tb_desc_rus.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Описание";
            // 
            // tb_name_rus
            // 
            this.tb_name_rus.Location = new System.Drawing.Point(9, 32);
            this.tb_name_rus.Name = "tb_name_rus";
            this.tb_name_rus.Size = new System.Drawing.Size(277, 21);
            this.tb_name_rus.TabIndex = 2;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tb_desc_eng);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.tb_name_eng);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Location = new System.Drawing.Point(313, 58);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(292, 258);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Описание на английском языке";
            // 
            // tb_desc_eng
            // 
            this.tb_desc_eng.Location = new System.Drawing.Point(9, 71);
            this.tb_desc_eng.Multiline = true;
            this.tb_desc_eng.Name = "tb_desc_eng";
            this.tb_desc_eng.Size = new System.Drawing.Size(277, 178);
            this.tb_desc_eng.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 55);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Описание";
            // 
            // tb_name_eng
            // 
            this.tb_name_eng.Location = new System.Drawing.Point(9, 32);
            this.tb_name_eng.Name = "tb_name_eng";
            this.tb_name_eng.Size = new System.Drawing.Size(277, 21);
            this.tb_name_eng.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Наименование";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Производитель";
            // 
            // cb_manufacters
            // 
            this.cb_manufacters.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_manufacters.FormattingEnabled = true;
            this.cb_manufacters.Location = new System.Drawing.Point(15, 26);
            this.cb_manufacters.Name = "cb_manufacters";
            this.cb_manufacters.Size = new System.Drawing.Size(289, 21);
            this.cb_manufacters.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(310, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Код ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(459, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(93, 13);
            this.label7.TabIndex = 8;
            this.label7.Text = "Цена за еденицу";
            // 
            // tb_price
            // 
            this.tb_price.Location = new System.Drawing.Point(462, 26);
            this.tb_price.Name = "tb_price";
            this.tb_price.Size = new System.Drawing.Size(140, 21);
            this.tb_price.TabIndex = 7;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(18, 325);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(117, 13);
            this.label8.TabIndex = 10;
            this.label8.Text = "Файл с изображением";
            // 
            // tb_img
            // 
            this.tb_img.Location = new System.Drawing.Point(21, 341);
            this.tb_img.Name = "tb_img";
            this.tb_img.Size = new System.Drawing.Size(360, 21);
            this.tb_img.TabIndex = 9;
            // 
            // btn_img
            // 
            this.btn_img.Location = new System.Drawing.Point(396, 340);
            this.btn_img.Name = "btn_img";
            this.btn_img.Size = new System.Drawing.Size(75, 20);
            this.btn_img.TabIndex = 11;
            this.btn_img.Text = "Выбрать";
            this.btn_img.UseVisualStyleBackColor = true;
            this.btn_img.Click += new System.EventHandler(this.btn_img_Click);
            // 
            // btn_save
            // 
            this.btn_save.Location = new System.Drawing.Point(12, 369);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(593, 36);
            this.btn_save.TabIndex = 12;
            this.btn_save.Text = "Сохранить";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // EquipmentEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(617, 408);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.btn_img);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.tb_img);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tb_price);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cb_manufacters);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tb_code);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "EquipmentEdit";
            this.Text = "EquipmentEdit";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tb_code;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tb_desc_rus;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tb_name_rus;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox tb_desc_eng;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tb_name_eng;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cb_manufacters;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tb_price;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tb_img;
        private System.Windows.Forms.Button btn_img;
        private System.Windows.Forms.Button btn_save;
    }
}
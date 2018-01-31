namespace MyOrders
{
    partial class RatesControl
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
            this.RateName = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.lb_scale = new System.Windows.Forms.Label();
            this.RateName.SuspendLayout();
            this.SuspendLayout();
            // 
            // RateName
            // 
            this.RateName.Controls.Add(this.lb_scale);
            this.RateName.Controls.Add(this.button1);
            this.RateName.Controls.Add(this.textBox1);
            this.RateName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RateName.Location = new System.Drawing.Point(0, 0);
            this.RateName.Name = "RateName";
            this.RateName.Size = new System.Drawing.Size(183, 60);
            this.RateName.TabIndex = 1;
            this.RateName.TabStop = false;
            this.RateName.Text = "USD/RUB";
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(8, 17);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(123, 20);
            this.textBox1.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(152, 16);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(25, 20);
            this.button1.TabIndex = 2;
            this.button1.Text = "-";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lb_scale
            // 
            this.lb_scale.AutoSize = true;
            this.lb_scale.Location = new System.Drawing.Point(10, 40);
            this.lb_scale.Name = "lb_scale";
            this.lb_scale.Size = new System.Drawing.Size(55, 13);
            this.lb_scale.TabIndex = 3;
            this.lb_scale.Text = "Колич-во:";
            // 
            // RatesControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.RateName);
            this.Name = "RatesControl";
            this.Size = new System.Drawing.Size(183, 60);
            this.RateName.ResumeLayout(false);
            this.RateName.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox RateName;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label lb_scale;
    }
}

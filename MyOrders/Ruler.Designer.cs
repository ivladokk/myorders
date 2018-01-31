namespace MyOrders
{
    partial class Ruler
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.rulerX = new System.Windows.Forms.Panel();
            this.rulerY = new System.Windows.Forms.Panel();
            this.imgContainer = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.imgContainer)).BeginInit();
            this.SuspendLayout();
            // 
            // rulerX
            // 
            this.rulerX.Location = new System.Drawing.Point(82, 13);
            this.rulerX.Name = "rulerX";
            this.rulerX.Size = new System.Drawing.Size(310, 40);
            this.rulerX.TabIndex = 0;
            this.rulerX.Paint += new System.Windows.Forms.PaintEventHandler(this.rulerX_Paint);
            // 
            // rulerY
            // 
            this.rulerY.Location = new System.Drawing.Point(43, 53);
            this.rulerY.Name = "rulerY";
            this.rulerY.Size = new System.Drawing.Size(40, 310);
            this.rulerY.TabIndex = 1;
            this.rulerY.Paint += new System.Windows.Forms.PaintEventHandler(this.rulerY_Paint);
            // 
            // imgContainer
            // 
            this.imgContainer.Location = new System.Drawing.Point(82, 53);
            this.imgContainer.Name = "imgContainer";
            this.imgContainer.Size = new System.Drawing.Size(300, 300);
            this.imgContainer.TabIndex = 2;
            this.imgContainer.TabStop = false;
            this.imgContainer.Paint += new System.Windows.Forms.PaintEventHandler(this.imgContainer_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(351, -1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Длина";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(-2, 338);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Ширина";
            this.label2.Paint += new System.Windows.Forms.PaintEventHandler(this.label2_Paint);
            // 
            // Ruler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.imgContainer);
            this.Controls.Add(this.rulerY);
            this.Controls.Add(this.rulerX);
            this.Name = "Ruler";
            this.Size = new System.Drawing.Size(410, 365);
            ((System.ComponentModel.ISupportInitialize)(this.imgContainer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel rulerX;
        private System.Windows.Forms.Panel rulerY;
        private System.Windows.Forms.PictureBox imgContainer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

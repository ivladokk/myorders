namespace MyOrders
{
    partial class GoodItem
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
            this.lb_place = new System.Windows.Forms.Label();
            this.lb_Size = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.lb_Weight = new System.Windows.Forms.Label();
            this.lb_Comments = new System.Windows.Forms.Label();
            this.ruler1 = new MyOrders.Ruler();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lb_place
            // 
            this.lb_place.AutoSize = true;
            this.lb_place.Location = new System.Drawing.Point(3, 0);
            this.lb_place.Name = "lb_place";
            this.lb_place.Size = new System.Drawing.Size(102, 13);
            this.lb_place.TabIndex = 0;
            this.lb_place.Text = "Грузовое место №";
            // 
            // lb_Size
            // 
            this.lb_Size.AutoSize = true;
            this.lb_Size.Location = new System.Drawing.Point(3, 13);
            this.lb_Size.Name = "lb_Size";
            this.lb_Size.Size = new System.Drawing.Size(54, 13);
            this.lb_Size.TabIndex = 1;
            this.lb_Size.Text = "Размеры:";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.Controls.Add(this.lb_place);
            this.flowLayoutPanel1.Controls.Add(this.lb_Size);
            this.flowLayoutPanel1.Controls.Add(this.lb_Weight);
            this.flowLayoutPanel1.Controls.Add(this.lb_Comments);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 2);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(399, 82);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // lb_Weight
            // 
            this.lb_Weight.AutoSize = true;
            this.lb_Weight.Location = new System.Drawing.Point(3, 26);
            this.lb_Weight.Name = "lb_Weight";
            this.lb_Weight.Size = new System.Drawing.Size(28, 13);
            this.lb_Weight.TabIndex = 2;
            this.lb_Weight.Text = "Вес:";
            // 
            // lb_Comments
            // 
            this.lb_Comments.AutoSize = true;
            this.lb_Comments.Location = new System.Drawing.Point(3, 39);
            this.lb_Comments.Name = "lb_Comments";
            this.lb_Comments.Size = new System.Drawing.Size(68, 13);
            this.lb_Comments.TabIndex = 3;
            this.lb_Comments.Text = "Примечания";
            // 
            // ruler1
            // 
            this.ruler1.Location = new System.Drawing.Point(0, 86);
            this.ruler1.MyImg = null;
            this.ruler1.Name = "ruler1";
            this.ruler1.Size = new System.Drawing.Size(402, 373);
            this.ruler1.TabIndex = 3;
            // 
            // GoodItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ruler1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "GoodItem";
            this.Size = new System.Drawing.Size(405, 462);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lb_place;
        private System.Windows.Forms.Label lb_Size;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label lb_Weight;
        private System.Windows.Forms.Label lb_Comments;
        private Ruler ruler1;
    }
}

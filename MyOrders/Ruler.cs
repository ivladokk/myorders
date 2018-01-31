using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyOrders
{
    public partial class Ruler : UserControl
    {
        public Pen pen;
        public bool DrawGrid;
        
        public Image MyImg
        {
            get
            {
                return imgContainer.Image;
            }
            set
            {
                imgContainer.Image = value;
            }
        }

        public Ruler()
        {
            InitializeComponent();
            pen = new Pen(System.Drawing.Color.Black, 0.1f);
            DrawGrid = true;
            
        }

        private void rulerX_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.PageUnit = GraphicsUnit.Pixel;
            int step = 10;
            int length = rulerX.Width;   
            int small = 10;
            int big = 50;
            int number = 1;         
            float stroke = 2.5f;

            for (int i = 0; i < length; i += step)
            {
                float d = 1;
                if (i % small == 0) 
                {
                    if (i % big == 0)
                    {
                        d = 4; 
                    }
                    else
                    {
                        d = 2;
                    }
                }
                g.DrawLine(this.pen, i, 40, i, 40 - (d * stroke));
                if ((i % number) == 0)//0,1,,2
                {
                    string text = (i / number).ToString();
                    SizeF size = g.MeasureString(text, this.Font, length, StringFormat.GenericDefault);
                    g.DrawString((i % 50 == 0) && (i != 0) ? text : "", this.Font, Brushes.Black, i - size.Width / 2, d * stroke, StringFormat.GenericDefault);

                }
            }
        }

        private void rulerY_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.PageUnit = GraphicsUnit.Pixel;
            int step = 10;
            int length = rulerY.Height;    
            int small = 10;
            int big = 50;
            int number = 1;          
            float stroke = 2.5f;

            for (int i = 0; i < length; i += step)
            {
                float d = 1;
                if (i % small == 0) 
                {
                    if (i % big == 0)
                    {
                        d = 4;
                    }
                    else
                    {
                        d = 2;
                    }
                }
                g.DrawLine(this.pen, 40, i, 40 - (d * stroke), i);
                if ((i % number) == 0)
                {
                    string text = (i / number).ToString();
                    SizeF size = g.MeasureString(text, this.Font, length, StringFormat.GenericDefault);
                    g.DrawString((i % 50 == 0) && (i != 0) ? text : "", this.Font, Brushes.Black, d * stroke, i - size.Height / 2, StringFormat.GenericDefault);
                }
            }
        }

        private void imgContainer_Paint(object sender, PaintEventArgs e)
        {
            if (DrawGrid)
            {
                Graphics g = e.Graphics;
                g.PageUnit = GraphicsUnit.Pixel;

                Pen gridPen = new Pen(System.Drawing.Color.LightGray, 0.01f);


                int step = 10;
                int length = imgContainer.Height;

                for (int i = 0; i < imgContainer.Height; i += step)
                {
                    g.DrawLine(gridPen, 0, i, imgContainer.Height, i);

                }
                for (int i = 0; i < imgContainer.Width; i += step)
                {
                    g.DrawLine(gridPen, i, 0, i, imgContainer.Width);

                }

            }

        }

        private void label2_Paint(object sender, PaintEventArgs e)
        {
            
        }
    }
}

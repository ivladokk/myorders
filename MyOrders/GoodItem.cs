using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using AppCore.Models;
using AppCore.Settings;
using DevExpress.XtraEditors;


namespace MyOrders
{
    public partial class GoodItem : DevExpress.XtraEditors.XtraUserControl
    {
        
        public GoodItem(Good goodItem,int PlaceNum)
        {
            InitializeComponent();
            
            lb_place.Text = string.Format("Грузовое место № {0}", PlaceNum);
            lb_Size.Text = string.Format("Размер(ш/в/д): {0}/{1}/{2}", goodItem.Width, goodItem.Height, goodItem.Lenght);
            lb_Weight.Text = string.Format("Вес(кг): {0}", goodItem.Weight);
            lb_Comments.Text = goodItem.Comments == "" ? "Примечания: Нет" : string.Format("Примечания: {0}", goodItem.Comments);

            /*pictureBox1.Width = Settings.ConvertSizeToPx(Settings.maxLenght);
            pictureBox1.Height = Settings.ConvertSizeToPx(Settings.maxWidth);

            pictureBox1.Image = GetBitmap(Settings.ConvertSizeToPx(goodItem.Lenght), Settings.ConvertSizeToPx(goodItem.Width));*/
            ruler1.MyImg = GetBitmap(Settings.ConvertSizeToPx(goodItem.Lenght), Settings.ConvertSizeToPx(goodItem.Width));


        }

        

        private Bitmap GetBitmap(int width, int height)
        {
            Bitmap Bmp = new Bitmap(width, height);
            using (Graphics gfx = Graphics.FromImage(Bmp))
            using (SolidBrush brush = new SolidBrush(Color.Khaki))
            {
                gfx.FillRectangle(brush, 0, 0, width, height);

            }
            return Bmp;
        }




    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using AppCore;
using AppCore.Models;
using AppCore.Settings;
using DevExpress.XtraEditors;

namespace MyOrders
{
    public partial class GoodEdit : DevExpress.XtraEditors.XtraUserControl
    {

        public Good Item;
        object Owner;
        int OrderID;
        int Type;
        public GoodEdit(Good item,int type, object owner,int orderId)
        {
            InitializeComponent();
            Item = item;
            Owner = owner;
            OrderID = orderId;
            this.Type = type;

            tb_Height.KeyPress += OnlyDigits;
            tb_Lenght.KeyPress += OnlyDigits;
            tb_Weight.KeyPress += OnlyDigits;
            tb_Width.KeyPress += OnlyDigits;
            if (Type==2)
            {
                InitGoodEdit();

            }


        }


        public bool isValid()
        {
            if (tb_Width.Text == "" || tb_Height.Text == "" || tb_Lenght.Text == "" || tb_Weight.Text == "")
            {
                MessageBox.Show("Заполните все поля!");
                return false;
            }

            else return true;
        }

        private void OnlyDigits(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != Convert.ToChar(8))
            {
                e.Handled = true;
            }
        }
        private void InitGoodEdit()
        {
            tb_Width.Text = Item.Width.ToString();
            tb_Height.Text = Item.Height.ToString();
            tb_Lenght.Text = Item.Lenght.ToString();
            tb_Weight.Text = Item.Weight.ToString();
            tb_Comments.Text = Item.Comments.ToString();

        }
        private bool AddGood(int orderID)
        {
            Good newgood = new Good()
            {
                OrderID = orderID,
                Width = Convert.ToInt32(tb_Width.Text),
                Height = Convert.ToInt32(tb_Height.Text),
                Lenght = Convert.ToInt32(tb_Lenght.Text),
                Weight = Convert.ToInt32(tb_Weight.Text),
                Comments = tb_Comments.Text
            };
            if (!CheckSize(newgood))
            {
                MessageBox.Show("Некорректные размеры!");
                return false;
            }
            using (UserContext db = new UserContext(Settings.constr))
            {
                
                db.Goods.Add(newgood);
                db.SaveChanges();
            }
            return true;
        }

        private bool EditGood(Good good)
        {
            good.Width = Convert.ToInt32(tb_Width.Text);
            good.Height = Convert.ToInt32(tb_Height.Text);
            good.Lenght = Convert.ToInt32(tb_Lenght.Text);
            good.Weight = Convert.ToInt32(tb_Weight.Text);
            good.Comments = tb_Comments.Text;
            if (!CheckSize(good))
            {
                MessageBox.Show("Некорректные размеры!");
                return false;
            }

            using (UserContext db = new UserContext(Settings.constr))
            {
                db.Goods.Attach(good);
                var entry = db.Entry(good);
                entry.Property(x => x.Width).IsModified = true;
                entry.Property(x => x.Height).IsModified = true;
                entry.Property(x => x.Lenght).IsModified = true;
                entry.Property(x => x.Weight).IsModified = true;
                entry.Property(x => x.Comments).IsModified = true;
                db.SaveChanges();

            }
            return true;
        }


        public bool CheckSize(Good good)
        {
            if (good.Width > Settings.maxWidth || good.Height > Settings.maxHeight || good.Lenght > Settings.maxLenght)
                return false;
            else return true;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (this.Type==1)
            {
                if (isValid())
                {

                    if (AddGood(OrderID))
                    {
                        MessageBox.Show("Добавлено!");
                        (Owner as EditForm).flyoutPanel1.HidePopup();
                        (Owner as EditForm).InitEditForm();
                        (Owner as EditForm).Focus();
                    }
                    
                }
                else return;
               // (Owner as DevExpress.Utils.FlyoutPanel).HidePopup();

            }
            if (this.Type==2)
            {
                if (isValid())
                {
                    if(EditGood(Item))
                    {
                        MessageBox.Show("Изменено!");
                        (Owner as EditForm).flyoutPanel1.HidePopup();
                        (Owner as EditForm).InitEditForm();
                        (Owner as EditForm).Focus();
                        // (Owner as DevExpress.Utils.FlyoutPanel).HidePopup();
                    }

                }
                else return;

            }
            
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            (Owner as EditForm).flyoutPanel1.HidePopup();
        }
    }
}

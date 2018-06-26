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
    public partial class MyGood : DevExpress.XtraEditors.XtraUserControl
    {
        public Good Item;
        public object Sender;
        public MyGood(object sender, Good item)
        {
            InitializeComponent();
            this.Sender = sender;
            this.Item = item;
            lb_Num.Text = string.Format("Номер: {0}", Item.ID);
            lb_Size.Text = string.Format("Размер: {0}/{1}/{2}", Item.Width, Item.Height, Item.Lenght);
            lb_Weight.Text = string.Format("Вес:{0}", Item.Weight);


        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            GoodItem ge = new GoodItem(Item,Item.ID);
            ge.Show();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            (Sender as EditForm).flyoutPanelControl1.Controls.Clear();
            (Sender as EditForm).flyoutPanelControl1.Controls.Add(new GoodEdit(Item, 2, Sender, Item.OrderID));
            (Sender as EditForm).flyoutPanel1.ShowPopup();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using (UserContext db = new UserContext(Settings.constr))
            {
                db.Goods.Attach(Item);
                db.Goods.Remove(Item);
                db.SaveChanges();
            }
            (Sender as EditForm).InitEditForm();
        }
    }
}

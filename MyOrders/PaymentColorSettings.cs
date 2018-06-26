using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AppCore;
using AppCore.Models;
using AppCore.Settings;

namespace MyOrders
{
    public partial class PaymentColorSettings : XtraForm
    {

        List<PaymentColor> AllColors;
        int Type = 0;
        private PaymentColor editItem;

        

        public PaymentColorSettings()
        {
            InitializeComponent();

            Init();

        }

        public void Init()
        {
            foreach (Control i in groupControl1.Controls)
                i.Enabled = false;

            using (UserContext db = new UserContext(Settings.constr))
            {
                AllColors = db.PaymentColors.ToList();
            }

            if (AllColors.Count > 0)
            {
                BindingList<PaymentColor> ColorsDS = new BindingList<PaymentColor>();
                foreach (var i in AllColors)
                    ColorsDS.Add(i);

                cb_Colors.DisplayMember = "ColorRus";
                cb_Colors.ValueMember = "ID";
                cb_Colors.DataSource = ColorsDS;
            }

        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            Type = 1;
            foreach (Control i in groupControl1.Controls)
                i.Enabled = true;
        }

        private void btn_Edit_Click(object sender, EventArgs e)
        {
            Type = 2;
            foreach (Control i in groupControl1.Controls)
                i.Enabled = true;
            PaymentColor item;
            int curColor = Int32.Parse(cb_Colors.SelectedValue.ToString());
            using (UserContext db = new UserContext(Settings.constr))
            {
                item = db.PaymentColors.Where(x => x.ID == curColor).FirstOrDefault();
            }
            tb_ColorName.Text = item.ColorRus;
            ce_ColorValue.Color = Color.FromArgb(Convert.ToInt32(item.Color));
            tb_Value.Text = item.Value;

        }
        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (Type == 1)
            {

                

                PaymentColor item = new PaymentColor()
                {
                    Color = ce_ColorValue.Color.ToArgb().ToString(),
                    ColorRus = tb_ColorName.Text,
                    Value = tb_Value.Text
                };
                using (UserContext db = new UserContext(Settings.constr))
                {



                    db.PaymentColors.Add(item);
                    db.SaveChanges();
                }
                Type = 2;
                editItem = item;
                Init();
                return;
            }

            if (Type==2)
            {
                /*PaymentColor item = new PaymentColor()
                {
                    Color = ce_ColorValue.Color.Name,
                    ColorRus = tb_ColorName.Text,
                    Value = tb_Value.Text
                };*/
                using (UserContext db = new UserContext(Settings.constr))
                {
                    int curColor = Int32.Parse(cb_Colors.SelectedValue.ToString());

                    editItem = db.PaymentColors.FirstOrDefault(x => x.ID == curColor);
                    editItem.Color = ce_ColorValue.Color.ToArgb().ToString();
                    editItem.ColorRus = tb_ColorName.Text;
                    editItem.Value = tb_Value.Text;
                    db.PaymentColors.Attach(editItem);
                    var entry = db.Entry(editItem);
                    entry.Property(x => x.Value).IsModified = true;
                    entry.Property(x => x.Color).IsModified = true;
                    entry.Property(x => x.ColorRus).IsModified = true;
                    db.SaveChanges();
                }
                Init();
            }
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            int curColor = Int32.Parse(cb_Colors.SelectedValue.ToString());
            using (UserContext db = new UserContext(Settings.constr))
            {
               var item = db.PaymentColors.Where(x => x.ID == curColor).FirstOrDefault();
                db.PaymentColors.Remove(item);
                db.SaveChanges();
            }
            MessageBox.Show("Удалено!");
            Init();
        }
    }
}

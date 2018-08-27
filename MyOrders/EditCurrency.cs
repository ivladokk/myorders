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
    public partial class EditCurrency : Form
    {
        List<CurrencyCode> Currencies;
        int Type = 0;
        public EditCurrency()
        {
            InitializeComponent();
            Init();
        }
        public void Init()
        {
            foreach (Control i in groupBox1.Controls)
            {
                i.Enabled = false;
            }

            using (UserContext db = new UserContext(Settings.constr))
            {
                Currencies = db.CurrencyCodes.ToList();
            }

            if (Currencies.Count > 0)
            {
                BindingList<CurrencyCode> CurDS = new BindingList<CurrencyCode>();
                foreach (var i in Currencies)
                    CurDS.Add(i);

                cb_currency.DisplayMember = "CurrencyName";
                cb_currency.ValueMember = "CurrencyID";
                cb_currency.DataSource = CurDS;
            }
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            Type = 1;
            foreach (Control i in groupBox1.Controls)
                i.Enabled = true;
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            Type = 2;
            foreach (Control i in groupBox1.Controls)
                i.Enabled = true;
            CurrencyCode item;
            int cur = Int32.Parse(cb_currency.SelectedValue.ToString());
            using (UserContext db = new UserContext(Settings.constr))
            {
                item = db.CurrencyCodes.Where(x => x.CurrencyID == cur).FirstOrDefault();
            }
            tb_Code.Text = item.Code.ToString();
            tb_curname.Text = item.CurrencyName;
            tb_curname_eng.Text = item.CurrencyNameEng;
        }

        private void btn_del_Click(object sender, EventArgs e)
        {
            int cur = Int32.Parse(cb_currency.SelectedValue.ToString());
            using (UserContext db = new UserContext(Settings.constr))
            {
                var item = db.CurrencyCodes.Where(x => x.CurrencyID == cur).FirstOrDefault();
                db.CurrencyCodes.Remove(item);
                db.SaveChanges();
            }
            MessageBox.Show("Удалено!");
            Init();
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            try
            {
                if (Type == 1)
                {
                    CurrencyCode item = new CurrencyCode()
                    {
                        Code = Convert.ToInt32(tb_Code.Text),
                        CurrencyName = tb_curname.Text,
                        CurrencyNameEng = tb_curname_eng.Text
                    };
                    using (UserContext db = new UserContext(Settings.constr))
                    {
                        db.CurrencyCodes.Add(item);
                        db.SaveChanges();
                    }
                    Type = 2;
                    Init();
                    return;
                }

                if (Type == 2)
                {
                    CurrencyCode item = new CurrencyCode()
                    {
                        Code = Convert.ToInt32(tb_Code.Text),
                        CurrencyName = tb_curname.Text,
                        CurrencyNameEng = tb_curname_eng.Text
                    };
                    using (UserContext db = new UserContext(Settings.constr))
                    {
                        db.CurrencyCodes.Attach(item);
                        var entry = db.Entry(item);
                        entry.Property(x => x.CurrencyID).IsModified = true;
                        entry.Property(x => x.CurrencyName).IsModified = true;
                        entry.Property(x => x.CurrencyNameEng).IsModified = true;
                        db.SaveChanges();
                    }
                    Init();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
    }
}

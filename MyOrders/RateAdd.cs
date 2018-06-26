using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using AppCore;
using AppCore.Models;
using AppCore.Settings;

namespace MyOrders
{
    public partial class RateAdd : XtraForm
    {
        private WorkDay workDay;
        private object Sender;
        public RateAdd(WorkDay workday,object sender)
        {
            workDay = workday;
            Sender = sender;

            InitializeComponent();

            BindingList<CurrencyCode> Currencies = new BindingList<CurrencyCode>();

            using (UserContext db = new UserContext(Settings.constr))
            {
                foreach (var i in db.CurrencyCodes.ToList())
                {
                    Currencies.Add(i);
                }
            }

            cb_from.DisplayMember = "CurrencyName";
            cb_from.ValueMember = "CurrencyID";
            cb_from.DataSource = Currencies;

            BindingList<CurrencyCode> Currencies2 = new BindingList<CurrencyCode>();

            using (UserContext db = new UserContext(Settings.constr))
            {
                foreach (var i in db.CurrencyCodes.ToList())
                {
                    Currencies2.Add(i);
                }
            }
            cb_to.DisplayMember = "CurrencyName";
            cb_to.ValueMember = "CurrencyID";
            cb_to.DataSource = Currencies2;

        }
        public bool isValid()
        {
            if (tb_value.Text == "0.00")
            {
                MessageBox.Show("Введите сумму!");
                return false;
            }
            if (!Regex.IsMatch(tb_value.Text, @"^[0-9]*\.[0-9]{4}$"))
            {
                MessageBox.Show("Не корректно введена сумма!");
                return false;
            }
            return true;
        }
        private void btn_save_Click(object sender, EventArgs e)
        {
            if (isValid())
            {
                try
                {
                    Rate rate = new Rate()
                    {
                        FromCurID = Convert.ToInt32(cb_from.SelectedValue),
                        ToCurID = Convert.ToInt32(cb_to.SelectedValue),
                        WorkDayID = workDay.WorkDayID,
                        RateValue = Convert.ToDouble(tb_value.Text.Replace('.', ',')),
                        Scale = Convert.ToInt32(tb_scale.Text),
                        RateDate = workDay.WorkDayDate
                    };
                    using (var db = new UserContext(Settings.constr))
                    {
                        db.Rates.Add(rate);
                        db.SaveChanges();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    (Sender as RatesForm).Init();
                    this.Close();
                }
            }
            
            
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tb_value_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar)) && !((e.KeyChar == '.') && (tb_value.Text.IndexOf(".") == -1) && (tb_value.Text.Length != 0)))
            {
                if (e.KeyChar != (char)Keys.Back)
                {
                    e.Handled = true;

                }

            }
        }

        private void tb_scale_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar)) && !((e.KeyChar == '.') && (tb_value.Text.IndexOf(".") == -1) && (tb_value.Text.Length != 0)))
            {
                if (e.KeyChar != (char)Keys.Back)
                {
                    e.Handled = true;

                }

            }
        }
    }
}

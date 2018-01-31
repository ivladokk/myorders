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

namespace MyOrders
{
    public partial class BalanceForm : XtraForm
    {
        Dictionary<string, Control> BalanceControls = new Dictionary<string, Control>();

        private int Type;
        WorkDay workDay;
        object Sender;
        public BalanceForm(int type, int workdayID, object sender)
        {
            InitializeComponent();
            Type = type;
            Sender = sender;
            //workDay = workday;
            using (UserContext db = new UserContext(Settings.constr))
            {
                workDay = db.WorkDays.Where(s => s.WorkDayID == workdayID).ToList().FirstOrDefault();


                foreach (var i in db.CurrencyCodes)
                {
                    var label = new Label();
                    label.Name = $"lb_{i.Code}";
                    label.Text = i.CurrencyName;
                    flowLayoutPanel1.Controls.Add(label);
                    var tb = new TextBox();
                    tb.Name = $"tb_{i.Code}";
                    tb.Text = "0.00";
                    tb.KeyPress += tb_Sum_KeyPress;
                    tb.Tag = i.CurrencyID;
                    flowLayoutPanel1.Controls.Add(tb);
                    BalanceControls.Add(i.CurrencyName, tb);
                }
            }

            if (Type == 2)
                InitEdit();

        }
        public void InitEdit()
        {
            Dictionary<string, decimal> OldValues = new Dictionary<string, decimal>();
            using (UserContext db = new UserContext(Settings.constr))
            {
                var list = db.BalanceOnDays.Where(x => x.WorkDayID == workDay.WorkDayID).ToList();
                foreach (BalanceOnDay i in list)
                {
                    var curName = db.CurrencyCodes.Where(x => x.CurrencyID == i.CurrencyID).FirstOrDefault().CurrencyName;
                    OldValues.Add(curName, i.StartAmount);
                }
            }


            foreach (var i in BalanceControls)
            {
                (i.Value as Control).Text = "";
                (i.Value as Control).Text = OldValues[i.Key].ToString().Replace(',', '.');
            }
        }

        private void tb_Sum_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar)) && !((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf(".") == -1) && ((sender as TextBox).Text.Length != 0)))
            {
                if (e.KeyChar != (char)Keys.Back)
                {
                    e.Handled = true;

                }

            }

        }

        public bool isValid()
        {
            if (Type==1)
            {
                using (UserContext db = new UserContext(Settings.constr))
                {
                    //var lst = db.WorkDays.Where(x => x.WorkDayDate.Date.ToString("dd.MM.yyyy") == de_Date.Value.Date.ToString("dd.MM.yyyy")).ToList();
                    foreach (var i in db.WorkDays.ToList())
                    {
                        if (i.WorkDayDate.ToString("dd.MM.yyyy") == de_Date.Value.ToString("dd.MM.yyyy"))
                        {
                            MessageBox.Show("Для выбранной даты уже существуют данные!");
                            return false;
                        }
                    }

                    /*if (lst.Count>1)
                    {
                        MessageBox.Show("Для выбранной даты уже существуют данные!");
                        return false;
                    }*/
                }
            }
            
            foreach (var i in BalanceControls)
            {
                if (!Regex.IsMatch((i.Value as Control).Text, @"^[0-9]*\.[0-9]{2}$"))
                {
                    MessageBox.Show("Не корректно введена сумма!");
                    return false;
                }
            }
            return true;

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (Type == 1 && isValid())
            {
                using (UserContext db = new UserContext(Settings.constr))
                {
                    WorkDay newDay = new WorkDay()
                    {
                        WorkDayDate = de_Date.Value
                    };

                    db.WorkDays.Add(newDay);
                    db.SaveChanges();

                    foreach (var i in BalanceControls)
                    { 
                        BalanceOnDay item = new BalanceOnDay()
                        {
                            CurrencyID = Convert.ToInt32((i.Value as Control).Tag),
                            WorkDayID = newDay.WorkDayID,
                            StartAmount = Convert.ToDecimal((i.Value as Control).Text.Replace(".", ",")),
                            CurrentAmount = Convert.ToDecimal((i.Value as Control).Text.Replace(".", ","))
                        };
                        db.BalanceOnDays.Add(item);
                        db.SaveChanges();
                    }
                }
                MessageBox.Show("Сохранено");
                this.Close();
                (Sender as BalanceRepot).Init();
                return;
            }
            if (Type == 2 && isValid())
            {
                foreach (var i in BalanceControls)
                {


                    /*
                    BalanceOnDay item = new BalanceOnDay()
                    {
                        CurrencyID = Convert.ToInt32((i.Value as Control).Tag),
                        WorkDayID = workDay.WorkDayID,
                        StartAmount = Convert.ToDecimal((i.Value as Control).Text.Replace('.', ',')),
                        CurrentAmount = Convert.ToDecimal((i.Value as Control).Text.Replace('.', ','))
                    };*/
                    using (UserContext db = new UserContext(Settings.constr))
                    {
                        int cur = Convert.ToInt32((i.Value as Control).Tag);

                        var item = db.BalanceOnDays.Where(x => x.WorkDayID == workDay.WorkDayID && x.CurrencyID == cur).ToList().FirstOrDefault();
                        item.CurrencyID = Convert.ToInt32((i.Value as Control).Tag);
                        item.WorkDayID = workDay.WorkDayID;
                        item.StartAmount = Convert.ToDecimal((i.Value as Control).Text.Replace('.', ','));
                        item.CurrentAmount = Convert.ToDecimal((i.Value as Control).Text.Replace('.', ','));

                        db.BalanceOnDays.Attach(item);
                        var entry = db.Entry(item);
                        entry.Property(x => x.CurrencyID).IsModified = true;
                        entry.Property(x => x.StartAmount).IsModified = true;
                        db.SaveChanges();
                    }
                }
                MessageBox.Show("Обновлено");
                (Sender as BalanceRepot).Init();
                return;
            }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {


            this.Close();
        }
    }
}

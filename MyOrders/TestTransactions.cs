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
    public partial class TestTransactions : XtraForm
    {
        Payments Form;
        public class BindSrc
        {
            public int Value { get; set; }
            public string Text { get; set; }
        }
        public string GetCurName(int PaymentCurrencyCode)
        {
            using (var db = new UserContext(Settings.constr))
            {
                return db.CurrencyCodes.Where(x => x.Code == PaymentCurrencyCode).FirstOrDefault().CurrencyName;
            }
                
        }
        public int GetCurID(int PaymentCurrencyCode)
        {
            using (var db = new UserContext(Settings.constr))
            {
                return db.CurrencyCodes.Where(x => x.Code == PaymentCurrencyCode).FirstOrDefault().CurrencyID;
            }

        }
        public string GetCurNameByID(int id)
        {
            using (var db = new UserContext(Settings.constr))
            {
                return db.CurrencyCodes.Where(x => x.CurrencyID == id).FirstOrDefault().CurrencyName;
            }

        }
        public string GetConrAgentName(int id)
        {
            using (var db = new UserContext(Settings.constr))
            {
                return db.Contragents.Where(x => x.ContrAgentID == id).FirstOrDefault().Name;
            }
                
        }
        public TestTransactions(Payments form)
        {
            InitializeComponent();
            Form = form;
            Init();
        }
        List<BindSrc> bindList;
        public void Init()
        {
            bindList = new List<BindSrc>();
            foreach (var i in Form.PreTransactions)
            {

                bindList.Add(new BindSrc
                {
                    Value = i.ID,
                    Text = $"{Payments.FormatSum(i.Sum)} {GetCurName(i.PaymentCurrencyCode)} - {GetConrAgentName(i.ContrAgentID)}"
                });
            }
            listBox1.DataSource = bindList;
            listBox1.DisplayMember = "Text";
            listBox1.ValueMember = "Value";
            listBox1.Refresh();
            GetPreSum();
        }
        public void GetPreSum()
        {
            List<BalanceOnDay> PreBalances = new List<BalanceOnDay>();
            using (var db = new UserContext(Settings.constr))
            {
                var lastWorkDayID = db.WorkDays.Max(x => x.WorkDayID);
                PreBalances = db.BalanceOnDays.Where(x => x.WorkDayID == lastWorkDayID).ToList();
            }

            foreach (var i in Form.PreTransactions)
            {
                var sum = i.PaymentType == 1 ? i.Sum : i.Sum * -1;
                var cur = GetCurID(i.PaymentCurrencyCode);
                PreBalances.FirstOrDefault(x => x.CurrencyID == cur).CurrentAmount += sum;
            }
            string ret = "";
            foreach(var i in PreBalances)
            {
                ret += $"{Payments.FormatSum(i.CurrentAmount)} {GetCurNameByID(i.CurrencyID)} {Environment.NewLine}";
            }
            label2.Text = ret;
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            var item = Form.PreTransactions.FirstOrDefault(x => x.ID == Convert.ToInt32(listBox1.SelectedValue));
            Form.PreTransactions.Remove(item);
            Init();
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            Form.PreTransactions.Clear();
            Init();
        }
    }
}

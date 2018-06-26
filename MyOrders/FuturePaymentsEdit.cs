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
    public partial class FuturePaymentsEdit : XtraForm
    {
        public int Type;

        private FuturePayment FPayment;

        private object Sender;
        public FuturePaymentsEdit(int type, FuturePayment payment, object sender)
        {
            InitializeComponent();

            Type = type;
            Sender = sender;
            if (Type == 2)
            {
                FPayment = payment;
                InitFPaymentEditForm();
            }
                

            Dictionary<int, string> PaymentTypes = new Dictionary<int, string>();
            PaymentTypes.Add(1, "Приход");
            PaymentTypes.Add(2, "Расход");

            BindingSource pt_bs = new BindingSource(PaymentTypes, null);
            cb_PaymentType.DataSource = pt_bs;
            cb_PaymentType.DisplayMember = "Value";
            cb_PaymentType.ValueMember = "Key";


            BindingList<CurrencyCode> Currencies = new BindingList<CurrencyCode>();

            using (UserContext db = new UserContext(Settings.constr))
            {
                foreach (var i in db.CurrencyCodes.ToList())
                {
                    Currencies.Add(i);
                }
            }

            cb_Currency.DisplayMember = "CurrencyName";
            cb_Currency.ValueMember = "Code";
            cb_Currency.DataSource = Currencies;

            Dictionary<int, string> Colors = new Dictionary<int, string>();
            using (UserContext db = new UserContext(Settings.constr))
            {
                foreach (var i in db.PaymentColors.ToList())
                {
                    Colors.Add(i.ID, $"{i.ColorRus}/{i.Value}");
                }
            }

            if (Colors.Count>0)
            {
                BindingSource colors_bs = new BindingSource(Colors, null);
                cb_Color.DataSource = colors_bs;
                cb_Color.DisplayMember = "Value";
                cb_Color.ValueMember = "Key";
            }
            


            BindingList<ContrAgent> Contragents = new BindingList<ContrAgent>();

            using (UserContext db = new UserContext(Settings.constr))
            {
                foreach (var i in db.Contragents.ToList())
                {
                    Contragents.Add(i);
                }
            }

            cb_Contragent.DisplayMember = "Name";
            cb_Contragent.ValueMember = "ContrAgentID";
            cb_Contragent.DataSource = Contragents;

        }

        private bool isValid()
        {
            if (!Regex.IsMatch(tb_Sum.Text, @"^[0-9]*\.[0-9]{2}$"))
            {
                MessageBox.Show("Не корректно введена сумма!");
                return false;
            }
            if (cb_Contragent.SelectedValue == null)
            {
                MessageBox.Show("Не выбран контрагент");
                return false;

            }
            if (cb_Color.SelectedValue == null)
            {
                MessageBox.Show("Не выбран цвет");
                return false;
            }

            return true;
        }
        public void InitFPaymentEditForm()
        {
            cb_PaymentType.SelectedValue = FPayment.PaymentType;
            cb_Contragent.SelectedValue = FPayment.ContrAgentID;
            tb_Sum.Text = FPayment.Sum.ToString().Replace(',', '.');
            cb_Currency.SelectedValue = FPayment.PaymentCurrencyCode;
            tb_Comments.Text = FPayment.Comments;
            tb_ContractNum.Text = FPayment.CreditNum;
            tb_Acc.Text = FPayment.Acc;
            cb_Color.SelectedValue = FPayment.ColorID;
        }


        public void EditFPayment(FuturePayment payment)
        {
            payment.PaymentType = Convert.ToInt32(cb_PaymentType.SelectedValue);
            payment.ContrAgentID = Convert.ToInt32(cb_Contragent.SelectedValue);
            payment.Sum = Convert.ToDecimal(tb_Sum.Text.Replace('.', ','));
            payment.PaymentCurrencyCode = Convert.ToInt32(cb_Currency.SelectedValue);
            payment.Comments = tb_Comments.Text;
            payment.CreditNum = tb_ContractNum.Text;
            payment.Acc = tb_Acc.Text;
            payment.ColorID = Convert.ToInt32(cb_Color.SelectedValue);

            using (UserContext db = new UserContext(Settings.constr))
            {
                db.FuturePayments.Attach(payment);
                var entry = db.Entry(payment);
                entry.Property(x => x.PaymentType).IsModified = true;
                entry.Property(x => x.Sum).IsModified = true;
                
                entry.Property(x => x.PaymentCurrencyCode).IsModified = true;
                entry.Property(x => x.ContrAgentID).IsModified = true;
                entry.Property(x => x.Comments).IsModified = true;
                
                entry.Property(x => x.CreditNum).IsModified = true;
                entry.Property(x => x.Acc).IsModified = true;
                entry.Property(x => x.ColorID).IsModified = true;
                db.SaveChanges();
            }

        }



        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (Type == 1 & isValid())
            {
                FuturePayment newpayment = new FuturePayment()
                {
                    PaymentType = Convert.ToInt32(cb_PaymentType.SelectedValue),
                    ContrAgentID = Convert.ToInt32(cb_Contragent.SelectedValue),
                    Sum = Convert.ToDecimal(tb_Sum.Text.Replace('.', ',')),
                    PaymentCurrencyCode = Convert.ToInt32(cb_Currency.SelectedValue),
                    Comments = tb_Comments.Text,
                    CreditNum = tb_ContractNum.Text,
                    Acc = tb_Acc.Text,
                    CreateDate = DateTime.Today,
                    ColorID = Convert.ToInt32(cb_Color.SelectedValue)
                };

                using (UserContext db = new UserContext(Settings.constr))
                {
                    db.FuturePayments.Add(newpayment);
                    db.SaveChanges();
                }
                FPayment = newpayment;
                Type = 2;
                InitFPaymentEditForm();
                this.Text = "Редактирование платежа";
                MessageBox.Show("Платеж добавлен!");
                (Sender as FuturePaymentsRep).Init();
                this.Close();
                return;
            }

            if (Type == 2 & isValid())
            {
                EditFPayment(FPayment);
                InitFPaymentEditForm();
                (Sender as FuturePaymentsRep).Init();
                MessageBox.Show("Изменено!");
                this.Close();
                return;
            }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

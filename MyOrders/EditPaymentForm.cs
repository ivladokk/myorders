using DevExpress.XtraEditors;
using MyOrders.Dictionaries;
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
    public partial class EditPaymentForm : XtraForm
    {
        private Payment Payment;
        private int Type;
        object Sender;

        public EditPaymentForm(Payment payment, int type, object sender)
        {
            InitializeComponent();
            this.Sender = sender;
            this.Type = type;
            this.Payment = payment;

            Dictionary<int, string> PaymentTypes = new Dictionary<int, string>();
            PaymentTypes.Add(1, "Приход");
            PaymentTypes.Add(2, "Расход");

            BindingSource pt_bs = new BindingSource(PaymentTypes, null);
            cb_PaymentType.DataSource = pt_bs;
            cb_PaymentType.DisplayMember = "Value";
            cb_PaymentType.ValueMember = "Key";





            LoadAgents();

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



            Dictionary<int, string> PaymentStatuses = new Dictionary<int, string>();
            PaymentStatuses.Add(1, "Ожидает оплаты");
            PaymentStatuses.Add(2, "Оплачено");
            PaymentStatuses.Add(3, "Перспективный платеж");


            BindingSource ps_bs = new BindingSource(PaymentStatuses, null);
            cb_PaymentStatus.DataSource = ps_bs;
            cb_PaymentStatus.DisplayMember = "Value";
            cb_PaymentStatus.ValueMember = "Key";

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
            




            if (Type == 2)
                InitPaymentEditForm();

        }

        public void LoadAgents()
        {
            BindingList<ContrAgent> Contragents = new BindingList<ContrAgent>();

            using (UserContext db = new UserContext(Settings.constr))
            {
                foreach (var i in db.Contragents.ToList())
                {
                    Contragents.Add(i);
                }
            }

            cb_Contragent.Properties.DisplayMember = "Name";
            cb_Contragent.Properties.ValueMember = "ContrAgentID";
            cb_Contragent.Properties.DataSource = Contragents;
        }

        public void InitPaymentEditForm()
        {
            cb_PaymentType.SelectedValue = Payment.PaymentType;
            cb_Contragent.EditValue = Payment.ContrAgentID;
            tb_Sum.Text = Payment.Sum.ToString().Replace(',', '.');
            cb_Currency.SelectedValue = Payment.PaymentCurrencyCode;
            cb_PaymentStatus.SelectedValue = Payment.PaymentStatus;
            de_PaymentDate.Value = Payment.PaymentDate;
            tb_Comments.Text = Payment.Comments;
            tb_CreditNum.Text = Payment.CreditNum;
            tb_Acc.Text = Payment.Acc;
            de_ControlDate.Value = Payment.ControlDate;
            cb_Color.SelectedValue = Payment.ColorID;
        }


        private bool isValid()
        {
            if (!Regex.IsMatch(tb_Sum.Text, @"^[0-9]*\.[0-9]{2}$"))
            {
                MessageBox.Show("Не корректно введена сумма!");
                return false;
            }
            if (cb_Contragent.EditValue==null)
            {
                MessageBox.Show("Не выбран контрагент");
                return false;

            }
            if (cb_Color.SelectedValue==null)
            {
                MessageBox.Show("Не выбран цвет");
                return false;
            }

            return true;
        }


       

        public void EditPayement(Payment payment)
        {
            payment.PaymentType = Convert.ToInt32(cb_PaymentType.SelectedValue);
            payment.ContrAgentID = Convert.ToInt32(cb_Contragent.EditValue);
            payment.Sum = Convert.ToDecimal(tb_Sum.Text.Replace('.',','));
            payment.PaymentCurrencyCode = Convert.ToInt32(cb_Currency.SelectedValue);
            payment.PaymentStatus = Convert.ToInt32(cb_PaymentStatus.SelectedValue);
            payment.PaymentDate = de_PaymentDate.Value;
            payment.Comments = tb_Comments.Text;
            payment.CreditNum = tb_CreditNum.Text;
            payment.Acc = tb_Acc.Text;
            payment.ControlDate = de_ControlDate.Value;
            payment.ColorID = Convert.ToInt32(cb_Color.SelectedValue);

            using (UserContext db = new UserContext(Settings.constr))
            {
                db.Payments.Attach(payment);
                var entry = db.Entry(payment);
                entry.Property(x => x.PaymentType).IsModified = true;
                entry.Property(x => x.Sum).IsModified = true;
                entry.Property(x => x.PaymentDate).IsModified = true;
                entry.Property(x => x.PaymentCurrencyCode).IsModified = true;
                entry.Property(x => x.ContrAgentID).IsModified = true;
                entry.Property(x => x.Comments).IsModified = true;
                entry.Property(x => x.PaymentStatus).IsModified = true;
                entry.Property(x => x.CreditNum).IsModified = true;
                entry.Property(x => x.Acc).IsModified = true;
                entry.Property(x => x.ControlDate).IsModified = true;
                entry.Property(x => x.ColorID).IsModified = true;
                db.SaveChanges();
            }

            if (payment.PaymentStatus == 2)
            {
                TransactionUnit unit = new TransactionUnit(payment);
                var trans = unit.CreateTransaction();
                unit.PutTransOnBalance(trans);
                payment.TransactionID = trans.ID;

                using (UserContext db = new UserContext(Settings.constr))
                {
                    db.Payments.Attach(payment);
                    var entry = db.Entry(payment);
                    entry.Property(x => x.TransactionID).IsModified = true;
                    db.SaveChanges();
                }
            }


        }
        private void simpleButton3_Click(object sender, EventArgs e)
        {

        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (Type==1 & isValid())
            {
                Payment newpayment = new Payment()
                {
                    PaymentType = Convert.ToInt32(cb_PaymentType.SelectedValue),
                    ContrAgentID = Convert.ToInt32(cb_Contragent.EditValue),
                    Sum = Convert.ToDecimal(tb_Sum.Text.Replace('.', ',')),
                    PaymentCurrencyCode = Convert.ToInt32(cb_Currency.SelectedValue),
                    PaymentStatus = Convert.ToInt32(cb_PaymentStatus.SelectedValue),
                    PaymentDate = de_PaymentDate.Value,
                    Comments = tb_Comments.Text,
                    CreditNum = tb_CreditNum.Text,
                    Acc = tb_Acc.Text,
                    ControlDate = de_ControlDate.Value,
                    ColorID = Convert.ToInt32(cb_Color.SelectedValue)
                };

                using (UserContext db = new UserContext(Settings.constr))
                {
                    db.Payments.Add(newpayment);
                    db.SaveChanges();
                }
                Payment = newpayment;
                Type = 2;
                InitPaymentEditForm();
                this.Text = "Редактирование платежа";
                MessageBox.Show("Платеж добавлен!");
                (Sender as Payments).InitPaymentsForm((Sender as Payments).CurrentWeek);
                this.Close();
                return;
            }

            if (Type == 2 & isValid())
            {
                EditPayement(Payment);
                InitPaymentEditForm();
                (Sender as Payments).InitPaymentsForm((Sender as Payments).CurrentWeek);
                MessageBox.Show("Изменено!");
                this.Close();
                return;
            }


        }

        private void tb_Sum_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar)) && !((e.KeyChar == '.') && (tb_Sum.Text.IndexOf(".") == -1) && (tb_Sum.Text.Length != 0)))
            {
                if (e.KeyChar != (char)Keys.Back)
                {
                    e.Handled = true;

                }

            }
            
        }

        private void btn_AddAgent_Click(object sender, EventArgs e)
        {
            EditDictionaryForm f = new EditDictionaryForm(null, 3, this);
            f.Show();
        }

        private void groupControl8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

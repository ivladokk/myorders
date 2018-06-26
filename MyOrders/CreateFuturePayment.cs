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
    public partial class CreateFuturePayment : XtraForm
    {
        private FuturePayment payment;
        public CreateFuturePayment(FuturePayment p)
        {
            InitializeComponent();
            payment = p;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Payment newpayment = new Payment()
            {
                ControlDate = dateTimePicker1.Value,
                Sum = payment.Sum,
                Acc = payment.Acc,
                ColorID = payment.ColorID,
                PaymentStatus = 1,
                Comments = payment.Comments,
                ContrAgentID = payment.ContrAgentID,
                CreditNum = payment.CreditNum,
                PaymentCurrencyCode = payment.PaymentCurrencyCode,
                PaymentDate = dateTimePicker1.Value,
                PaymentType = payment.PaymentType
            };
            using (UserContext db = new UserContext(Settings.constr))
            {
                db.Payments.Add(newpayment);
                db.SaveChanges();
            }
            MessageBox.Show("Добавлено!");
            this.Close();
        }
    }
}

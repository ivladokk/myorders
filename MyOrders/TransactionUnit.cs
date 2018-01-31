using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyOrders
{


    public interface ITransaction
    {
        Transaction CreateTransaction();
        void PutTransOnBalance(Transaction tr);
    }

    class SimpleTransaction : ITransaction
    {
        private Payment _payment;

        public SimpleTransaction(Payment payment)
        {
            _payment = payment;
        }
        public Transaction CreateTransaction()
        {
            Transaction trans = new Transaction()
            {
                PaymentID = _payment.ID,
                TransactionCurrencyCode = _payment.PaymentCurrencyCode,
                Sum = _payment.PaymentType == 1 ? _payment.Sum : _payment.Sum * -1,
                TransactionDate = _payment.PaymentDate
            };
            return trans;
        }

        public void PutTransOnBalance(Transaction trans)
        {
            try
            {
                using (UserContext db = new UserContext(Settings.constr))
                {
                    db.Transactions.Add(trans);
                    db.SaveChanges();

                    var payment = db.Payments.Where(x => x.ID == trans.PaymentID).FirstOrDefault();
                    payment.TransactionID = trans.ID;
                    db.Payments.Attach(payment);
                    var ent = db.Entry(payment);
                    ent.Property(x => x.TransactionID).IsModified = true;
                    db.SaveChanges();

                    var lastWorkDayID = db.WorkDays.Max(x=>x.WorkDayID);
                    var curID = db.CurrencyCodes.Where(x => x.Code == trans.TransactionCurrencyCode).ToList().FirstOrDefault().CurrencyID;
                    var balance = db.BalanceOnDays.Where(x => x.WorkDayID == lastWorkDayID && x.CurrencyID == curID).FirstOrDefault();
                    balance.CurrentAmount += trans.Sum;
                    db.BalanceOnDays.Attach(balance);
                    var entry = db.Entry(balance);
                    entry.Property(x => x.CurrentAmount).IsModified = true;
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }
    }





    class TransactionUnit
    {
        private Payment _payment;
        public TransactionUnit(Payment payment)
        {
            _payment = payment;
        }

        public Transaction CreateTransaction()
        {

            Transaction trans = new Transaction()
            {
                PaymentID = _payment.ID,
                Sum = _payment.PaymentType == 1 ? _payment.Sum : _payment.Sum * -1,
                TransactionCurrencyCode = _payment.PaymentCurrencyCode,
                TransactionDate = DateTime.Today
            };
            return trans;
            

        }
        public void PutTransOnBalance(Transaction trans)
        {



            using (UserContext db = new UserContext(Settings.constr))
            {
                /*db.Transactions.Add(trans);
                var balance = db.Balances.ToList().Where(x => x.BalanceCurrency == trans.TransactionCurrencyCode).FirstOrDefault();
                balance.TotalSum += trans.Sum;
                db.Balances.Attach(balance);
                var entry = db.Entry(balance);
                entry.Property(x => x.TotalSum).IsModified = true;
                db.SaveChanges();*/
            }


        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AppCore;
using AppCore.Models;
using AppCore.Settings;

namespace MyOrders
{
    public partial class Payments : Form
    {

        public int CurrentWeek = 0;
        private List<PaymentColor> Colors;

        public List<Payment> PreTransactions;

        public Payments()
        {
            InitializeComponent();
            SetConvertMenuItems();
            SetConvertMenuItems2();
            PreTransactions = new List<Payment>();            tb_CurrentWeek.KeyPress += OnlyDigits;
            CurrentWeek = CalendarSetting.GetWeekOfYear(DateTime.Today);
            label1.Text = string.Format("Текущая неделя: {0}", CurrentWeek);
            tb_CurrentWeek.Text = CurrentWeek.ToString();

            

                InitPaymentsForm(CurrentWeek);

        }
        List<Payment> AllPayments = null;
        List<CurrencyCode> CurrencyCodes = null;

        List<ContrAgent> Contragents = null;
        public void InitPaymentsForm(int week)
        {
            GetBalance();

            dataGridView1.Columns.Clear();
            dataGridView1.Rows.Clear();

            dataGridView2.Columns.Clear();
            dataGridView2.Rows.Clear();


            var days = CalendarSetting.getDaysOfTwoWeeks(week);
            try
            {
                using (UserContext db = new UserContext(Settings.constr))
                {
                    AllPayments = db.Payments.ToList();
                    if (AllPayments.Count == 0) return;
                    Contragents = db.Contragents.ToList();
                    CurrencyCodes = db.CurrencyCodes.ToList();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            using (UserContext db = new UserContext(Settings.constr))
            {
                Colors = db.PaymentColors.ToList();
            }

            foreach (DateTime i in days)
            {
                if (Settings.isShowWeekends)
                {
                    string caption = CultureInfo.GetCultureInfo("ru-RU").DateTimeFormat.GetDayName(Convert.ToDateTime(i.ToString()).DayOfWeek);
                    dataGridView1.Columns.Add(i.ToString("dd.MM.yyyy"), i.ToString("dd.MM.yyyy") + " " + caption);
                    dataGridView2.Columns.Add(i.ToString("dd.MM.yyyy"), i.ToString("dd.MM.yyyy") + " " + caption);
                }
                else
                {
                    if (i.DayOfWeek != DayOfWeek.Saturday && i.DayOfWeek != DayOfWeek.Sunday)
                    {
                        string caption = CultureInfo.GetCultureInfo("ru-RU").DateTimeFormat.GetDayName(Convert.ToDateTime(i.ToString()).DayOfWeek);
                        dataGridView1.Columns.Add(i.ToString("dd.MM.yyyy"), i.ToString("dd.MM.yyyy") + " " + caption);
                        dataGridView2.Columns.Add(i.ToString("dd.MM.yyyy"), i.ToString("dd.MM.yyyy") + " " + caption);
                    }
                }
                
            }
            foreach (DataGridViewColumn i in dataGridView1.Columns)
            {
                if (i.Name == DateTime.Today.ToString("dd.MM.yyyy"))
                {
                    i.HeaderCell.Style.Font = new Font("Tahoma", 8.5f, FontStyle.Bold);
                }
            }
            InitPaymentsGrid(dataGridView1, getRowCnt(days, 1), 1);
           

            InitPaymentsGrid(dataGridView2, getRowCnt(days, 2), 2);
        }


        public int getRowCnt(List<DateTime> days, int paymentType)
        {
            int rowcnt = 0;

            using (SqlConnection conn = new SqlConnection(Settings.constr))
            {
                try
                {


                    var cmdStr = $"select top 1 count(*) as rowcnt from Payments where PaymentType={paymentType} and convert(date,ControlDate,104) >= convert(date,'{days.First().ToString("dd.MM.yyyy")}',104) and convert(date,ControlDate,104) <= convert(date,'{days.Last().ToString("dd.MM.yyyy")}',104) group by convert(date, ControlDate,104) order by count(*) desc";

                    //SqlCommand cmd = new SqlCommand($"select top 1 count(*) as rowcnt from Payments where PaymentType={paymentType} and ControlDate between convert(date,'{days.First().ToString("MM.dd.yyyy")}',104) and convert(date,'{days.Last().ToString("MM.dd.yyyy")}') group by convert(date, ControlDate) order by count(*) desc", conn);
                    SqlCommand cmd = new SqlCommand(cmdStr, conn);
                    conn.Open();
                    rowcnt = (int)cmd.ExecuteScalar();

                }
                catch (Exception ex)
                {
                    // MessageBox.Show(ex.Message);
                }
            }
                return rowcnt;
        }


        public static string FormatSum(decimal sum)
        {
            var numberFormatInfo = new System.Globalization.CultureInfo("en-Us", false).NumberFormat;
            numberFormatInfo.NumberGroupSeparator = " ";
            var ret = sum.ToString("N", numberFormatInfo);  // "2 401 000.22"
            return ret;
        }
        public void InitPaymentsGrid(DataGridView grid, int rowscount, int paymentType)
        {
            if (rowscount == 0) return;


            grid.Rows.Add(rowscount);

            foreach (DataGridViewColumn col in grid.Columns)
            {
                //DateTime date = Convert.ToDateTime(col.Name);
                DateTime date = DateTime.ParseExact(col.Name, "dd.MM.yyyy", CultureInfo.InvariantCulture);

                var rows = AllPayments.Where(x => x.ControlDate.ToString("dd:MM:yyyy", CultureInfo.InvariantCulture) == date.ToString("dd:MM:yyyy", CultureInfo.InvariantCulture) && x.PaymentType == paymentType).ToList();

                for (int i = 0; i < rows.Count; i++)
                {


                    string ContrAgentName = Contragents.Where(x => x.ContrAgentID == rows[i].ContrAgentID).FirstOrDefault().Name;
                    string CurCode = CurrencyCodes.Where(x => x.Code == rows[i].PaymentCurrencyCode).FirstOrDefault().CurrencyName;


                    var en = Environment.NewLine;
                    string content = $"{FormatSum(rows[i].Sum)} {CurCode} {en} {ContrAgentName} {en} №сп {rows[i].CreditNum},№сч {rows[i].Acc},  {en} {rows[i].Comments}";

                    var fontSimple = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
                    var fontBold = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));


                    try
                    {
                        grid[col.Name, i] = new DataGridViewTextBoxCell()
                        {
                            Value = content, //string.Format("{0},сумма:{1}", ContrAgentName, rows[i].Sum),
                            Style = new DataGridViewCellStyle()
                            {
                                Font = rows[i].TransactionID == 0 ? fontSimple : fontBold,
                                BackColor = isPaymentExpired(rows[i]) ? Color.Red : GetPaymentColor(rows[i].ColorID),//paymentType == 2 ? Color.LightGreen : Color.Azure,//GetStatusColor(rows[i].Status),
                                Alignment = DataGridViewContentAlignment.MiddleCenter,
                                SelectionBackColor = isPaymentExpired(rows[i]) ? Color.Red : GetPaymentColor(rows[i].ColorID)//paymentType == 2 ? Color.LightGreen : Color.Azure//GetStatusColor(rows[i].Status)
                            }

                        };

                        grid[col.Name, i].Tag = rows[i].ID.ToString();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }
        
        public void GetBalance()
        {
            using (UserContext db = new UserContext(Settings.constr))
            {
                if (db.BalanceOnDays.ToList().Count == 0) return;
                var lastBalanceID = db.BalanceOnDays.Max(x => x.WorkDayID);
                var lastBalanceList = db.BalanceOnDays.Where(x => x.WorkDayID == lastBalanceID).ToList();
                string text = "";
                foreach (var i in lastBalanceList)
                {
                    string curName = db.CurrencyCodes.Where(x => x.CurrencyID == i.CurrencyID).ToList().FirstOrDefault().CurrencyName;
                    text += $"{curName}:{i.CurrentAmount}";
                    text += " ";
                }
                lb_balance.Text = text;
            }
        }

        private bool isPaymentExpired(Payment payment)
        {
            return payment.PaymentStatus == 1 && (payment.ControlDate < DateTime.Today);
        }

        private Color GetPaymentColor(int colorID)
        {
            Color ret;
            if (Colors.Where(x => x.ID == colorID).ToList().Count != 0)
                ret = Color.FromArgb(Convert.ToInt32(Colors.Where(x => x.ID == colorID).FirstOrDefault().Color));
            else ret = Color.White;

            return ret;
            
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dataGridView1.CurrentCell.Tag != null)
            {
                var ID = Convert.ToInt32(dataGridView1.CurrentCell.Tag);
                using (UserContext db = new UserContext(Settings.constr))
                {
                    var item = db.Payments.SingleOrDefault(x => x.ID == ID);
                    EditPaymentForm f = new EditPaymentForm(item, 2, this);
                    f.StartPosition = FormStartPosition.CenterScreen;
                    f.Show();
                }
            }

        }

        private void CreateTransaction(Payment payment)
        {
            if (payment.PaymentStatus != 2)
            {
                MessageBox.Show("Переведите платеж в статус Оплачено!");
                return;
            }
            if (payment.TransactionID != 0)
            {
                MessageBox.Show("Этот платеж уже отражен");
                return;
            }
                
            
            SimpleTransaction trans = new SimpleTransaction(payment);
            var newtrans = trans.CreateTransaction();
            trans.PutTransOnBalance(newtrans);
            MessageBox.Show("Отражено!");
            InitPaymentsForm(CurrentWeek);
        }

        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                dataGridView1.CurrentCell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                dataGridView1.Focus();
            }
        }
        private void dataGridView1_KeyPress(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                InitPaymentsForm(CurrentWeek);
            }
        }

        private void OnlyDigits(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != Convert.ToChar(8))
            {
                e.Handled = true;
            }
        }

        private void добавитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditPaymentForm f = new EditPaymentForm(null, 1, this);
            f.StartPosition = FormStartPosition.CenterScreen;
            f.Show();
        }

        private void btn_PrevWeek_Click(object sender, EventArgs e)
        {
            CurrentWeek--;
            tb_CurrentWeek.Text = CurrentWeek.ToString();
            InitPaymentsForm(CurrentWeek);
        }

        private void btn_NextWeek_Click(object sender, EventArgs e)
        {
            CurrentWeek++;
            tb_CurrentWeek.Text = CurrentWeek.ToString();
            InitPaymentsForm(CurrentWeek);
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dataGridView2.CurrentCell.Tag != null)
            {
                var ID = Convert.ToInt32(dataGridView2.CurrentCell.Tag);
                using (UserContext db = new UserContext(Settings.constr))
                {
                    var item = db.Payments.Where(x => x.ID == ID).SingleOrDefault();
                    EditPaymentForm f = new EditPaymentForm(item, 2, this);
                    f.StartPosition = FormStartPosition.CenterScreen;
                    f.Show();
                }
            }
        }

        private void отразитьНаБалансеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentCell.Tag != null)
            {
                var ID = Convert.ToInt32(dataGridView1.CurrentCell.Tag);
                using (UserContext db = new UserContext(Settings.constr))
                {
                    var item = db.Payments.Where(x => x.ID == ID).SingleOrDefault();
                    CreateTransaction(item);
                }
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            EditPaymentForm f = new EditPaymentForm(null, 1, this);
            f.StartPosition = FormStartPosition.CenterScreen;
            f.Show();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (dataGridView2.CurrentCell.Tag != null)
            {
                var ID = Convert.ToInt32(dataGridView2.CurrentCell.Tag);
                using (UserContext db = new UserContext(Settings.constr))
                {
                    var item = db.Payments.Where(x => x.ID == ID).SingleOrDefault();
                    EditPaymentForm f = new EditPaymentForm(item, 2, this);
                    f.StartPosition = FormStartPosition.CenterScreen;
                    f.Show();
                }
            }
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            if (dataGridView2.CurrentCell.Tag != null)
            {
                var ID = Convert.ToInt32(dataGridView2.CurrentCell.Tag);
                using (UserContext db = new UserContext(Settings.constr))
                {
                    var item = db.Payments.Where(x => x.ID == ID).SingleOrDefault();
                    CreateTransaction(item);
                }
            }
        }

        private void изменитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentCell.Tag != null)
            {
                var ID = Convert.ToInt32(dataGridView1.CurrentCell.Tag);
                using (UserContext db = new UserContext(Settings.constr))
                {
                    var item = db.Payments.Where(x => x.ID == ID).SingleOrDefault();
                    EditPaymentForm f = new EditPaymentForm(item, 2, this);
                    f.StartPosition = FormStartPosition.CenterScreen;
                    f.Show();
                }
            }
        }

        public void SetConvertMenuItems()
        {
            using (var db = new UserContext(Settings.constr))
            {
                var currencies = db.CurrencyCodes.ToList();
                foreach (var i in currencies)
                {
                    ToolStripMenuItem menuItem = new ToolStripMenuItem();
                    menuItem.Name = i.CurrencyName;
                    menuItem.Text = $"В {i.CurrencyName}";
                    menuItem.Click += ConvertMenuClick;
                    menuItem.Tag = i;
                    //menuItem.Size = new System.Drawing.Size(188, 22);
                    ConvertToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { menuItem });
                }
            }
        }

        public void SetConvertMenuItems2()
        {
            using (var db = new UserContext(Settings.constr))
            {
                var currencies = db.CurrencyCodes.ToList();
                foreach (var i in currencies)
                {
                    ToolStripMenuItem menuItem = new ToolStripMenuItem();
                    menuItem.Name = i.CurrencyName;
                    menuItem.Text = $"В {i.CurrencyName}";
                    menuItem.Click += ConvertMenuClick2;
                    menuItem.Tag = i;
                    //menuItem.Size = new System.Drawing.Size(188, 22);
                    ConvertToolStripMenuItem2.DropDownItems.AddRange(new ToolStripItem[] { menuItem });
                }
            }
        }


        private void ConvertMenuClick(object sender, EventArgs e)
        {
            
            try
            {
                var curTo = (sender as ToolStripItem).Tag as CurrencyCode;
                var ID = Convert.ToInt32(dataGridView1.CurrentCell.Tag);
                using (UserContext db = new UserContext(Settings.constr))
                {
                    var payment = db.Payments.Where(x => x.ID == ID).SingleOrDefault();
                    if (payment.TransactionID != 0)
                    {
                        MessageBox.Show("Конвертация невозможна, т.к. платеж уже отражен на балансе!");
                        return;
                    }
                    ConvertPayment(curTo, payment);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                InitPaymentsForm(CurrentWeek);
            }
            
            
        }
        private void ConvertMenuClick2(object sender, EventArgs e)
        {

            try
            {
                var curTo = (sender as ToolStripItem).Tag as CurrencyCode;
                var ID = Convert.ToInt32(dataGridView2.CurrentCell.Tag);
                using (UserContext db = new UserContext(Settings.constr))
                {
                    var payment = db.Payments.Where(x => x.ID == ID).SingleOrDefault();
                    if (payment.TransactionID != 0)
                    {
                        MessageBox.Show("Конвертация невозможна, т.к. платеж уже отражен на балансе!");
                        return;
                    }
                    ConvertPayment(curTo, payment);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                InitPaymentsForm(CurrentWeek);
            }


        }

        private void ConvertPayment(CurrencyCode To, Payment payment)
        {
            
            using (var db = new UserContext(Settings.constr))
            {
                if (db.Rates.ToList().Count == 0) throw new Exception("Не введены курсы!");
                int maxRateDate = db.Rates.Max(x => x.WorkDayID);
                var rates = db.Rates.Where(x => x.WorkDayID == maxRateDate).ToList();
                int paymentCurID = db.CurrencyCodes.FirstOrDefault(x => x.Code == payment.PaymentCurrencyCode).CurrencyID;
                var currate = rates.FirstOrDefault(x => x.FromCurID == paymentCurID && x.ToCurID == To.CurrencyID);
                if (currate == null )
                {
                    throw new Exception("Не найден курс!");
                }
                var newAmount = (Convert.ToDecimal(currate.RateValue) / currate.Scale) * payment.Sum;

                payment.Sum = newAmount;
                payment.PaymentCurrencyCode = To.Code;
                db.Payments.Attach(payment);
                var entry = db.Entry(payment);
                entry.Property(x => x.Sum).IsModified = true;
                entry.Property(x => x.PaymentCurrencyCode).IsModified = true;
                db.SaveChanges();
            }

        }
        private void предварительныйРасчетToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentCell.Tag != null)
            {
                var ID = Convert.ToInt32(dataGridView1.CurrentCell.Tag);
                using (UserContext db = new UserContext(Settings.constr))
                {
                    var item = db.Payments.Where(x => x.ID == ID).SingleOrDefault();
                    if (PreTransactions.Where(x => x.ID == item.ID).ToList().Count() == 0)
                        PreTransactions.Add(item);
                    else MessageBox.Show("Этот платеж уже добавлен в список");
                }
            }
        }

        private void показатьПредварительныйРасчетToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TestTransactions f = new TestTransactions(this);
            f.ShowDialog();
        }

        private void добавитьВПредварительныйРасчетToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView2.CurrentCell.Tag != null)
            {
                var ID = Convert.ToInt32(dataGridView2.CurrentCell.Tag);
                using (UserContext db = new UserContext(Settings.constr))
                {
                    var item = db.Payments.Where(x => x.ID == ID).SingleOrDefault();
                    if (PreTransactions.Where(x => x.ID == item.ID).ToList().Count() == 0)
                        PreTransactions.Add(item);
                    else MessageBox.Show("Этот платеж уже добавлен в список");
                }
            }
        }

        private void показатьПредварительныйРасчетToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            TestTransactions f = new TestTransactions(this);
            f.ShowDialog();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        public void DeletePayment(Payment payment)
        {
            DialogResult dialogResult = MessageBox.Show("Удалить платеж?", "Удаление", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                if (payment.TransactionID != 0)
                {
                    MessageBox.Show("Удаление невозможно, т.к. платеж уже отражен на балансе!");
                    return;
                }
                using (var db = new UserContext(Settings.constr))
                {
                    var item = db.Payments.FirstOrDefault(x => x.ID == payment.ID);
                    db.Payments.Remove(item);
                    db.SaveChanges();
                }
                MessageBox.Show("Удалено");
            }
            else if (dialogResult == DialogResult.No)
            {
                return;
            }

            
        }
        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentCell.Tag != null)
            {
                var ID = Convert.ToInt32(dataGridView1.CurrentCell.Tag);
                using (UserContext db = new UserContext(Settings.constr))
                {
                    var item = db.Payments.Where(x => x.ID == ID).SingleOrDefault();
                    DeletePayment(item);
                }
            }
            InitPaymentsForm(this.CurrentWeek);
        }

        private void удалитьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (dataGridView2.CurrentCell.Tag != null)
            {
                var ID = Convert.ToInt32(dataGridView2.CurrentCell.Tag);
                using (UserContext db = new UserContext(Settings.constr))
                {
                    var item = db.Payments.Where(x => x.ID == ID).SingleOrDefault();
                    DeletePayment(item);
                }
            }
            InitPaymentsForm(this.CurrentWeek);
        }

        public void CancelTransaction(Payment payment)
        {
            int transID = payment.TransactionID;
            if (transID == 0)
            {
                MessageBox.Show("Платеж еще не проведен!");
                return;
            }
            
            try
            {
                using (var db = new UserContext(Settings.constr))
                {
                    var trans = db.Transactions.FirstOrDefault(x => x.ID == transID);
                    var date = trans.TransactionDate.ToString("dd.MM.yyyy");
                    var workDay = db.WorkDays.ToList().FirstOrDefault(x => x.WorkDayDate.ToString("dd.MM.yyyy") == date);
                    if (workDay == null)
                    {
                        MessageBox.Show("Ошибка! Не найден рабочий день!");
                        return;
                    }
                    var dayID = workDay.WorkDayID;
                    var currency = db.CurrencyCodes.FirstOrDefault(x => x.Code == trans.TransactionCurrencyCode).CurrencyID;
                    var balance = db.BalanceOnDays.FirstOrDefault(x => x.WorkDayID == dayID && x.CurrencyID == currency);
                    balance.CurrentAmount -= trans.Sum;
                    db.BalanceOnDays.Attach(balance);

                    var entry = db.Entry(balance);
                    entry.Property(x => x.CurrentAmount).IsModified = true;
                    var paym = db.Payments.FirstOrDefault(x => x.ID == payment.ID);
                    paym.TransactionID = 0;
                    var payentry = db.Entry(paym);
                    payentry.Property(x => x.TransactionID).IsModified = true;

                    db.Transactions.Remove(trans);

                    db.SaveChanges();
                }
                MessageBox.Show("Баланс изменен");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
            
            
        }
        private void отменитьПроводкуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentCell.Tag != null)
            {
                var ID = Convert.ToInt32(dataGridView1.CurrentCell.Tag);
                using (UserContext db = new UserContext(Settings.constr))
                {
                    var item = db.Payments.Where(x => x.ID == ID).SingleOrDefault();
                    CancelTransaction(item);
                }
            }
            InitPaymentsForm(this.CurrentWeek);
        }

        private void отменитьПроводкуToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            if (dataGridView2.CurrentCell.Tag != null)
            {
                var ID = Convert.ToInt32(dataGridView2.CurrentCell.Tag);
                using (UserContext db = new UserContext(Settings.constr))
                {
                    var item = db.Payments.Where(x => x.ID == ID).SingleOrDefault();
                    CancelTransaction(item);
                }
            }
            InitPaymentsForm(this.CurrentWeek);
        }
    }
}

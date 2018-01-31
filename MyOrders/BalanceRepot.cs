using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyOrders
{
    public partial class BalanceRepot : Form
    {
        public BalanceRepot()
        {
            InitializeComponent();
            try
            {
                Init();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        public void Init()
        {

            dataGridView1.Columns.Clear();
            dataGridView1.Rows.Clear();
            DataGridViewColumn col = new DataGridViewColumn()
            {
                Name = "WorkDay",
                HeaderText = "Рабочий день"
            };
            dataGridView1.Columns.Add("WorkDay", "Рабочий день");

            using (UserContext db = new UserContext(Settings.constr))
            {
                if (db.CurrencyCodes.ToList().Count == 0) return;
                foreach (var i in db.CurrencyCodes)
                {
                    dataGridView1.Columns.Add(i.CurrencyName, i.CurrencyName + "(начальный)");
                    dataGridView1.Columns.Add(i.CurrencyName + "Current", i.CurrencyName + "(Текущий)");
                }

                var cnt = db.WorkDays.ToList().Count;
                if (cnt == 0) return;
                //dataGridView1.Rows.Add();
                for (int i = 0; i < db.WorkDays.ToList().Count; i++)
                {
                    dataGridView1.Rows.Add();

                    var date = db.WorkDays.ToList()[i].WorkDayDate;
                    int dayID = db.WorkDays.ToList()[i].WorkDayID;

                    dataGridView1["WorkDay", i] = new DataGridViewTextBoxCell()
                    {
                        Value = date.ToString("dd.MM.yyyy")

                    };
                    var balancesOnDay = db.BalanceOnDays.Where(x => x.WorkDayID == dayID).ToList();
                    if (balancesOnDay.Count == 0) return;
                    foreach (var bal in balancesOnDay)
                    {
                        var colName = db.CurrencyCodes.Where(x => x.CurrencyID == bal.CurrencyID).FirstOrDefault().CurrencyName;
                        dataGridView1[colName, i] = new DataGridViewTextBoxCell()
                        {
                            Value = Payments.FormatSum(bal.StartAmount)
                        };
                        dataGridView1[colName + "Current", i] = new DataGridViewTextBoxCell()
                        {
                            Value = Payments.FormatSum(bal.CurrentAmount)
                        };
                    }
                    dataGridView1.Rows[i].Tag = dayID;
                }
            }
        }

        private void добавитьБалансToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //var curWorkDayID = Convert.ToInt32(dataGridView1.CurrentRow.Tag);
            BalanceForm f = new BalanceForm(1, 0, this);
            f.ShowDialog();
        }

        private void изменитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var curWorkDayID = Convert.ToInt32(dataGridView1.CurrentRow.Tag);
            BalanceForm f = new BalanceForm(2, curWorkDayID, this);
            f.ShowDialog();

        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var curWorkDayID = Convert.ToInt32(dataGridView1.CurrentRow.Tag);
            try
            {
                using (UserContext db = new UserContext(Settings.constr))
                {
                    var item = db.WorkDays.FirstOrDefault(x => x.WorkDayID == curWorkDayID);
                    db.WorkDays.Remove(item);
                    db.BalanceOnDays.Remove(db.BalanceOnDays.FirstOrDefault(x => x.WorkDayID == curWorkDayID));
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            MessageBox.Show("Удалено!");
            Init();
        }

        private void курсыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var curWorkDayID = Convert.ToInt32(dataGridView1.CurrentRow.Tag);

            using (UserContext db = new UserContext(Settings.constr))
            {
                var item = db.WorkDays.FirstOrDefault(x => x.WorkDayID == curWorkDayID);
                RatesForm f = new RatesForm(item);
                f.ShowDialog();
            }
        }
    }
    

    class BalanceReportItem
    {
        public DateTime WorkDay { get; set; }
        public List<CurrencyCode> Currencies { get; set; }
    }

}

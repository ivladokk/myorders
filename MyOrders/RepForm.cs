using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data.SqlClient;
using System.Globalization;
using AppCore;
using AppCore.Models;
using AppCore.Settings;

namespace MyOrders
{
    public partial class RepForm : DevExpress.XtraEditors.XtraForm
    {
        public int CurrentWeek = 0;
        public RepForm()
        {
            InitializeComponent();
            tb_CurrentWeek.KeyPress += OnlyDigits;
            CurrentWeek = CalendarSetting.GetWeekOfYear(DateTime.Today);
            label1.Text = string.Format("Текущая неделя: {0}", CurrentWeek);
            tb_CurrentWeek.Text = CurrentWeek.ToString();
            BuildReport(CurrentWeek);

        }
        List<ContrAgent> Contragents = null;
        public void BuildReport(int week)
        {
            dataGridView1.Columns.Clear();
            dataGridView1.Rows.Clear();

            var days = CalendarSetting.getDaysOfWeek(week);

            List<Order> Orders = null;
            try
            {
                using (UserContext db = new UserContext(Settings.constr))
                {
                    Orders = db.Orders.Where(x=>x.Status!=5).ToList();
                    if (Orders.Count == 0) return;

                    Contragents = db.Contragents.ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            

            foreach (DateTime i in days)
            {
                string caption = CultureInfo.GetCultureInfo("ru-RU").DateTimeFormat.GetDayName(Convert.ToDateTime(i.ToString()).DayOfWeek);
                dataGridView1.Columns.Add(i.ToString("dd.MM.yyyy"), i.ToString("dd.MM.yyyy") + " " + caption);
            }

            var rowsCount = 0;




            using (SqlConnection conn = new SqlConnection(Settings.constr))
            {
                SqlCommand cmd = new SqlCommand("select top 1 count(*) as rowcnt from Orders group by convert(date,ControlDate) order by count(*) desc", conn);
                try
                {
                    conn.Open();
                    rowsCount = (int)cmd.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            if (rowsCount == 0) return;

            dataGridView1.Rows.Add(rowsCount);


           

            foreach (DataGridViewColumn col in dataGridView1.Columns)
            {
                DateTime date = Convert.ToDateTime(col.Name);
                //DateTime date = DateTime.ParseExact(col.HeaderText, "dd:MM:yyyy", CultureInfo.InvariantCulture);

                var rows = Orders.Where(x =>x.ControlDate.ToString("dd:MM:yyyy", CultureInfo.InvariantCulture) == date.ToString("dd:MM:yyyy", CultureInfo.InvariantCulture)).ToList();
               
                for (int i = 0; i < rows.Count; i++)
                {
                    dataGridView1[col.Name, i] = new DataGridViewTextBoxCell()
                        {
                            Value = string.Format("{0},гр.мест:{1},общ.вес:{2}", /*rows[i].Provider*/GetProvider(rows[i]), rows[i].PlaceCount,GetTotalWeight(rows[i].ID)),
                            Style = new DataGridViewCellStyle()
                            {
                                BackColor = GetStatusColor(rows[i].Status),
                                Alignment = DataGridViewContentAlignment.MiddleCenter,
                                SelectionBackColor = GetStatusColor(rows[i].Status)
                            }

                        };

                    dataGridView1[col.Name, i].Tag = rows[i].ID.ToString();


                }
            }

        }

        private string GetProvider(Order item)
        {
            return item.ProviderID == null
                ? item.Provider
                : Contragents.FirstOrDefault(x => x.ContrAgentID == item.ProviderID).Name;
        }
        public int GetTotalWeight(int OrderID)
        {
            var db = new UserContext(Settings.constr);
            List<Good> goods = db.Goods.Where(x => x.OrderID == OrderID).ToList();
            int total = 0;
            foreach (Good i in goods)
                total += i.Weight;
            return total;
        }
        public Color GetStatusColor(int status)
        {
            Status color;
            using (UserContext db = new UserContext(Settings.constr))
            {
                color = db.OrderStatuses.SingleOrDefault(x => x.StatusID == status);
            }
            return status != 0 ? Color.FromName(color.StatusColor) : Color.White;
        }

        

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dataGridView1.CurrentCell.Tag != null)
            {
                var ID = Convert.ToInt32(dataGridView1.CurrentCell.Tag);
                using (UserContext db = new UserContext(Settings.constr))
                {
                    var item = db.Orders.SingleOrDefault(x => x.ID == ID);
                    OrderInfo f = new OrderInfo(item);
                    f.StartPosition = FormStartPosition.CenterScreen;

                    f.Show();
                }
            }

        }

        private void подробнееToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentCell.Tag != null)
            {
                var ID = Convert.ToInt32(dataGridView1.CurrentCell.Tag);
                using (UserContext db = new UserContext(Settings.constr))
                {
                    var item = db.Orders.SingleOrDefault(x => x.ID == ID);
                    OrderInfo f = new OrderInfo(item);
                    f.StartPosition = FormStartPosition.CenterScreen;

                    f.Show();
                }
            }
        }

        private void добавитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditForm f = new EditForm(null, 1,this);
            f.ShowDialog();
        }

        private void изменитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentCell.Tag != null)
            {
                var ID = Convert.ToInt32(dataGridView1.CurrentCell.Tag);
                using (UserContext db = new UserContext(Settings.constr))
                {
                    var item = db.Orders.SingleOrDefault(x => x.ID == ID);
                    EditForm f = new EditForm(item, 2,this);
                    f.StartPosition = FormStartPosition.CenterScreen;

                    f.Show();
                }
            }
        }

        private void dataGridView1_KeyPress(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                BuildReport(CurrentWeek);
            }
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentCell.Tag != null)
            {
                var ID = Convert.ToInt32(dataGridView1.CurrentCell.Tag);
                using (UserContext db = new UserContext(Settings.constr))
                {
                    var item = db.Orders.SingleOrDefault(x => x.ID == ID);
                    db.Orders.Attach(item);
                    db.Orders.Remove(item);
                    db.SaveChanges();
                    MessageBox.Show("Удалено!");
                }
                BuildReport(CurrentWeek);
            }
        }

        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                dataGridView1.CurrentCell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                dataGridView1.Focus();
            }
        }

        private void tb_CurrentWeek_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                BuildReport(Convert.ToInt32(tb_CurrentWeek.Text));
            }
        }

        private void btn_PrevWeek_Click(object sender, EventArgs e)
        {
            CurrentWeek--;
            tb_CurrentWeek.Text = CurrentWeek.ToString();
            BuildReport(CurrentWeek);


        }

        private void btn_NextWeek_Click(object sender, EventArgs e)
        {
            CurrentWeek++;
            tb_CurrentWeek.Text = CurrentWeek.ToString();
            BuildReport(CurrentWeek);
        }

        private void OnlyDigits(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != Convert.ToChar(8))
            {
                e.Handled = true;
            }
        }
    }
}
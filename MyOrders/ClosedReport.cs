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
    public partial class ClosedReport : Form
    {
        public ClosedReport()
        {
            InitializeComponent();
            InitReport();
        }
        public void InitReport()
        {
            List<Order> orders;
            using (UserContext db = new UserContext(Settings.constr))
            {
                
                orders = db.Orders.Where(x => x.Status == 5).ToList();

            }
            var bindingList = new BindingList<Order>(orders);
            var source = new BindingSource(bindingList, null);
            dataGridView1.DataSource = source;
            dataGridView1.Columns["ID"].HeaderText = "ID Заказа";
            dataGridView1.Columns["AddDate"].HeaderText = "Дата создания";
            dataGridView1.Columns["OrderDate"].HeaderText = "Дата поставки";
            dataGridView1.Columns["ControlDate"].HeaderText = "Контрольная дата";
            dataGridView1.Columns["Provider"].HeaderText = "Поставщик";
            dataGridView1.Columns["AcceptNum"].HeaderText = "Номер подтверждения";
            dataGridView1.Columns["Status"].HeaderText = "Статус";
            dataGridView1.Columns["PlaceCount"].HeaderText = "Кол-во мест";




        }
    }
}

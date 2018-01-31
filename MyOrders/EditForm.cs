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

namespace MyOrders
{
    public partial class EditForm : DevExpress.XtraEditors.XtraForm
    {
        public Order MyOrder;
        public int Type;
        public int OrderID;
        public List<Good> MyGoods;
        object Sender;
        public EditForm(Order order,int type, object sender)
        {
            InitializeComponent();

            tb_AcceptNum.KeyPress += OnlyDigits;
            tb_PlaceCount.KeyPress += OnlyDigits;


            Sender = sender;
            BindingList<Status> objects = new BindingList<Status>();
            using (UserContext db = new UserContext(Settings.constr))
            {
                foreach (var i in db.OrderStatuses.ToList())
                {
                    objects.Add(i);

                }
                cb_Status.ValueMember = "StatusID";
                cb_Status.DisplayMember = "StatusValue";
                cb_Status.DataSource = objects;
            }

            Type = type;
            MyOrder = order;
            if (Type == 2)
            {
                InitEditForm();
                this.Text = "Редактирование заказа";
            }
                
        }


        private void OnlyDigits(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != Convert.ToChar(8))
            {
                e.Handled = true;
            }
        }
        private void popupContainerEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (MyOrder == null)
            {
                MessageBox.Show("Создайте заказ!");
                return;
            }

            flyoutPanelControl1.Controls.Clear();
            flyoutPanelControl1.Controls.Add(new GoodEdit(null, 1, this, MyOrder.ID));
            flyoutPanel1.ShowPopup();
        }


        public void InitEditForm()
        {
            tb_Provider.Text = MyOrder.Provider;
            tb_AcceptNum.Text = MyOrder.AcceptNum.ToString();
            dt_OrderDate.Value = MyOrder.OrderDate;
            dt_ControlDate.Value = MyOrder.ControlDate;
            cb_Status.SelectedValue = MyOrder.Status;
            tb_PlaceCount.Text = MyOrder.PlaceCount.ToString();
            using (UserContext db = new UserContext(Settings.constr))
            {
                MyGoods = db.Goods.Where(x => x.OrderID == MyOrder.ID).ToList();
            }
            flowLayoutPanel1.Controls.Clear();
            foreach (Good i in MyGoods)
            {
                MyGood goodControl = new MyGood(this, i);
                flowLayoutPanel1.Controls.Add(goodControl);
            }

        }
        private void EditOrder(Order order)
        {
            order.Provider = tb_Provider.Text;
            order.AcceptNum = Convert.ToInt32(tb_AcceptNum.Text);
            order.OrderDate = dt_OrderDate.Value;
            order.ControlDate = dt_ControlDate.Value;
            order.Status = Convert.ToInt32(cb_Status.SelectedValue);
            order.PlaceCount = Convert.ToInt32(tb_PlaceCount.Text);
            using (UserContext db = new UserContext(Settings.constr))
            {
                db.Orders.Attach(order);
                var entry = db.Entry(order);
                entry.Property(x => x.Provider).IsModified = true;
                entry.Property(x => x.AcceptNum).IsModified = true;
                entry.Property(x => x.OrderDate).IsModified = true;
                entry.Property(x => x.ControlDate).IsModified = true;
                entry.Property(x => x.Status).IsModified = true;
                entry.Property(x => x.PlaceCount).IsModified = true;
                db.SaveChanges();

            }
        }


        public bool isValid()
        {
            if (tb_AcceptNum.Text == "" || tb_PlaceCount.Text == "" || tb_Provider.Text == "")
            {
                MessageBox.Show("Заполните все поля!");
                return false;
            }
            else return true;
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            

            if (Type==1 && isValid())
            {
                Order newOrder = new Order()
                {
                    Provider = tb_Provider.Text,
                    AcceptNum = Convert.ToInt32(tb_AcceptNum.Text),
                    AddDate = DateTime.Today,
                    OrderDate = dt_OrderDate.Value,
                    Status = Convert.ToInt32(cb_Status.SelectedValue),
                    ControlDate = dt_ControlDate.Value,
                    PlaceCount = Convert.ToInt32(tb_PlaceCount.Text)
                };
                using (UserContext db = new UserContext(Settings.constr))
                {
                    db.Orders.Add(newOrder);
                    db.SaveChanges();
                    OrderID = newOrder.ID;
                }
                MyOrder = newOrder;
                Type = 2;
                this.Text = "Редактирование заказа";
                MessageBox.Show("Заказ создан!");
                InitEditForm();
                (Sender as RepForm).BuildReport((Sender as RepForm).CurrentWeek);
                return;
                
            }
            if (Type == 2 && isValid())
            {
                EditOrder(MyOrder);
                InitEditForm();
                (Sender as RepForm).BuildReport((Sender as RepForm).CurrentWeek);
                MessageBox.Show("Изменено!");
                return;
            }
        }

        private void EditForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            int cnt;
            if (MyOrder!=null)
            {
                using (UserContext db = new UserContext(Settings.constr))
                {
                    cnt = db.Goods.Where(x => x.OrderID == MyOrder.ID).ToList().Count;
                }
                if (MyOrder.PlaceCount < cnt)
                {
                    MessageBox.Show("Введенное количество грузов не совпадает с количеством добавленных грузов!");
                    e.Cancel = true;
                    return;
                }
                (Sender as RepForm).BuildReport((Sender as RepForm).CurrentWeek);
            }
           
        }
    }
}
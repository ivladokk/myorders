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
using MyOrders.Dictionaries;

namespace MyOrders
{
    public partial class EditForm : DevExpress.XtraEditors.XtraForm,IEditForm
    {
        public Order MyOrder;
        public int Type;
        public int OrderID;
        public List<Good> MyGoods;
        object Sender;

        private bool needToUpdateProvider = false;

        public EditForm(Order order,int type, object sender)
        {
            InitializeComponent();
            if (type == 2)
                needToUpdateProvider = order.ProviderID == null;



            tb_AcceptNum.KeyPress += OnlyDigits;
            tb_PlaceCount.KeyPress += OnlyDigits;


            Sender = sender;
            LoadAgents();


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

            cb_Provider.Properties.DisplayMember = "Name";
            cb_Provider.Properties.ValueMember = "ContrAgentID";
            cb_Provider.Properties.DataSource = Contragents;
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
        private void btn_AddAgent_Click(object sender, EventArgs e)
        {
            EditDictionaryForm f = new EditDictionaryForm(null, 3, this);
            f.Show();
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
            cb_Contragent.EditValue = MyOrder.ContrAgentID;
            tb_NumberKP.Text = MyOrder.NumberKP;
            if (needToUpdateProvider)
                label8.Text = $"Поставщик: {MyOrder.Provider}";
            else cb_Provider.EditValue = MyOrder.ProviderID;
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
            order.ContrAgentID = Convert.ToInt32(cb_Contragent.EditValue);
            order.NumberKP = tb_NumberKP.Text;
            order.ProviderID = Convert.ToInt32(cb_Provider.EditValue);
            order.AcceptNum = Convert.ToInt32(tb_AcceptNum.Text);
            order.OrderDate = dt_OrderDate.Value;
            order.ControlDate = dt_ControlDate.Value;
            order.Status = Convert.ToInt32(cb_Status.SelectedValue);
            order.PlaceCount = Convert.ToInt32(tb_PlaceCount.Text);
            using (UserContext db = new UserContext(Settings.constr))
            {
                db.Orders.Attach(order);
                var entry = db.Entry(order);
                entry.Property(x => x.ContrAgentID).IsModified = true;
                entry.Property(x => x.NumberKP).IsModified = true;
                entry.Property(x => x.ProviderID).IsModified = true;
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

            if (needToUpdateProvider && cb_Provider.EditValue == null)
            {
                MessageBox.Show("Выберите поставщика из справочника!");
                return false;
            }

            if (cb_Contragent.EditValue == null|| tb_AcceptNum.Text == "" || tb_PlaceCount.Text == "" || cb_Provider.EditValue == null)
            {
                MessageBox.Show("Заполните все поля!");
                return false;
            }
            return true;
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            

            if (Type==1 && isValid())
            {
                Order newOrder = new Order()
                {
                    ContrAgentID = Convert.ToInt32(cb_Contragent.EditValue),
                    NumberKP = tb_NumberKP.Text,
                    ProviderID = Convert.ToInt32(cb_Provider.EditValue),
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
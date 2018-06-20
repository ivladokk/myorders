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
using AppCore.Settings;
using AppCore.Models;
using DevExpress.XtraEditors;

namespace CalculationModule.UI
{
    
    public partial class CalculationSettings : XtraForm
    {
        private int _mode;
        private List<CalculationType> Types = new List<CalculationType>();
        public List<CalculationItem> Items = new List<CalculationItem>();
        public List<CalculationConstant> Constants = new List<CalculationConstant>();
        public List<DynamicConstant> Dynamics = new List<DynamicConstant>();

        public List<OrderViewModel> Orders = new List<OrderViewModel>();


        public int currentTypeID;
        private bool typesLoaded = false;

        public CalculationSettings()
        {
            InitializeComponent();
            LoadTypes();
            Init();
        }

        private void LoadTypes()
        {
            using (UserContext db = new UserContext(Settings.constr))
            {
                Types = db.CalculationTypes.ToList();
            }

            if (Types.Count > 0)
            {
                BindingList<CalculationType> typesDS = new BindingList<CalculationType>();
                foreach (var i in Types)
                {
                    typesDS.Add(i);
                }

                cb_type.DisplayMember = "Name";
                cb_type.ValueMember = "ID";
                cb_type.DataSource = typesDS;
                currentTypeID = (int) cb_type.SelectedValue;
                typesLoaded = true;
                
            }
        }

        public void Init()
        {
            if (typesLoaded)
            {
                using (UserContext db = new UserContext(Settings.constr))
                {
                    Items = db.CalculationItems.Where(x => x.CalculationTypeID == currentTypeID).ToList();
                    Constants = db.CalculationConstants.Where(x => x.CalculationTypeID == currentTypeID).ToList();
                    Dynamics = db.DynamicConstants.Where(x => x.CalculationTypeID == currentTypeID).ToList();
                }

                LoadItemsGrid();
                LoadConstantsGrid();
                LoadDynamicsGrid();
            }
            
        }

        

        public List<OrderViewModel> CreateOrder()
        {
            int tempOrder = 0;
            List<OrderViewModel> list = new List<OrderViewModel>();
            foreach (var i in Items)
            {
                list.Add(new OrderViewModel
                {
                    ItemID = i.ID,
                    Type = 1,
                    Order = tempOrder,
                    Text = $"item {i.ItemName}"
                });
                tempOrder++;
                if (i.WithSum == 1)
                {
                    list.Add(new OrderViewModel
                    {
                        ItemID = i.ID,
                        Type = 3,
                        Order = tempOrder,
                        Text = $"sum {i.ItemName}"
                    });
                    tempOrder++;
                }
            }

            foreach (var i in Dynamics)
            {

                list.Add(new OrderViewModel
                {
                    ItemID = i.ID,
                    Type = 2,
                    Order = tempOrder,
                    Text = $"dynamic {i.Name}"
                });
                tempOrder++;
            }




            return list;
        }


        public void CheckOrdersAndReloadIsNeed(List<CalculationOrder> order)
        {
            if (order.Count != CreateOrder().Count)
            {
                foreach (var i in order)
                {
                    if (!Orders.Any(x => x.ItemID == i.ItemID && x.Type == i.ItemType))
                    {
                        Orders.Add(new OrderViewModel
                        {
                            ItemID = i.ItemID,
                            Order = i.Order,
                            Type = i.ItemType,
                            Text = GetOrderText(i.ItemType, i.ItemID)
                        });
                    }
                   
                }
                foreach (var i in Items)
                {
                    if (!Orders.Any(x => x.ItemID == i.ID && x.Type == 1))
                    {
                        Orders.Add(new OrderViewModel
                        {
                            ItemID = i.ID,
                            Type = 1,
                            Order = Orders.Max(x => x.Order) + 1,
                            Text = $"item {i.ItemName}"
                        });
                        if (i.WithSum == 1)
                        {
                            Orders.Add(new OrderViewModel
                            {
                                ItemID = i.ID,
                                Type = 3,
                                Order = Orders.Max(x => x.Order) + 1,
                                Text = $"sum {i.ItemName}"
                            });
                        }
                    }
                }

                foreach (var i in Dynamics)
                {
                    if (!Orders.Any(x => x.ItemID == i.ID && x.Type == 2))
                    {
                        Orders.Add(new OrderViewModel
                        {
                            ItemID = i.ID,
                            Type = 2,
                            Order = Orders.Max(x => x.Order) + 1,
                            Text = $"dynamic {i.Name}"
                        });
                    }
                }
            }
            else
            {
                foreach (var i in order)
                {
                    Orders.Add(new OrderViewModel
                    {
                        ItemID = i.ItemID,
                        Order = i.Order,
                        Type = i.ItemType,
                        Text = GetOrderText(i.ItemType, i.ItemID)
                    });
                }
            }
        }

        public void LoadOrderList()
        {
            lb_order.DataSource = null;
            

            List<CalculationOrder> ordersFromDB = new List<CalculationOrder>();

            using (UserContext db = new UserContext(Settings.constr))
            {
                ordersFromDB = db.CalculationOrders.Where(x => x.CalculationTypeID == currentTypeID)
                    .OrderBy(x => x.Order)
                    .ToList();
            }

            if (Orders.Count == 0)
            {
                if (ordersFromDB.Count == 0)
                {
                    Orders = CreateOrder();
                }
                else CheckOrdersAndReloadIsNeed(ordersFromDB);
                
            }
            else CheckOrdersAndReloadIsNeed(ordersFromDB);

            BindingList<OrderViewModel> ordersDS = new BindingList<OrderViewModel>();
            foreach (var i in Orders.OrderBy(x => x.Order))
            {
                ordersDS.Add(i);
            }

            lb_order.DisplayMember = "Text";
            lb_order.ValueMember = "Order";
            lb_order.DataSource = ordersDS;
        }

        private string GetOrderText(int type, int id)
        {
            if (type == 1)
                return $"item {Items.FirstOrDefault(x => x.ID == id).ItemName}";
            if (type == 2)
                return $"dynamic {Dynamics.FirstOrDefault(x => x.ID == id).Name}";
            if (type == 3)
                return $"sum {Items.FirstOrDefault(x => x.ID == id).ItemName}";
            return "";
        }

        private void LoadItemsGrid()
        {
            dataGridView1.Rows.Clear();
            for (int i = 0; i < Items.Count; i++)
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Tag = Items[i].ID;
                dataGridView1["ID", i] = new DataGridViewTextBoxCell
                {
                    Value = Items[i].ID
                };
                dataGridView1["ItemName", i] = new DataGridViewTextBoxCell
                {
                    Value = Items[i].ItemName
                };
                dataGridView1["Expression", i] = new DataGridViewTextBoxCell
                {
                    Value = Items[i].Expression
                };
            }
        }

        private void LoadConstantsGrid()
        {
            dataGridView2.Rows.Clear();
            for (int i = 0; i < Constants.Count; i++)
            {
                dataGridView2.Rows.Add();
                dataGridView2.Rows[i].Tag = Constants[i].ID;
                dataGridView2["K_ID", i] = new DataGridViewTextBoxCell
                {
                    Value = Constants[i].ID
                };
                dataGridView2["ConstantName", i] = new DataGridViewTextBoxCell
                {
                    Value = Constants[i].Name
                };
                dataGridView2["ConstantType", i] = new DataGridViewTextBoxCell
                {
                    Value = Constants[i].ConstantType
                };
                dataGridView2["Value", i] = new DataGridViewTextBoxCell
                {
                    Value = Constants[i].Value
                };
            }
        }

        private void LoadDynamicsGrid()
        {
            dataGridView3.Rows.Clear();
            for (int i = 0; i < Dynamics.Count; i++)
            {
                dataGridView3.Rows.Add();
                dataGridView3.Rows[i].Tag = Dynamics[i].ID;
                dataGridView3["D_ID", i] = new DataGridViewTextBoxCell
                {
                    Value = Dynamics[i].ID
                };
                dataGridView3["DynamicName", i] = new DataGridViewTextBoxCell
                {
                    Value = Dynamics[i].Name
                };
                dataGridView3["DynamicExpression", i] = new DataGridViewTextBoxCell
                {
                    Value = Dynamics[i].Expression
                };
            }
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            _mode = 1;
            CalculationTypeName f = new CalculationTypeName("", 1);
            if (f.ShowDialog(this) == DialogResult.OK)
            {
                using (UserContext db = new UserContext(Settings.constr))
                {

                    db.CalculationTypes.Add(new CalculationType {Name = f.result});
                    db.SaveChanges();
                }
                LoadTypes();
                Init();
            }
        }

        private void btn_Edit_Click(object sender, EventArgs e)
        {
            _mode = 2;
            string name = "";
            using (UserContext db = new UserContext(Settings.constr))
            {
               name = db.CalculationTypes.FirstOrDefault(x => x.ID == currentTypeID).Name;
            }

            CalculationTypeName f = new CalculationTypeName(name, 2);
            if (f.ShowDialog(this) == DialogResult.OK)
            {
                using (UserContext db = new UserContext(Settings.constr))
                {
                    var type = db.CalculationTypes.FirstOrDefault(x => x.ID == currentTypeID);
                    type.Name = f.result;
                    db.CalculationTypes.Attach(type);
                    var entry = db.Entry(type);
                    entry.Property(x => x.Name).IsModified = true;
                    db.SaveChanges();
                }
                LoadTypes();
                Init();
            }
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            using (UserContext db = new UserContext(Settings.constr))
            {
                var type = db.CalculationTypes.FirstOrDefault(x => x.ID == currentTypeID);
                if (type!=null)
                    db.CalculationTypes.Remove(type);
                db.SaveChanges();
            }
        }

        private void cb_type_SelectedValueChanged(object sender, EventArgs e)
        {
            if (typesLoaded)
            {
                currentTypeID = Convert.ToInt32(cb_type.SelectedValue);
                Init();
            }
                
        }

        private void RemoveFromOrder(int type, int id)
        {
            using (UserContext db = new UserContext(Settings.constr))
            {
                var item = db.CalculationOrders.FirstOrDefault(x => x.CalculationTypeID == currentTypeID && x.ItemType == type && x.ItemID == id);
                if (item != null)
                {
                    int order = item.Order;
                    db.CalculationOrders.Remove(item);
                    var left = db.CalculationOrders.Where(x => x.CalculationTypeID == currentTypeID && x.Order > order)
                        .ToList();
                    foreach (var i in left)
                    {
                        i.Order--;
                    }

                    db.SaveChanges();
                    Orders.Clear();
                }
            }
        }

        private void добавитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CalculationItemForm f = new CalculationItemForm(this, 1, null);
            f.ShowDialog();
        }

        private void изменитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow.Tag != null)
            {
                var id = Convert.ToInt32(dataGridView1.CurrentRow.Tag);
                using (UserContext db = new UserContext(Settings.constr))
                {
                    var item = db.CalculationItems.FirstOrDefault(x => x.ID == id);
                    CalculationItemForm f = new CalculationItemForm(this, 2, item);
                    f.ShowDialog();
                }
            }
                
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow.Tag != null)
            {
                var id = Convert.ToInt32(dataGridView1.CurrentRow.Tag);
                using (UserContext db = new UserContext(Settings.constr))
                {
                    var item = db.CalculationItems.FirstOrDefault(x => x.ID == id);
                    RemoveFromOrder(1, id);
                    if (item.WithSum == 1)
                        RemoveFromOrder(3, id);
                    db.CalculationItems.Remove(item);
                    db.SaveChanges();
                    
                    Init();
                }
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CalculationConstantForm f = new CalculationConstantForm(this, 1, null);
            f.ShowDialog();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (dataGridView2.CurrentRow.Tag != null)
            {
                var id = Convert.ToInt32(dataGridView2.CurrentRow.Tag);
                using (UserContext db = new UserContext(Settings.constr))
                {
                    var item = db.CalculationConstants.FirstOrDefault(x => x.ID == id);
                    CalculationConstantForm f = new CalculationConstantForm(this, 2, item);
                    f.ShowDialog();
                }
            }
        }

        private void добавитьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CalculationDynamicForm f = new CalculationDynamicForm(this, 1, null);
            f.ShowDialog();
        }

        private void изменитьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (dataGridView3.CurrentRow.Tag != null)
            {
                var id = Convert.ToInt32(dataGridView3.CurrentRow.Tag);
                using (UserContext db = new UserContext(Settings.constr))
                {
                    var item = db.DynamicConstants.FirstOrDefault(x => x.ID == id);
                    CalculationDynamicForm f = new CalculationDynamicForm(this, 2, item);
                    f.ShowDialog();
                }
            }
        }

        private void btn_up_Click(object sender, EventArgs e)
        {
            if (lb_order.SelectedValue != null)
            {
                int curOrder = lb_order.SelectedIndex;
                var curItem = Orders.FirstOrDefault(x => x.Order == curOrder);
                var prevItem = Orders.FirstOrDefault(x => x.Order == curOrder - 1);
                curItem.Order--;
                prevItem.Order++;
                LoadOrderList();
                lb_order.SelectedIndex = curItem.Order;
            }
        }

        private void btn_down_Click(object sender, EventArgs e)
        {
            if (lb_order.SelectedValue != null)
            {
                int curOrder = lb_order.SelectedIndex;
                var curItem = Orders.FirstOrDefault(x => x.Order == curOrder);
                var nextItem = Orders.FirstOrDefault(x => x.Order == curOrder + 1);
                curItem.Order++;
                nextItem.Order--;
                LoadOrderList();
                lb_order.SelectedIndex = curItem.Order;
            }
        }

        private void btn_loadorder_Click(object sender, EventArgs e)
        {
            LoadOrderList();
        }

        private void btn_saveorder_Click(object sender, EventArgs e)
        {
            if (Orders.Count > 0)
            {
                List<CalculationOrder> list = new List<CalculationOrder>();
                foreach (var i in Orders)
                {
                    list.Add(new CalculationOrder
                    {
                        CalculationTypeID = currentTypeID,
                        ItemID = i.ItemID,
                        ItemType = i.Type,
                        Order = i.Order
                    });
                }

                using (UserContext db = new UserContext(Settings.constr))
                {
                    foreach (var i in db.CalculationOrders.Where(x => x.CalculationTypeID == currentTypeID))
                    {
                        db.CalculationOrders.Remove(i);
                    }

                    db.CalculationOrders.AddRange(list);
                    db.SaveChanges();


                }
            }
            
        }

        private void lb_order_SelectedIndexChanged(object sender, EventArgs e)
        {
            btn_up.Enabled = lb_order.SelectedIndex != 0;
            btn_down.Enabled = lb_order.SelectedIndex != lb_order.Items.Count - 1;
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            if (dataGridView2.CurrentRow.Tag != null)
            {
                var id = Convert.ToInt32(dataGridView2.CurrentRow.Tag);
                using (UserContext db = new UserContext(Settings.constr))
                {
                    var item = db.CalculationConstants.FirstOrDefault(x => x.ID == id);
                    db.CalculationConstants.Remove(item);
                    db.SaveChanges();
                    Init();
                }
            }
        }

        private void удалитьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (dataGridView3.CurrentRow.Tag != null)
            {
                var id = Convert.ToInt32(dataGridView3.CurrentRow.Tag);
                using (UserContext db = new UserContext(Settings.constr))
                {
                    var item = db.DynamicConstants.FirstOrDefault(x => x.ID == id);
                    RemoveFromOrder(2, id);
                    db.DynamicConstants.Remove(item);
                    db.SaveChanges();
                    RemoveFromOrder(1, id);
                    Init();
                }
            }
        }
    }

    public class OrderViewModel
    {
        public string Text { get; set; }
        public int ItemID { get; set; }
        public int Type { get; set; }
        public int Order { get; set; }
    }
}

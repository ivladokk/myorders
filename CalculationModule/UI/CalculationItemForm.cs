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
using DevExpress.XtraEditors;

namespace CalculationModule.UI
{
    public partial class CalculationItemForm : XtraForm
    {
        private CalculationSettings _sender;
        private int _type;
        private CalculationItem _editModel = new CalculationItem();
        public CalculationItemForm(CalculationSettings sender, int type, CalculationItem editItem )
        {
            InitializeComponent();
            _sender = sender;
            _type = type;
            if (_type == 2)
            {
                _editModel = editItem;
                checkBox1.Checked = _editModel.WithSum == 1;
                checkBox2.Checked = _editModel.NeedRound == 1;
            }
            
            LoadLists();
            tb_name.DataBindings.Add("Text", _editModel, "ItemName");
            tb_value.DataBindings.Add("Text", _editModel, "Expression");
        }

        private void LoadLists()
        {
            BindingList<CalculationItemViewModel> itemsDS = new BindingList<CalculationItemViewModel>();
            foreach (var i in _sender.Items)
            {
                CalculationItemViewModel item = new CalculationItemViewModel
                {
                    ID = i.ID,
                    Name = i.ItemName,
                    isSum = false
                };
                itemsDS.Add(item);
                if (i.WithSum == 1)
                {
                    CalculationItemViewModel itemWithSum = new CalculationItemViewModel
                    {
                        ID = i.ID,
                        Name = i.ItemName + "[sum]",
                        isSum = true
                    };
                    itemsDS.Add(itemWithSum);
                }
            }

            lb_items.DisplayMember = "Name";
            lb_items.ValueMember = "ID";
            lb_items.DataSource = itemsDS;

            BindingList<CalculationConstant> constantsDS = new BindingList<CalculationConstant>();
            foreach (var i in _sender.Constants)
            {
                constantsDS.Add(i);
            }

            lb_constants.DisplayMember = "Name";
            lb_constants.ValueMember = "ID";
            lb_constants.DataSource = constantsDS;

            Dictionary<string,string> attrsDS = new Dictionary<string, string>();
            attrsDS.Add("price","Цена");
            attrsDS.Add("count","Кол-во");
            attrsDS.Add("TNVEDCode", "Код ТНВЭД");
            attrsDS.Add("TNVEDValue", "Ставка ТНВЭД");
            attrsDS.Add("Additional", "Доп. значение");
            lb_attrs.DisplayMember = "Value";
            lb_attrs.ValueMember = "Key";
            lb_attrs.DataSource = new BindingSource(attrsDS, null);


            BindingList<DynamicConstant> dynamicDS = new BindingList<DynamicConstant>();
            foreach (var i in _sender.Dynamics)
            {
                dynamicDS.Add(i);
                
            }
            lb_dynamics.DisplayMember = "Name";
            lb_dynamics.ValueMember = "ID";
            lb_dynamics.DataSource = dynamicDS;


           

        }

        private void lb_items_DoubleClick(object sender, EventArgs e)
        {

            if (!(lb_items.SelectedItem as CalculationItemViewModel).isSum)
            {
                tb_value.Text += $"item[{lb_items.SelectedValue}]";
            }
            else
            {
                tb_value.Text += $"sum[{lb_items.SelectedValue}]";
            }
            
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            _editModel.Expression = tb_value.Text;
            if (_type == 1)
            {
                _editModel.OrderID = 1;
                _editModel.CalculationTypeID = _sender.currentTypeID;
                _editModel.WithSum = checkBox1.Checked ? 1 : 0;
                _editModel.NeedRound = checkBox2.Checked ? 1 : 0;
                using (UserContext db = new UserContext(Settings.constr))
                {
                    db.CalculationItems.Add(_editModel);
                    db.SaveChanges();
                }
                _sender.Init();
                Close();
                return;
            }

            if (_type == 2)
            {
                _editModel.WithSum = checkBox1.Checked ? 1 : 0;
                _editModel.NeedRound = checkBox2.Checked ? 1 : 0;
                using (UserContext db = new UserContext(Settings.constr))
                {
                    db.CalculationItems.Attach(_editModel);
                    var entry = db.Entry(_editModel);
                    entry.Property(x => x.Expression).IsModified = true;
                    entry.Property(x => x.ItemName).IsModified = true;
                    entry.Property(x => x.OrderID).IsModified = true;
                    entry.Property(x => x.NeedRound).IsModified = true;
                    entry.Property(x => x.WithSum).IsModified = true;
                    db.SaveChanges();
                }
                _sender.Init();
                Close();
            }
            
        }

        private void lb_constants_DoubleClick(object sender, EventArgs e)
        {
            tb_value.Text += $"constant[{lb_constants.SelectedValue}]";
        }

        private void lb_attrs_DoubleClick(object sender, EventArgs e)
        {
            tb_value.Text += $"{lb_attrs.SelectedValue}";
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lb_dynamics_DoubleClick(object sender, EventArgs e)
        {
            tb_value.Text += $"dynamic[{lb_dynamics.SelectedValue}]";
        }
    }



    public class CalculationItemViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public bool isSum { get; set; }

    }
}

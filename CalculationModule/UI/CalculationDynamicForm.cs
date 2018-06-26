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
    public partial class CalculationDynamicForm : XtraForm
    {
        private CalculationSettings _sender;
        private int _type;
        private DynamicConstant _editModel = new DynamicConstant();
        public CalculationDynamicForm(CalculationSettings sender, int type, DynamicConstant editItem)
        {
            _sender = sender;
            _type = type;
            if (_type==2)
                _editModel = editItem;
            InitializeComponent();
            LoadLists();
            tb_name.DataBindings.Add("Text", _editModel, "Name");
            tb_express.DataBindings.Add("Text", _editModel, "Expression");
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

            Dictionary<string, string> attrsDS = new Dictionary<string, string>();
            attrsDS.Add("price", "Цена");
            attrsDS.Add("count", "Кол-во");
            attrsDS.Add("TNVEDCode", "Код ТНВЭД");
            attrsDS.Add("TNVEDValue", "Ставка ТНВЭД");
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
        private void btn_save_Click(object sender, EventArgs e)
        {
            if (_type == 1)
            {
                _editModel.CalculationTypeID = _sender.currentTypeID;
                using (UserContext db = new UserContext(Settings.constr))
                {
                    db.DynamicConstants.Add(_editModel);
                    db.SaveChanges();
                }
                _sender.Init();
                Close();
                return;
            }

            if (_type == 2)
            {
                using (UserContext db = new UserContext(Settings.constr))
                {
                    db.DynamicConstants.Attach(_editModel);
                    var entry = db.Entry(_editModel);
                    entry.Property(x => x.Expression).IsModified = true;
                    entry.Property(x => x.Name).IsModified = true;
                    db.SaveChanges();
                }
                _sender.Init();
                Close();
            }
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lb_items_DoubleClick(object sender, EventArgs e)
        {
            if (!(lb_items.SelectedItem as CalculationItemViewModel).isSum)
            {
                tb_express.Text += $"item[{lb_items.SelectedValue}]";
            }
            else
            {
                tb_express.Text += $"sum[{lb_items.SelectedValue}]";
            }
        }

        private void lb_constants_DoubleClick(object sender, EventArgs e)
        {
            tb_express.Text += $"constant[{lb_constants.SelectedValue}]";
        }

        private void lb_attrs_DoubleClick(object sender, EventArgs e)
        {
            tb_express.Text += $"{lb_attrs.SelectedValue}";
        }

        private void lb_dynamics_DoubleClick(object sender, EventArgs e)
        {
            tb_express.Text += $"dynamic[{lb_dynamics.SelectedValue}]";
        }
    }
}

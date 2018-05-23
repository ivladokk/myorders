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

namespace CalculationModule.UI
{

    public partial class CalculationConstantForm : Form
    {
        private CalculationSettings _sender;
        private CalculationConstant _editModel = new CalculationConstant();
        private int _type;
        public CalculationConstantForm(CalculationSettings sender, int type, CalculationConstant item)
        {
            InitializeComponent();
            _type = type;
            if (type == 2)
                _editModel = item;
            _sender = sender;
            Dictionary<int,string> constTypes = new Dictionary<int, string>();
            constTypes.Add(1,"Постоянная");
            constTypes.Add(2, "Ручная");
            cb_type.DisplayMember = "Value";
            cb_type.ValueMember = "Key";
            cb_type.DataSource = new BindingSource(constTypes, null);

            tb_name.DataBindings.Add("Text", _editModel, "Name");
            tb_value.DataBindings.Add("Text", _editModel, "Value");
            cb_type.DataBindings.Add("SelectedValue", _editModel, "ConstantType");


        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            if (_type == 1)
            {
                _editModel.CalculationTypeID = _sender.currentTypeID;
                using (UserContext db = new UserContext(Settings.constr))
                {
                    db.CalculationConstants.Add(_editModel);
                    db.SaveChanges();
                }
                _sender.Init();
                this.Close();
                return;
            }

            if (_type == 2)
            {
                using (UserContext db = new UserContext(Settings.constr))
                {
                    db.CalculationConstants.Attach(_editModel);
                    var entry = db.Entry(_editModel);
                    entry.Property(x => x.ConstantType).IsModified = true;
                    entry.Property(x => x.Name).IsModified = true;
                    entry.Property(x => x.Value).IsModified = true;
                    db.SaveChanges();
                }
                _sender.Init();
                Close();
            }
        }

    }
}

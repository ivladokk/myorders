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
            tb_name.DataBindings.Add("Text", _editModel, "Name");
            tb_express.DataBindings.Add("Text", _editModel, "Expression");
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
    }
}

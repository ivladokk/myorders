using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AppCore;
using AppCore.Models;
using AppCore.Settings;

namespace CalculationModule.UI.MasterPages
{
    public partial class Page1 : UserControl
    {
        public int SelectedTypeID { get; set; }
        public string CalcName { get; set; }
        public int ContrAgentID { get; set; }
        public Page1()
        {
            InitializeComponent();
           
            LoadTypes();
            LoadAgents();

            

        }

        private bool isLoaded = false;
        public void LoadTypes()
        {
            using (UserContext db = new UserContext(Settings.constr))
            {
                var types = db.CalculationTypes.ToList();
                BindingList<CalculationType> ds = new BindingList<CalculationType>();
                foreach (var i in types)
                {
                    ds.Add(i);
                }

                cb_type.DisplayMember = "Name";
                cb_type.ValueMember = "ID";
                cb_type.DataSource = ds;
                isLoaded = true;
                SelectedTypeID = (int) cb_type.SelectedValue;
                tb_name.DataBindings.Add("Text", this, "CalcName");
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
            //ContrAgentID = (int) cb_Contragent.EditValue;
            cb_Contragent.DataBindings.Add("EditValue", this, "ContrAgentID");
        }

        private void cb_type_SelectedValueChanged(object sender, EventArgs e)
        {
            if (isLoaded)
            {
                SelectedTypeID = Convert.ToInt32(cb_type.SelectedValue);
            }
        }
    }
}

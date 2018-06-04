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

namespace Offers.UI.MasterPage
{
    public partial class Page1 : UserControl
    {
        public string  OfferName { get; set; }
        public int ContrAgentID { get; set; }
        public Page1()
        {
            InitializeComponent();

            LoadAgents();
            tb_name.DataBindings.Add("Text", this, "OfferName");
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
    }
}

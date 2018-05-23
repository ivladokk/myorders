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
    public partial class Page3 : UserControl
    {
        private CalculationInstance _instance;
        public List<CalculationConstant> ManualConstants;
        public Page3(CalculationInstance instance)
        {
            InitializeComponent();
            _instance = instance;
            GetManualConstatns();
        }

        public void GetManualConstatns()
        {
            using (UserContext db = new UserContext(Settings.constr))
            {
                ManualConstants = db.CalculationConstants
                    .Where(x => x.CalculationTypeID == _instance.CalculationTypeID && x.ConstantType == 2).ToList();

                foreach (var i in ManualConstants)
                {
                    var box = new GroupBox();
                    box.Text = i.Name;
                    box.Width = 180;
                    box.Height = 45;
                    var tb = new TextBox();
                    tb.Name = $"Constant{i.ID}";
                    tb.Dock = DockStyle.Fill;
                    tb.DataBindings.Add("Text", i, "Value");
                    box.Controls.Add(tb);
                    flowLayoutPanel1.Controls.Add(box);
                }
            }

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}

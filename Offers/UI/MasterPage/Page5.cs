using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Offers.UI.MasterPage
{
    public partial class Page5 : UserControl
    {
        public bool Print { get; set; }
        public Page5()
        {
            InitializeComponent();
            checkBox1.DataBindings.Add("Checked", this, "Print");
        }
    }
}

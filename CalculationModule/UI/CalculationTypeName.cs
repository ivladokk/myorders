using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculationModule.UI
{
    public partial class CalculationTypeName : Form
    {
        private string _oldName = "";
        private int _type;
        public string result = "";
        public CalculationTypeName(string oldName, int type)
        {
            InitializeComponent();
            if (type == 2)
                _oldName = oldName;
            tb_name.Text = _oldName;
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            result = tb_name.Text;
            this.DialogResult = DialogResult.OK;
        }
    }
}

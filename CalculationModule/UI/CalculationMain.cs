using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using AppCore.Models;


namespace CalculationModule.UI
{
    public partial class CalculationMain : Form
    {
        public CalculationMain()
        {
            InitializeComponent();

            CalculationCreateForm f = new CalculationCreateForm();
            f.Show();
            f.Focus();

        }  
    }
}

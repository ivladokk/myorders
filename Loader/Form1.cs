using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Loader
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ReadConfig();
        }

        private void ReadConfig()
        {
            var connectionsXml = new XmlDocument();
            connectionsXml.Load(@"connections.xml");
            Dictionary<string,string> connections = new Dictionary<string, string>();
            foreach (XmlNode i in connectionsXml["root"].ChildNodes)
            {
                connections.Add(i["name"].InnerText, i["constr"].InnerText);
            }
            var ds = new BindingSource(connections, null);
            comboBox1.DisplayMember = "Key";
            comboBox1.ValueMember = "Value";
            comboBox1.DataSource = ds;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //AppCore.Settings.Settings.constr = comboBox1.SelectedValue.ToString();
            System.Diagnostics.Process.Start("myorders.exe", comboBox1.SelectedValue.ToString());
            Close();

        }
    }
}

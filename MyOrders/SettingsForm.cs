using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Xml;
using AppCore.Settings;

namespace MyOrders
{
    public partial class SettingsForm : DevExpress.XtraEditors.XtraForm
    {
        public SettingsForm()
        {
            InitializeComponent();
            var settingsXml = new XmlDocument();
            settingsXml.Load(@"settings.xml");
            tb_CurrentYear.Text = settingsXml["root"]["currentYear"].InnerText;
            tb_MaxHeight.Text = settingsXml["root"]["maxHeight"].InnerText;
            tb_MaxWidth.Text = settingsXml["root"]["maxWidth"].InnerText;
            tb_MaxLenght.Text = settingsXml["root"]["maxLenght"].InnerText;
            tb_pxSize.Text = settingsXml["root"]["pxSize"].InnerText;
            tb_realSize.Text = settingsXml["root"]["realSize"].InnerText;
            isShowWeekend.Checked = Convert.ToBoolean(settingsXml["root"]["isShowWeekends"].InnerText);

        }

        private void button1_Click(object sender, EventArgs e)
        {

            var settingsXml = new XmlDocument();
            settingsXml.Load(@"settings.xml");
            settingsXml["root"]["currentYear"].InnerText = tb_CurrentYear.Text;
            settingsXml["root"]["maxHeight"].InnerText = tb_MaxHeight.Text;
            settingsXml["root"]["maxWidth"].InnerText = tb_MaxWidth.Text;
            settingsXml["root"]["maxLenght"].InnerText = tb_MaxLenght.Text;
            settingsXml["root"]["pxSize"].InnerText = tb_pxSize.Text;
            settingsXml["root"]["realSize"].InnerText = tb_realSize.Text;
            settingsXml["root"]["isShowWeekends"].InnerText = isShowWeekend.Checked.ToString();
            System.IO.File.WriteAllText(@"settings.xml", settingsXml.InnerXml);


            Settings.currentYear = Convert.ToInt32(tb_CurrentYear.Text);
            Settings.maxWidth = Convert.ToInt32(tb_MaxWidth.Text);
            Settings.maxHeight = Convert.ToInt32(tb_MaxHeight.Text);
            Settings.maxLenght = Convert.ToInt32(tb_MaxLenght.Text);
            Settings.pxSize = Convert.ToInt32(tb_pxSize.Text);
            Settings.realSize = Convert.ToInt32(tb_realSize.Text);
            Settings.scale = Settings.pxSize / Settings.realSize;
            Settings.isShowWeekends = isShowWeekend.Checked;
            this.Close();
            
        }
    }
}
using CalculationModule.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml.Linq;
using CalculationModule;

namespace MyOrders
{
    public partial class Form1 : DevExpress.XtraEditors.XtraForm
    {
        public Form1()
        {
            InitializeComponent();


            CultureInfo culture = new CultureInfo("ru-RU");
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;
            RepForm rep = new RepForm();


            rep.MdiParent = this;
            rep.WindowState = FormWindowState.Maximized;
            rep.Show();

        }

        private void доставкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RepForm rep = new RepForm();
            rep.MdiParent = this;
            rep.WindowState = FormWindowState.Maximized;
            rep.Show();
        }


        public void InitSettings()
        {
           
        }

        private void настройкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SettingsForm f = new SettingsForm();
            f.ShowDialog();
        }

        private void добавитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void закрытыеЗаказыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClosedReport rep = new ClosedReport();
            rep.MdiParent = this;
            rep.WindowState = FormWindowState.Maximized;
            rep.Show();
        }

        private void справочникиToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void контрагентыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dictionaries.Contragents f = new Dictionaries.Contragents();
            f.Show();                

        }

        public static object GetPropValue(object src, string propName)
        {
            return src.GetType().GetProperty(propName).GetValue(src, null);
        }

        private void платежиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Payments rep = new Payments();
            rep.MdiParent = this;
            rep.WindowState = FormWindowState.Maximized;
            rep.Show();
        }

        private void балансToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BalanceRepot f = new BalanceRepot();
            f.MdiParent = this;
            f.WindowState = FormWindowState.Maximized;
            f.Show();
        }

        private void отчетПоПлатежамToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PaymentsReport f = new PaymentsReport
            {
                MdiParent = this,
                WindowState = FormWindowState.Maximized
            };
            f.Show();
        }

        private void цветаПлатежейToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PaymentColorSettings f = new PaymentColorSettings();
            f.ShowDialog();
        }

        private void шаблоныПлатежейToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FuturePaymentsRep f = new FuturePaymentsRep
            {
                MdiParent = this,
                WindowState = FormWindowState.Maximized
            };
            f.Show();
        }

        private void валютыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditCurrency f = new EditCurrency();
            f.ShowDialog();
        }

        private void отчетПоДоставкамToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GoodsReport f = new GoodsReport();
            f.MdiParent = this;
            f.WindowState = FormWindowState.Maximized;
            f.Show();
        }

        private void создатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CalculationMain f = new CalculationMain
            {
                MdiParent = this,
                WindowState = FormWindowState.Maximized
            };
            f.Show();
        }

        private void настройкиToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CalculationSettings f = new CalculationSettings();
            f.ShowDialog();
        }

        private void справочникТоваровToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProductsDictionary f = new ProductsDictionary
            {
                MdiParent = this,
                WindowState = FormWindowState.Maximized
            };
            f.Show();
        }
    }
}

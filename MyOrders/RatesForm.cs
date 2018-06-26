using DevExpress.XtraEditors;
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

namespace MyOrders
{
    public partial class RatesForm : XtraForm
    {
        public WorkDay workDay;
        public List<Rate> Rates;
        public RatesForm(WorkDay workday)
        {
           InitializeComponent();
            workDay = workday;
            label1.Text = $"Курсы на {workDay.WorkDayDate.ToString("dd:MM:yyyy")}";

            Init();


        }

        public void Init()
        {
            flowLayoutPanel1.Controls.Clear();
            using (var db = new UserContext(Settings.constr))
            {
                Rates = db.Rates.Where(x => x.WorkDayID == workDay.WorkDayID).ToList();
            }
            foreach (var i in Rates)
            {
                RatesControl rc = new RatesControl(i, this);
                flowLayoutPanel1.Controls.Add(rc);
            }
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            RateAdd f = new RateAdd(workDay, this);
            f.ShowDialog();
        }
    }
}

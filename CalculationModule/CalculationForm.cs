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

namespace CalculationModule
{
    public partial class CalculationForm : Form
    {
        private CalculationInstance _instance;
        private CalculationWorker worker;
        public CalculationForm(CalculationInstance instance)
        {
            InitializeComponent();
            _instance = instance;
            worker = new CalculationWorker(_instance);
            LoadCalculation();

        }

        public void LoadCalculation()
        {
            gridControl1.DataSource = worker.GetDataTable();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
        private void excelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
            if (!String.IsNullOrEmpty(saveFileDialog1.FileName))
                gridControl1.ExportToXlsx(saveFileDialog1.FileName);
        }
    }
}

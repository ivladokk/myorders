using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using AppCore.Components;
using AppCore.Settings;
using CalculationModule;

namespace MyOrders
{
    public partial class CustomsData : Form
    {
        public MyGrid grid;
        public CustomsData()
        {
            InitializeComponent();
            MyGridSettings settings = new MyGridSettings();
            settings.ContextMenuItems = GetMenuItems();
            settings.AutoSizeColums = false;
            grid = new MyGrid(settings);
            grid.Dock = DockStyle.Fill;
            Controls.Add(grid);
            Init();
        }

        public void Init()
        {
            DataSet ds = new DataSet();
            try
            {

                using (SqlConnection conn = new SqlConnection(Settings.constr))
                {
                    SqlCommand cmd = new SqlCommand("GetCustomsInfo", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = cmd;
                    da.Fill(ds);
                }
                grid.SetDataTable(ds.Tables[0]);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private List<ToolStripMenuItem> GetMenuItems()
        {
            var ret = new List<ToolStripMenuItem>();
            ToolStripMenuItem importData = new ToolStripMenuItem
            {
                Name = "importData",
                Text = "Импорт",
            };
            importData.Click += ImportData_Click;
            ret.Add(importData);
            return ret;
        }

        private void ImportData_Click(object sender, EventArgs e)
        {
            CustomDataImportForm f = new CustomDataImportForm(this);
            f.ShowDialog();
        }

        

    }
}

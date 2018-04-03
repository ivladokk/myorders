using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace MyOrders
{
    public partial class GoodsReport : XtraForm
    {
        public GoodsReport()
        {
            InitializeComponent();
            DataSet ds = new DataSet();
            try
            {

                using (SqlConnection conn = new SqlConnection(Settings.constr))
                {
                    SqlCommand cmd = new SqlCommand("GoodsReport", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = cmd;
                    da.Fill(ds);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            gridControl1.DataSource = ds.Tables[0];
        }
        private void excelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
            if (!String.IsNullOrEmpty(saveFileDialog1.FileName))
                gridControl1.ExportToXlsx(saveFileDialog1.FileName);
        }
    }
}

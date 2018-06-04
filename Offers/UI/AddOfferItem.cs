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
using AppCore.Settings;

namespace Offers.UI
{
    public partial class AddOfferItem : Form
    {
        public int retValue { get; set; }
        public AddOfferItem()
        {
            InitializeComponent();
            LoadGrid();

        }

        public void LoadGrid()
        {
            DataSet ds = new DataSet();
            try
            {

                using (SqlConnection conn = new SqlConnection(Settings.constr))
                {
                    SqlCommand cmd = new SqlCommand("GetEquipmentsForOffer", conn);
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

        
        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            var current = gridView1.GetSelectedRows()[0];
            int id = Convert.ToInt32(gridView1.GetRowCellValue(current, "ID"));
            retValue = id;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}

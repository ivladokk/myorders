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

namespace MyOrders
{
    public partial class PaymentsReport : Form
    {
        public PaymentsReport()
        {
            InitializeComponent();

            DataSet ds = new DataSet();
            try
            {

                using (SqlConnection conn = new SqlConnection(Settings.constr))
                {
                    SqlCommand cmd = new SqlCommand("PaymentsReport", conn);
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


    }
}

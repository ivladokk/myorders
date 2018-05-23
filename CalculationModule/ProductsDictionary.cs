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

namespace CalculationModule
{
    public partial class ProductsDictionary : Form
    {
        public ProductsDictionary()
        {
            InitializeComponent();
            Load();
        }

        public void Load()
        {
            DataSet ds = new DataSet();
            try
            {

                using (SqlConnection conn = new SqlConnection(Settings.constr))
                {
                    SqlCommand cmd = new SqlCommand("GetProductsAttributes", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = cmd;
                    da.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void импортToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProductsImport f = new ProductsImport(this);
            f.ShowDialog();
        }
    }
}

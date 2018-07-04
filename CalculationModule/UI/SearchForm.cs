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
using AppCore;
using AppCore.Settings;
using DevExpress.XtraEditors;

namespace CalculationModule.UI
{
    public partial class SearchForm : XtraForm
    {

        public SearchForm()
        {
            InitializeComponent();

        }

        public void Search(int type, string par)
        {
            dataGridView1.DataSource = null;
            if (type == 1)
            {
                DataSet ds = new DataSet();
                try
                {

                    using (SqlConnection conn = new SqlConnection(Settings.constr))
                    {
                        SqlCommand cmd = new SqlCommand("FindCalculationItemByVendor", conn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@vendorcode", SqlDbType.NVarChar));
                        cmd.Parameters["@vendorcode"].Value = par;
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
            if (type == 2)
            {
                DataSet ds = new DataSet();
                try
                {

                    using (SqlConnection conn = new SqlConnection(Settings.constr))
                    {
                        SqlCommand cmd = new SqlCommand("FindCalculationItemByName", conn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@name", SqlDbType.NVarChar));
                        cmd.Parameters["@name"].Value = par;
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


        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                var id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                using (UserContext db = new UserContext(Settings.constr))
                {
                    var instance = db.CalculationInsctInstances.FirstOrDefault(x => x.ID == id);
                    CalculationForm f = new CalculationForm(instance);
                    f.MdiParent = this.MdiParent;
                    f.Show();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (vendorSearch.Checked)
                Search(1, textBox1.Text);
            if (nameSearch.Checked)
                Search(2, textBox1.Text);

        }
    }
}

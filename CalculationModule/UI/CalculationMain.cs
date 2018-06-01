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
using AppCore;
using AppCore.Models;
using AppCore.Settings;


namespace CalculationModule.UI
{
    public partial class CalculationMain : Form
    {
        public CalculationMain()
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
                    SqlCommand cmd = new SqlCommand("GetCalculationInstances", conn);
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

            dataGridView1.DataSource = ds.Tables[0];
        }

        private void создатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CalculationCreateForm f = new CalculationCreateForm(this);
            f.Show();
            f.Focus();
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                var id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["ID"].Value);
                using (UserContext db = new UserContext(Settings.constr))
                {
                    var instance = db.CalculationInsctInstances.FirstOrDefault(x => x.ID == id);
                    db.CalculationInsctInstances.Remove(instance);
                }
                Load();
            }
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                var id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["ID"].Value);
                using (UserContext db = new UserContext(Settings.constr))
                {
                    var instance = db.CalculationInsctInstances.FirstOrDefault(x => x.ID == id);
                    CalculationForm f = new CalculationForm(instance);
                    f.MdiParent = this.MdiParent;
                    f.Show();
                }
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                var id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["ID"].Value);
                using (UserContext db = new UserContext(Settings.constr))
                {
                    var instance = db.CalculationInsctInstances.FirstOrDefault(x => x.ID == id);
                    CalculationForm f = new CalculationForm(instance);
                    f.MdiParent = this.MdiParent;
                    f.Show();
                }
            }
        }
    }
}

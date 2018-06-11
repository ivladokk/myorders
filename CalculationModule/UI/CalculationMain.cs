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
            CreateStatusMenu();
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

        public void CreateStatusMenu()
        {
            using (UserContext db = new UserContext(Settings.constr))
            {
                var statuses = db.CalculationStatus.ToList();
                foreach (var i in statuses)
                {
                    ToolStripMenuItem item = new ToolStripMenuItem();
                    item.Text = i.StatusValue;
                    item.Tag = i.ID;
                    item.Click += status_click;
                    изменитьСтатусToolStripMenuItem.DropDownItems.Add(item);

                }
            }
            
            
        }

        private void status_click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                
                var id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["ID"].Value);
                SetStatus(id, Convert.ToInt32((sender as ToolStripMenuItem).Tag));
            }
        }

        private void SetStatus(int calcId, int status)
        {
            using (UserContext db = new UserContext(Settings.constr))
            {
                var calc = db.CalculationInsctInstances.FirstOrDefault(x => x.ID == calcId);
                calc.Status = status;
                db.SaveChanges();
                Load();
            }
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

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {

        }
    }
}

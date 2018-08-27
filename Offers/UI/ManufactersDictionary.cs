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
using AppCore.Models;
using AppCore.Settings;

namespace Offers.UI
{
    public partial class ManufactersDictionary : Form
    {
        public ManufactersDictionary()
        {
            InitializeComponent();
            Init();
        }

        public void Init()
        {
            DataSet ds = new DataSet();
            try
            {

                using (SqlConnection conn = new SqlConnection(Settings.constr))
                {
                    SqlCommand cmd = new SqlCommand("GetManufactersDictionary", conn);
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

        private void добавитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManufactersEdit f = new ManufactersEdit(null,this);
            f.ShowDialog();
        }

        private void изменитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                var id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["ID"].Value);
                using (UserContext db = new UserContext(Settings.constr))
                {
                    var manufacter = db.Manufacters.FirstOrDefault(x => x.ID == id);
                    ManufactersEdit f = new ManufactersEdit(manufacter,this);
                    f.ShowDialog();
                }
            }
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы уверены?", "Удаление", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (dataGridView1.CurrentRow != null)
                {
                    var id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["ID"].Value);
                    using (UserContext db = new UserContext(Settings.constr))
                    {
                        var manufacter = db.Manufacters.FirstOrDefault(x => x.ID == id);
                        db.Manufacters.Remove(manufacter);
                        db.SaveChanges();
                    }
                    Init();
                }
            }
               
        }
    }
}

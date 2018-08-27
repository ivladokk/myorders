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

namespace Offers.UI
{
    public partial class EquipmentDictionary : Form
    {
        public EquipmentDictionary()
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
                    SqlCommand cmd = new SqlCommand("GetEquipments", conn);
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

        private void орToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EquipmentEdit f = new EquipmentEdit(null, this);
            f.ShowDialog();
        }

        private void измнеитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                var id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["ID"].Value);
                using (UserContext db = new UserContext(Settings.constr))
                {
                    var equip = db.Equipments.FirstOrDefault(x => x.ID == id);
                    EquipmentEdit f = new EquipmentEdit(equip, this);
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
                        var equip = db.Equipments.FirstOrDefault(x => x.ID == id);
                        db.Equipments.Remove(equip);
                        db.SaveChanges();
                    }
                    Init();
                }
            }   
        }
    }
}

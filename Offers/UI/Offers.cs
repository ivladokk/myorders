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
    public partial class OffersMain : Form
    {
        public OffersMain()
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
                    SqlCommand cmd = new SqlCommand("GetAllOffers", conn);
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
            OfferCreateForm f = new OfferCreateForm(this);
            f.ShowDialog();
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                var id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["ID"].Value);
                using (UserContext db = new UserContext(Settings.constr))
                {
                    var offer = db.Offers.FirstOrDefault(x => x.ID == id);
                    if (offer != null)
                    {
                        db.Offers.Remove(offer);
                        db.SaveChanges();
                    }
                    
                }
            }
        }

        private void печатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                var id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["ID"].Value);
                using (UserContext db = new UserContext(Settings.constr))
                {
                    var offer = db.Offers.FirstOrDefault(x => x.ID == id);
                    if (offer != null)
                    {
                        OfferWorker worker = new OfferWorker(offer);
                        worker.Print();
                    }
                        
                }
            }
        }
    }
    
}

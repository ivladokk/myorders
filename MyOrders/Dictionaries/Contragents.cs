using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AppCore;
using AppCore.Settings;

namespace MyOrders.Dictionaries
{
    public partial class Contragents : Form
    {
        public Contragents()
        {
            InitializeComponent();
            Init();

        }


        public void Init()
        {
            dataGridView1.Rows.Clear();
            using (UserContext db = new UserContext(Settings.constr))
            {
                var contragents = db.Contragents.ToList();
                if (contragents.Count == 0) return;

                for (int i = 0; i < contragents.Count; i++)
                {
                    dataGridView1.Rows.Add();
                    dataGridView1["ContragentName", i] = new DataGridViewTextBoxCell()
                    {
                        Value = contragents[i].Name
                    };
                    dataGridView1["Address", i] = new DataGridViewTextBoxCell()
                    {
                        Value = contragents[i].Address
                    };
                    dataGridView1.Rows[i].Tag = contragents[i].ContrAgentID;
                }
            }
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            using (UserContext db = new UserContext(Settings.constr))
            {
                int ID = Convert.ToInt32(dataGridView1.CurrentRow.Tag);

                var item = db.Contragents.Where(x => x.ContrAgentID == ID).FirstOrDefault();
                EditDictionaryForm f = new EditDictionaryForm(item, 2, this);
                f.Show();
            }

        }

        private void добавитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (UserContext db = new UserContext(Settings.constr))
            {
                int ID = Convert.ToInt32(dataGridView1.CurrentRow.Tag);

                var item = db.Contragents.Where(x => x.ContrAgentID == ID).FirstOrDefault();
                EditDictionaryForm f = new EditDictionaryForm(null, 1, this);
                f.Show();
            }

        }

        private void изменитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (UserContext db = new UserContext(Settings.constr))
            {
                int ID = Convert.ToInt32(dataGridView1.CurrentRow.Tag);

                var item = db.Contragents.Where(x => x.ContrAgentID == ID).FirstOrDefault();
                EditDictionaryForm f = new EditDictionaryForm(item, 2, this);
                f.Show();
            }
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (UserContext db = new UserContext(Settings.constr))
            {
                int ID = Convert.ToInt32(dataGridView1.CurrentRow.Tag);

                var item = db.Contragents.Where(x => x.ContrAgentID == ID).FirstOrDefault();
                db.Contragents.Remove(item);
                db.SaveChanges();
            }
            Init();
        }
    }
}

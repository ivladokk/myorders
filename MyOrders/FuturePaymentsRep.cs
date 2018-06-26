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

namespace MyOrders
{
    public partial class FuturePaymentsRep : Form
    {
        public FuturePaymentsRep()
        {
            InitializeComponent();
            Init();
        }


        public void Init()
        {
            using (UserContext db = new UserContext(Settings.constr))
            {
                var fpayments = db.FuturePayments.ToList();
                for (int i = 0; i < fpayments.Count; i++)
                {
                    dataGridView1.Rows.Add();
                    dataGridView1["CreateDate", i].Value = fpayments[i].CreateDate.ToString("dd.MM.yyyy");
                    dataGridView1["Acc", i].Value = fpayments[i].Acc;
                    dataGridView1["Sum", i].Value = fpayments[i].Sum;
                    dataGridView1["Comments", i].Value = fpayments[i].Comments;
                    dataGridView1["ContractNum", i].Value = fpayments[i].CreditNum;
                    dataGridView1["PaymentType", i].Value = fpayments[i].PaymentType == 1 ? "Приход" : "Расход";

                    int caid = fpayments[i].ContrAgentID;
                    var contragent = db.Contragents.Where(x => x.ContrAgentID == caid).FirstOrDefault().Name;
                    dataGridView1["Contragent", i].Value = contragent;
                    int pcd = fpayments[i].PaymentCurrencyCode;
                    var currency = db.CurrencyCodes.Where(x => x.Code == pcd).FirstOrDefault().CurrencyName;
                    dataGridView1["Currency", i].Value = currency;
                    int colid = fpayments[i].ColorID;
                    var color = db.PaymentColors.Where(x => x.ID == colid).FirstOrDefault()?.ColorRus ??"";
                    dataGridView1["Currency", i].Value = currency;
                    dataGridView1.Rows[i].Tag = fpayments[i].ID;
                }

            }

            /*

            DataSet ds = new DataSet();
            try
            {
                using (SqlConnection conn = new SqlConnection(Settings.constr))
                {
                    SqlCommand cmd = new SqlCommand("GetFuturePayments", conn);
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

            dataGridView1.DataSource = ds;
            */
        }


        private void добавитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FuturePaymentsEdit f = new FuturePaymentsEdit(1, null, this);
            f.ShowDialog();
        }

        private void изменитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow.Tag!=null)
            {
                using (UserContext db = new UserContext(Settings.constr))
                {
                    int id = Convert.ToInt32(dataGridView1.CurrentRow.Tag);
                    var item = db.FuturePayments.Where(x => x.ID == id).FirstOrDefault();
                    FuturePaymentsEdit f = new FuturePaymentsEdit(2, item, this);
                    f.ShowDialog();
                }
                    
            }
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow.Tag != null)
            {
                using (UserContext db = new UserContext(Settings.constr))
                {
                    int id = Convert.ToInt32(dataGridView1.CurrentRow.Tag);
                    var item = db.FuturePayments.Where(x => x.ID == id).FirstOrDefault();
                    db.FuturePayments.Remove(item);
                    db.SaveChanges();
                }

            }
        }

        private void перенестиВКалендарьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow.Tag != null)
            {
                using (UserContext db = new UserContext(Settings.constr))
                {
                    int id = Convert.ToInt32(dataGridView1.CurrentRow.Tag);
                    var item = db.FuturePayments.Where(x => x.ID == id).FirstOrDefault();
                    CreateFuturePayment f = new CreateFuturePayment(item);
                    f.ShowDialog();
                }
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentRow.Tag != null)
            {
                using (UserContext db = new UserContext(Settings.constr))
                {
                    int id = Convert.ToInt32(dataGridView1.CurrentRow.Tag);
                    var item = db.FuturePayments.Where(x => x.ID == id).FirstOrDefault();
                    FuturePaymentsEdit f = new FuturePaymentsEdit(2, item, this);
                    f.ShowDialog();
                }

            }
        }
    }
}

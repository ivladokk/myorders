using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyOrders.Dictionaries
{
    public partial class EditDictionaryForm : XtraForm
    {


        ContrAgent Item;
        object Sender;
        int Type;
        public EditDictionaryForm(ContrAgent item,int type, object sender)
        {
            InitializeComponent();
            
            Sender = sender;
            Type = type;
            Item = item;
            if (Type == 2)
            {
                InitForm();
            }

        }

        private void InitForm()
        {
            tb_Name.Text = Item.Name;
            tb_Address.Text = Item.Address;
        }

        


        private bool isValid()
        {
            return true;
        }


        public void EditContragent(ContrAgent item)
        {
            item.Name = tb_Name.Text;
            item.Address = tb_Address.Text;
            using (UserContext db = new UserContext(Settings.constr))
            {
                db.Contragents.Attach(item);
                var entry = db.Entry(item);
                entry.Property(x => x.Name).IsModified = true;
                entry.Property(x => x.Address).IsModified = true;
                db.SaveChanges();
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {


            if (Type == 1 & isValid())
            {

                ContrAgent newitem = new ContrAgent()
                {
                    Name = tb_Name.Text,
                    Address = tb_Address.Text
                };

                using (UserContext db = new UserContext(Settings.constr))
                {
                    db.Contragents.Add(newitem);
                    db.SaveChanges();
                }

                MessageBox.Show("Добавлено");
                (Sender as Contragents).Init();
                this.Close();
                return;
            }
            if (Type == 2 & isValid())
            {

                EditContragent(Item);
                MessageBox.Show("Изменено");
                (Sender as Contragents).Init();
                this.Close();
                return;

            }

            if (Type==3 & isValid())
            {
                ContrAgent newitem = new ContrAgent()
                {
                    Name = tb_Name.Text,
                    Address = tb_Address.Text
                };

                using (UserContext db = new UserContext(Settings.constr))
                {
                    db.Contragents.Add(newitem);
                    db.SaveChanges();
                }

                MessageBox.Show("Добавлено");
                (Sender as EditPaymentForm).LoadAgents();
                this.Close();
                return;
            }
                


            
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {

        }
    }
}

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
using AppCore;
using AppCore.Models;
using AppCore.Settings;

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
            tb_name_eng.Text = Item.NameEng;
        }

        


        private bool isValid()
        {
            return true;
        }


        public void EditContragent(ContrAgent item)
        {
            item.Name = tb_Name.Text;
            item.NameEng = tb_name_eng.Text;
            item.Address = tb_Address.Text;
            using (UserContext db = new UserContext(Settings.constr))
            {
                db.Contragents.Attach(item);
                var entry = db.Entry(item);
                entry.Property(x => x.Name).IsModified = true;
                entry.Property(x => x.NameEng).IsModified = true;
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
                    NameEng = tb_name_eng.Text,
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
                    NameEng = tb_name_eng.Text,
                    Address = tb_Address.Text
                };

                using (UserContext db = new UserContext(Settings.constr))
                {
                    db.Contragents.Add(newitem);
                    db.SaveChanges();
                }

                MessageBox.Show("Добавлено");
                (Sender as IEditForm).LoadAgents();
                this.Close();
                return;
            }
                


            
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {

        }
    }
}

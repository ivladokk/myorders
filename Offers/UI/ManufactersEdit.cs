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

namespace Offers.UI
{
    public partial class ManufactersEdit : XtraForm
    {
        private Manufacter _manufacter;
        private ManufactersDictionary _sender;
        private int _mode;
        public ManufactersEdit(Manufacter manufacter, ManufactersDictionary sender)
        {
            InitializeComponent();
            _manufacter = manufacter ?? new Manufacter();
            _mode = manufacter == null ? 1 : 2;
            _sender = sender;
            tb_name_eng.DataBindings.Add("Text", _manufacter, "Name");
            tb_name_rus.DataBindings.Add("Text", _manufacter, "NameRus");
            tb_logo.DataBindings.Add("Text", _manufacter, "Logo");
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            if (_manufacter.Name == "" || _manufacter.NameRus == "")
            {
                MessageBox.Show("Заполните данные!");
                return;
            }

            _manufacter.Logo = tb_logo.Text;
            if (_mode == 1)
            {
                using (UserContext db = new UserContext(Settings.constr))
                {
                    db.Manufacters.Add(_manufacter);
                    db.SaveChanges();
                }
            }

            if (_mode == 2)
            {
                using (UserContext db = new UserContext(Settings.constr))
                {
                    db.Manufacters.Attach(_manufacter);
                    var entry = db.Entry(_manufacter);
                    entry.Property(x => x.Name).IsModified = true;
                    entry.Property(x => x.NameRus).IsModified = true;
                    entry.Property(x => x.Logo).IsModified = true;
                    db.SaveChanges();
                }
            }
            _sender.Init();
            Close();
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            tb_logo.Text = openFileDialog1.FileName;
        }
    }
}

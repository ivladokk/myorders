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
using DevExpress.XtraEditors;

namespace Offers.UI
{
    public partial class EquipmentEdit : XtraForm
    {
        private Equipment _equipment;
        private EquipmentDictionary _sender;
        private readonly int _mode;
        public EquipmentEdit(Equipment equipment, EquipmentDictionary sender)
        {
            InitializeComponent();
            _sender = sender;
            _equipment = equipment ?? new Equipment();
            _mode = equipment == null ? 1 : 2;
            LoadManufacters();

            tb_code.DataBindings.Add("Text", _equipment, "Code");
            tb_price.DataBindings.Add("Text", _equipment, "Price");
            tb_name_eng.DataBindings.Add("Text", _equipment, "EquipName");
            tb_name_rus.DataBindings.Add("Text", _equipment, "EquipNameRus");
            tb_desc_eng.DataBindings.Add("Text", _equipment, "Description");
            tb_desc_rus.DataBindings.Add("Text", _equipment, "DescriptionRus");
            tb_img.DataBindings.Add("Text", _equipment, "Image");
            cb_manufacters.DataBindings.Add("SelectedValue", _equipment, "ManufacterID");


        }

        public void LoadManufacters()
        {
            BindingList<Manufacter> manufacterDS = new BindingList<Manufacter>();
            using (UserContext db = new UserContext(Settings.constr))
            {
                foreach (var i in db.Manufacters)
                {
                    manufacterDS.Add(i);
                }
            }

            cb_manufacters.DisplayMember = "NameRus";
            cb_manufacters.ValueMember = "ID";
            cb_manufacters.DataSource = manufacterDS;

        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            using (UserContext db = new UserContext(Settings.constr))
            {
                if (_mode == 1)
                {
                    db.Equipments.Add(_equipment);
                }

                if (_mode == 2)
                {
                    db.Equipments.Attach(_equipment);
                    var entry = db.Entry(_equipment);
                    entry.Property(x => x.Code).IsModified = true;
                    entry.Property(x => x.Price).IsModified = true;
                    entry.Property(x => x.Description).IsModified = true;
                    entry.Property(x => x.DescriptionRus).IsModified = true;
                    entry.Property(x => x.EquipName).IsModified = true;
                    entry.Property(x => x.EquipNameRus).IsModified = true;
                    entry.Property(x => x.ManufacterID).IsModified = true;
                    entry.Property(x => x.Image).IsModified = true;
                }

                db.SaveChanges();
            }
            _sender.Init();
            this.Close();

        }

        private void btn_img_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            if (openFileDialog1.FileName != "")
                tb_img.Text = openFileDialog1.FileName;
            _equipment.Image = tb_img.Text;
        }
    }
}

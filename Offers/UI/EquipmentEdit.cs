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
    public partial class EquipmentEdit : Form
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

        }
    }
}

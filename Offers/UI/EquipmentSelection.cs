using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AppCore;
using AppCore.Models;
using AppCore.Settings;

namespace Offers.UI
{
    public partial class EquipmentSelection : UserControl
    {
        private readonly List<OfferItem> _items;
        private readonly Offer _offer;
        public EquipmentSelection(Offer offer, List<OfferItem> items)
        {
            InitializeComponent();
            _items = items;
            _offer = offer;

        }

        public void AddItem(OfferItem item)
        {
            _items.Add(item);
            LoadItems();
        }

        public void RemoveItem(OfferItem item)
        {
            _items.Remove(item);
            LoadItems();
        }

        public void LoadItems()
        {
            flowLayoutPanel1.Controls.Clear();
            foreach (var i in _items)
            {
                EquipmentItem item = new EquipmentItem(i, this);
                flowLayoutPanel1.Controls.Add(item);
            }
        }

        public List<OfferItem> GetOfferItems()
        {
            return _items;
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            int retID = 0;
            using (AddOfferItem f = new AddOfferItem())
            {
                var result = f.ShowDialog();
                if (result == DialogResult.OK)
                {
                    retID = f.retValue;
                }
                else return;
            }

            using (UserContext db = new UserContext(Settings.constr))
            {
                var equip = db.Equipments.FirstOrDefault(x => x.ID == retID);
                AddItem(new OfferItem
                {
                    OfferID = _offer.ID,
                    EquipmentID = equip.ID,
                    Count = 1,
                    Price = equip.Price,
                    Amount = equip.Price
                });
            }
        }
    }
}

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
using DevExpress.Data.Helpers;

namespace Offers.UI.MasterPage
{
    public partial class Page3 : UserControl
    {
        private List<OfferItem> _items;
        public Page3(Offer offer, List<OfferItem> items)
        {
            InitializeComponent();
            _items = items;
            EquipmentSelection selection = new EquipmentSelection(offer, _items);
            flowLayoutPanel1.Controls.Add(selection);
        }

        public List<OfferItem> GetItems()
        {
            return _items;
        }


    }
}

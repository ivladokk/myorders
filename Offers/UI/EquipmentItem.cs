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
    public partial class EquipmentItem : UserControl
    {
        private OfferItem _offerItem;
        private Equipment _equipment;
        private EquipmentSelection _sender;


        public EquipmentItem(OfferItem offerItem, EquipmentSelection sender)
        {
            InitializeComponent();
            _offerItem = offerItem;
            _sender = sender;
            using (UserContext db = new UserContext(Settings.constr))
            {
                _equipment = db.Equipments.FirstOrDefault(x => x.ID == offerItem.EquipmentID);
            }

          

            lb_name.DataBindings.Add("Text", _equipment, "EquipNameRus");
            tb_price.DataBindings.Add("Text", _offerItem, "Price");
            tb_count.DataBindings.Add("Value", _offerItem, "Count");
            tb_amount.DataBindings.Add("Text", _offerItem, "Amount");
           

        }

        public OfferItem GetItem()
        {
            return _offerItem;
        }

        private void Remove()
        {
            _sender.RemoveItem(_offerItem);
        }
        private decimal GetAmount()
        {
            return _offerItem.Price * _offerItem.Count;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Remove();
        }

        private void tb_price_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void tb_count_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void tb_price_Leave(object sender, EventArgs e)
        {
            tb_amount.Text = GetAmount().ToString();
        }

        private void tb_count_Leave(object sender, EventArgs e)
        {
            tb_amount.Text = GetAmount().ToString();
        }

        private void tb_price_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char) 13)
            {
                try
                {
                    _offerItem.Price = Convert.ToDecimal(tb_price.Text);
                    _offerItem.Count = Convert.ToInt32(tb_count.Value);
                    tb_amount.Text = GetAmount().ToString();
                    _offerItem.Amount = GetAmount();

                }
                catch (Exception exception)
                {

                }
            }
               
        }

        private void tb_count_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                try
                {
                    _offerItem.Price = Convert.ToDecimal(tb_price.Text);
                    _offerItem.Count = Convert.ToInt32(tb_count.Value);
                    tb_amount.Text = GetAmount().ToString();
                    _offerItem.Amount = GetAmount();

                }
                catch (Exception exception)
                {

                }
            }
        }
    }
}

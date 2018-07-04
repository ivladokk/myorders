using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AppCore.Models;
using Offers;

namespace CalculationModule.UI.MasterPages
{
    public partial class Page4 : UserControl
    {
        public OfferFooter footer;
        private List<OfferItem> _items;



        public Page4(OfferFooter footer,List<OfferItem> items)
        {
            InitializeComponent();
            this.footer = footer;
            //footer = new OfferFooter();
            _items = items;

            decimal total = 0;
            foreach (var i in items)
            {
                total += i.Amount;
            }

            footer.TotalAmountGoods = total;

            footer.OfferTill = DateTime.Today;
            dt_offertill.Value = DateTime.Today;
            tb_delivery_eng.DataBindings.Add("Text", footer, "Delivery");
            tb_delivery_rus.DataBindings.Add("Text", footer, "DeliveryRus");
            tb_payment_eng.DataBindings.Add("Text", footer, "Payment");
            tb_payment_rus.DataBindings.Add("Text", footer, "PaymentRus");
            tb_goodsdeliv_eng.DataBindings.Add("Text", footer, "GoodsDeliv");
            tb_goodsdeliv_rus.DataBindings.Add("Text", footer, "GoodsDelivRus");
            dt_offertill.DataBindings.Add("Value", footer, "OfferTill");
            tb_TechAssist_eng.DataBindings.Add("Text", footer, "TechAssist");
            tb_TechAssist_rus.DataBindings.Add("Text", footer, "TechAssistRus");
            tb_techdoc_eng.DataBindings.Add("Text", footer, "TechDoc");
            tb_techdoc_rus.DataBindings.Add("Text", footer, "TechDocRus");
            tb_warranty_eng.DataBindings.Add("Text", footer, "Warranty");
            tb_warranty_rus.DataBindings.Add("Text", footer, "WarrantyRus");
            tb_amount.DataBindings.Add("Text", footer, "TotalAmountGoods");
            tb_pack.DataBindings.Add("Text", footer, "PackPrice");
            tb_total.DataBindings.Add("Text", footer, "GeneralAmount");

        }

        private void tb_pack_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char) 13)
            {
                try
                {
                    var sum = Convert.ToDecimal(tb_amount.Text) + Convert.ToDecimal(tb_pack.Text);
                    tb_total.Text = sum.ToString();
                    footer.GeneralAmount = sum;
                }
                catch
                {

                }
            }
        }
    }
}

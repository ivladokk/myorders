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

namespace Offers.UI.MasterPage
{
    public partial class Page1 : UserControl
    {
        private Offer _offer;
        public Page1()
        {
            InitializeComponent();

            LoadAgents();
            tb_name.DataBindings.Add("Text", _offer, "OfferName");
        }

        public Page1(Offer offer)
        {
            InitializeComponent();
            _offer = offer ?? new Offer();
            LoadAgents();
            LoadCurrency();
            tb_name.DataBindings.Add("Text", _offer, "OfferName");
           
        }

        public void LoadCurrency()
        {
            BindingList<CurrencyCode> currencyCodes = new BindingList<CurrencyCode>();
            using (UserContext db = new UserContext(Settings.constr))
            {
                foreach (var i in db.CurrencyCodes.ToList())
                {
                    currencyCodes.Add(i);
                }
            }

            cb_currency.DisplayMember = "CurrencyName";
            cb_currency.ValueMember = "CurrencyID";
            cb_currency.DataSource = currencyCodes;
            cb_currency.DataBindings.Add("SelectedValue", _offer, "CurrencyID");
        }

        public void LoadAgents()
        {
            BindingList<ContrAgent> Contragents = new BindingList<ContrAgent>();

            using (UserContext db = new UserContext(Settings.constr))
            {
                foreach (var i in db.Contragents.ToList())
                {
                    Contragents.Add(i);
                }
            }

            cb_Contragent.Properties.DisplayMember = "Name";
            cb_Contragent.Properties.ValueMember = "ContrAgentID";
            cb_Contragent.Properties.DataSource = Contragents;
            //ContrAgentID = (int) cb_Contragent.EditValue;
            cb_Contragent.DataBindings.Add("EditValue", _offer, "ContrAgentID");
        }

        public Offer GetOffer()
        {
            return _offer;
        }

        public bool isValid()
        {
            return _offer.ContrAgentID != 0 && _offer.CurrencyID != 0;
        }
    }
}

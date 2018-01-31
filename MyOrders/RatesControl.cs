using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyOrders
{
    public partial class RatesControl : UserControl
    {
        
        private object Sender;

        Rate Item;

        public RatesControl(Rate rate, object sender)
        {
            InitializeComponent();
            Sender = sender;
            Item = rate;
            textBox1.Text = rate.RateValue.ToString().Replace(',', '.');
            using (var db = new UserContext(Settings.constr))
            {
                string from = db.CurrencyCodes.FirstOrDefault(x => x.CurrencyID == rate.FromCurID).CurrencyName;
                string to = db.CurrencyCodes.FirstOrDefault(x => x.CurrencyID == rate.ToCurID).CurrencyName;
                RateName.Text = $"{from}/{to}";
            }
            lb_scale.Text = $"Колич-во:{rate.Scale}";     
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (var db = new UserContext(Settings.constr))
                {
                    var it = db.Rates.FirstOrDefault(x => x.ID == Item.ID);
                    db.Rates.Remove(it);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                (Sender as RatesForm).Init();
            }
            
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace MyOrders
{
    public partial class OrderInfo : DevExpress.XtraEditors.XtraForm
    {
        public OrderInfo(Order order)
        {
            InitializeComponent();
            List<Good> goods;
            using (UserContext db = new UserContext(Settings.constr))
            {
                goods = db.Goods.Where(x => x.OrderID == order.ID).ToList();

            }

            for (int i=0; i<goods.Count;i++)
            {
                
                FlowLayoutPanel panel = new FlowLayoutPanel()
                {
                    Dock = DockStyle.Fill,
                    Name = string.Format("Place{0}", i+1)
                };
                panel.Controls.Add(new GoodItem(goods[i], i+1));
                var myTab = new DevExpress.XtraBars.Navigation.TabNavigationPage()
                {
                    Name = string.Format("Tab{0}", i + 1),
                    Caption = string.Format("Груз {0}", i + 1)
                };
                myTab.Controls.Add(panel);
                tabPane1.Controls.Add(myTab);
                tabPane1.Pages.Add(myTab);
                
            }



        }
    }
}
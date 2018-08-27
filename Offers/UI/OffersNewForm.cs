using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AppCore;
using AppCore.Components;
using AppCore.Interfaces;
using AppCore.Models;
using AppCore.Settings;
using DevExpress.Data.Helpers;

namespace Offers.UI
{
    public partial class OffersNewForm : Form, IUpdForm
    {
        public MyGrid grid;
        public OffersNewForm()
        {
            InitializeComponent();
            MyGridSettings settings = new MyGridSettings();
            settings.ContextMenuItems = GetMenuItems();
            settings.AutoSizeColums = true;
            grid = new MyGrid(settings);
            grid.Dock = DockStyle.Fill;
            Controls.Add(grid);
            Init();

        }

        private List<ToolStripMenuItem> GetMenuItems()
        {
            var ret = new List<ToolStripMenuItem>();
            ToolStripMenuItem createItem = new ToolStripMenuItem
            {
                Name = "createItem",
                Text = "Создать",
            };
            createItem.Click += CreateItem_Click;
            ToolStripMenuItem deleteItem = new ToolStripMenuItem
            {
                Name = "deleteItem",
                Text = "Удалить"
            };
            deleteItem.Click += DeleteItem_Click;
            ToolStripMenuItem printItem = new ToolStripMenuItem
            {
                Name = "printItem",
                Text = "Печать"
            };
            printItem.Click += PrintItem_Click;
            ToolStripMenuItem editItem = new ToolStripMenuItem
            {
                Name = "editItem",
                Text = "Изменить"
            };
            editItem.Click += EditItem_Click;
            ToolStripMenuItem copyItem = new ToolStripMenuItem
            {
                Name = "copyItem",
                Text = "Копировать"
            };
            copyItem.Click += CopyItem_Click;


            ret.Add(createItem);
            ret.Add(deleteItem);
            ret.Add(printItem);
            ret.Add(editItem);
            ret.Add(copyItem);
            return ret;
        }

        private void Copy()
        {
            var id = grid.GetSelectedID();
            if (id < 0) return;
            using (UserContext db = new UserContext(Settings.constr))
            {
                var offer = db.Offers.FirstOrDefault(x => x.ID == id);
                if (offer != null)
                {
                    var header = db.OfferHeaders.FirstOrDefault(x => x.OfferID == offer.ID);
                    var items = db.OfferItems.Where(x => x.OfferID == offer.ID).ToList();
                    var footer = db.OfferFooters.FirstOrDefault(x => x.OfferID == offer.ID);
                    var newOffer = new Offer()
                    {
                        ContrAgentID = offer.ContrAgentID,
                        CreateDate = DateTime.Now,
                        OfferName = $"{offer.OfferName} Копия"
                    };
                    db.Offers.Add(newOffer);
                    db.SaveChanges();
                    var newHeader = new OfferHeader
                    {
                        OfferID = newOffer.ID,
                        ManufacterID = header.ManufacterID,
                        HeaderText = header.HeaderText,
                        HeaderTextRus = header.HeaderTextRus,
                        OfferNumber = header.OfferNumber,
                        SubjectRus = header.SubjectRus,
                        Subject = header.Subject
                    };
                    var newItems = new List<OfferItem>();
                    foreach (var i in items)
                    {
                        var newItem = new OfferItem
                        {
                            EquipmentID = i.EquipmentID,
                            Amount = i.Amount,
                            Count = i.Count,
                            OfferID = newOffer.ID,
                            Price = i.Price
                        };
                        newItems.Add(newItem);
                    }

                    var newFooter = new OfferFooter
                    {
                        Sign = footer.Sign,
                        Delivery = footer.Delivery,
                        DeliveryRus = footer.DeliveryRus,
                        GeneralAmount = footer.GeneralAmount,
                        GoodsDeliv = footer.GoodsDeliv,
                        GoodsDelivRus = footer.GoodsDelivRus,
                        OfferID = newOffer.ID,
                        OfferTill = footer.OfferTill,
                        PackPrice = footer.PackPrice,
                        SignRus = footer.SignRus,
                        TotalAmountGoods = footer.TotalAmountGoods,
                        TechAssist = footer.TechAssist,
                        TechAssistRus = footer.TechAssistRus,
                        TechDoc = footer.TechDoc,
                        TechDocRus = footer.TechDocRus,
                        Payment = footer.Payment,
                        PaymentRus = footer.PaymentRus

                    };
                    

                    db.OfferHeaders.Add(newHeader);
                    db.OfferItems.AddRange(newItems);
                    db.OfferFooters.Add(newFooter);

                    db.SaveChanges();

                    var worker = new OfferWorker(newOffer);
                    OfferCreateForm f = new OfferCreateForm(this, worker);
                    f.ShowDialog();
                }

            }
        }

        private void CopyItem_Click(object sender, EventArgs e)
        {
            try
            {
                Copy();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
            
        }

        private void EditItem_Click(object sender, EventArgs e)
        {
            var id = grid.GetSelectedID();
            if (id < 0) return;
            using (UserContext db = new UserContext(Settings.constr))
            {
                var offer = db.Offers.FirstOrDefault(x => x.ID == id);
                if (offer != null)
                {
                    var worker = new OfferWorker(offer);
                    OfferCreateForm f = new OfferCreateForm(this, worker);
                    f.ShowDialog();
                }

            }
        }

        private void PrintItem_Click(object sender, EventArgs e)
        {
            var id = grid.GetSelectedID();
            if (id < 0) return;
            using (UserContext db = new UserContext(Settings.constr))
            {
                var offer = db.Offers.FirstOrDefault(x => x.ID == id);
                if (offer != null)
                {
                    OfferWorker worker = new OfferWorker(offer);
                    worker.Print();
                }

            }
        }

        private void DeleteItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы уверены?", "Удаление", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                var id = grid.GetSelectedID();
                if (id < 0) return;
                using (UserContext db = new UserContext(Settings.constr))
                {
                    var offer = db.Offers.FirstOrDefault(x => x.ID == id);
                    if (offer != null)
                    {
                        db.Offers.Remove(offer);
                        db.SaveChanges();
                        Init();
                    }

                }
            }
            

        }

        private void CreateItem_Click(object sender, EventArgs e)
        {
            OfferCreateForm f = new OfferCreateForm(this);
            f.ShowDialog();
        }

        public void Init()
        {
            DataSet ds = new DataSet();
            try
            {

                using (SqlConnection conn = new SqlConnection(Settings.constr))
                {
                    SqlCommand cmd = new SqlCommand("GetAllOffers", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = cmd;
                    da.Fill(ds);
                }
                grid.SetDataTable(ds.Tables[0]);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            

        }

    }
}

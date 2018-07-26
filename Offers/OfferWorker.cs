using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using AppCore;
using AppCore.Components;
using AppCore.Models;
using AppCore.Settings;
using DevExpress.DocumentServices.ServiceModel.DataContracts;
using DevExpress.Internal.WinApi.Windows.UI.Notifications;

namespace Offers
{
    public class OfferInstance
    {
        public Offer offer { get; set; }
        public OfferHeader header { get; set; }
        public List<OfferItem> items { get; set; }
        public OfferFooter footer { get; set; }
    }
    public class OfferWorker
    {
        private readonly int _type;
        public Offer offer;
        private OfferHeader _header;
        private List<OfferItem> _items;
        private OfferFooter _footer;

        

        public OfferWorker()
        {
            _type = 1;
            _items = new List<OfferItem>();
        }

        public OfferWorker(Offer offer)
        {
            _type = 2;
            this.offer = offer;
            using (UserContext db = new UserContext(Settings.constr))
            {
                _header = db.OfferHeaders.FirstOrDefault(x => x.OfferID == offer.ID);
                _footer = db.OfferFooters.FirstOrDefault(x => x.OfferID == offer.ID);
                _items = db.OfferItems.Where(x => x.OfferID == offer.ID).ToList();
            }
        }


        public void CreateOffer(Offer newOffer)
        {
            if (newOffer.ID == 0)
            {
                offer = newOffer;
                offer.CreateDate = DateTime.Now;
                using (UserContext db = new UserContext(Settings.constr))
                {
                    db.Offers.Add(offer);
                    db.SaveChanges();
                }
            }
            else EditOffer(newOffer);


        }

        public void EditOffer(Offer newOffer)
        {
            offer = newOffer;
            using (UserContext db = new UserContext(Settings.constr))
            {
                db.Offers.Attach(offer);
                var entry = db.Entry(offer);
                entry.Property(x => x.ContrAgentID).IsModified = true;
                entry.Property(x => x.OfferName).IsModified = true;
                db.SaveChanges();
            }
        }

        public void SetHeader(OfferHeader header)
        {
            _header = header;
        }

        public OfferHeader GetHeader()
        {
            return _header;
        }

        public void FillItems(List<OfferItem> items)
        {
            _items = items;
        }

        public List<OfferItem> GetItems()
        {
            return _items;
        }

        public void SetFooter(OfferFooter footer)
        {
            _footer = footer;
        }

        public OfferFooter GetFooter()
        {
            return _footer ?? new OfferFooter();
        }


        public void Save()
        {
            try
            {
                using (UserContext db = new UserContext(Settings.constr))
                {
                    db.OfferHeaders.Add(_header);
                    if (_type == 2)
                    {
                        ClearItems();
                    }
                    db.OfferItems.AddRange(_items);
                    db.OfferFooters.Add(_footer);
                    db.SaveChanges();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
           
        }

        private void ClearItems()
        {
            using (UserContext db = new UserContext(Settings.constr))
            {
                var oldItems = db.OfferItems.Where(x => x.OfferID == offer.ID).ToList();
                foreach (var i in oldItems)
                {
                    db.OfferItems.Remove(i);
                    
                }
                db.SaveChanges();

            }
        }
        public void Print()
        {
            var template = new ReportTemplate
            {
                MainTemplatePath = Application.StartupPath + @"\template\index.html",
                TableTemplatePath = Application.StartupPath + @"\template\table.html"
            };
            var instance = new OfferInstance
            {
                offer = offer,
                footer = _footer,
                header = _header,
                items = _items
            };

            SaveFileDialog dialog = new SaveFileDialog();
            dialog.DefaultExt = "pdf";
            dialog.Filter = "PDF|*.pdf";
            dialog.ShowDialog();

            if (!string.IsNullOrEmpty(dialog.FileName))
            {
                ExportUtils export = new ExportUtils(template, instance, dialog.FileName);
                export.Ex2();
                //export.Export();

            }
            
        }
    }
}

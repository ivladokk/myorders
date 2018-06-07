using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AppCore;
using AppCore.Models;
using AppCore.Settings;
using DevExpress.DocumentServices.ServiceModel.DataContracts;

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



        public void CreateOffer(int agentId, string name)
        {
            offer = new Offer
            {
                ContrAgentID = agentId,
                OfferName = name,
                CreateDate = DateTime.Now
            };
            using (UserContext db = new UserContext(Settings.constr))
            {
                db.Offers.Add(offer);
                db.SaveChanges();
            }
        }

        public void SetHeader(OfferHeader header)
        {
            _header = header;
        }

        public void FillItems(List<OfferItem> items)
        {
            _items = items;
        }

        public void SetFooter(OfferFooter footer)
        {
            _footer = footer;
        }


        public void Save()
        {
            try
            {
                using (UserContext db = new UserContext(Settings.constr))
                {
                    db.OfferHeaders.Add(_header);
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

        public void Print()
        {
            ExportUtils export = new ExportUtils(new ReportTemplate
            {
                MainTemplatePath = @"D:\template\index.html",
                TableTemplatePath = @"D:\template\table.html"
            });
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
                export.Export(instance, dialog.FileName);

            }
            
        }
    }
}

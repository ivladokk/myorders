using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppCore;
using AppCore.Models;
using AppCore.Settings;

namespace Offers
{
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

        public void Print()
        {

        }
    }
}

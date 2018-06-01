using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppCore.Models;

namespace Offers
{
    public class OfferWorker
    {
        private readonly int _type;
        private Offer _offer;

        public OfferWorker()
        {
            _type = 1;
            _offer = new Offer();
        }

        public OfferWorker(Offer offer)
        {
            _type = 2;
            _offer = offer;
        }

    }
}

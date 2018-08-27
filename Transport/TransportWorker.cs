using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppCore;
using AppCore.Models;
using AppCore.Settings;

namespace Transport
{
    public class TransportWorker
    {
        private TransportPack _transportPack;
        private List<TransportPackItem> _transportPackItems;

        public void CreatePack(string name, int from, int to, int itemId)
        {
            _transportPack = new TransportPack
            {
                Name = name,
                ContragentIDFrom = from,
                ContragentIDTo = to,
                Status = 1,
                TotalItemID = itemId,
                CreateDate = DateTime.Now
            };
        }


        public void SetItems(List<TransportPackItem> items)
        {
            _transportPackItems = items;
        }
        public void SavePack()
        {
            if (_transportPack != null)
            {
                decimal sum = 0;
                foreach (var pr in _transportPackItems)
                {
                    sum += pr.TotalValue;
                }

                _transportPack.TotalSum = sum;
                using (UserContext db = new UserContext(Settings.constr))
                {
                    db.TransportPacks.Add(_transportPack);
                    db.SaveChanges();

                    foreach (var i in _transportPackItems)
                    {
                        i.TransportPackID = _transportPack.ID;
                        db.TransportPackItems.Add(i);
                    }

                    db.SaveChanges();
                }

            }
        }

        public void UpdatePack()
        {

        }
    }
}

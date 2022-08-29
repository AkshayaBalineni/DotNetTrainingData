using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnCommonLayer.Models
{
   public class Bank
    {
        public int BankId { get; set; }
        public string BankName { get; set; }
        public string City { get; set; }
        public string IFSC { get; set; }
        private List<Offer> Offers = new List<Offer>();

        public void AddOffer(Offer offer)
        {
            this.Offers.Add(offer);
        }
        public IEnumerable<Offer> GetOffers()
        {
            return this.Offers;
        }
    }
}

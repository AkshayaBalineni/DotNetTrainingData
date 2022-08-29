using Microsoft.EntityFrameworkCore;
using ShopOnCommonLayer.Models;
using ShopOnDataLayer.Contracts;
using ShopOnEFLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnEFLayer.Impl
{
    public class BankRepoEFImpl : IBankRepo
    {
        private readonly db_shoponContext context;
        public BankRepoEFImpl()
        {
            this.context = new db_shoponContext();
        }
        public bool AddBank(ShopOnCommonLayer.Models.Bank bank)
        {
            bool isAdded = false;
            var bankExists = context.Banks.SingleOrDefault(x => x.IFSC == bank.IFSC);
            if (bankExists == null)
            {
                isAdded = saveBank(bank);
            }
            else
            {
               isAdded = saveOffers(bank);
               
            }
            return isAdded;
        }

        private bool saveOffers(ShopOnCommonLayer.Models.Bank bank)
        {
            bool isSaved = false;
            var dboffers = ExtractOffer(bank.GetOffers());
            foreach (var offer in dboffers)
            {
                offer.BankId = bank.BankId;
                this.context.Offers.Add(offer);   
            }
            context.SaveChanges();
            isSaved = true;
            return isSaved;
        }

        private bool saveBank(ShopOnCommonLayer.Models.Bank bank)
        {
            bool isInserted = false;
            try
            {
                var dbBank = new Models.Bank()
                {
                    BankName = bank.BankName,
                    City = bank.City,
                    IFSC = bank.IFSC,
                    Offers = ExtractOffer(bank.GetOffers())
                };
                this.context.Banks.Add(dbBank);
                this.context.SaveChanges();
                isInserted = true;
            }
            catch (Exception)
            {

            }
            return isInserted;
        }

        IEnumerable<ShopOnCommonLayer.Models.Bank> IBankRepo.GetBanks()
        {
           var dbBanks = context.Banks.ToList();

            var banks = from b in dbBanks
                        select new ShopOnCommonLayer.Models.Bank
                        {
                            BankId = b.BankId,
                            BankName = b.BankName,
                            City =b.City,
                            IFSC = b.IFSC
                        };
            return banks;
            
        }
        private ICollection<Models.Offer> ExtractOffer(IEnumerable<ShopOnCommonLayer.Models.Offer> offers)
        {
            List<Models.Offer> dbOffers = new List<Models.Offer>();
           foreach(var offer in offers)
            {
                Models.Offer dboffer = new Models.Offer()
                {
                    BankId = offer.BankId,
                    Discount = offer.Discount,
                    OfferType = offer.Remark,
                    Remark = offer.Remark
                };
                dbOffers.Add(dboffer);
            }
            return dbOffers;
        }

    }
}

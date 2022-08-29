using ShopOnBussinessLayer.Contracts;
using ShopOnBussinessLayer.Implementation;
using ShopOnCommonLayer.Models;
using ShopOnDataLayer.Contracts;
using ShopOnEFLayer.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnConsoleApplication
{
    public class BankMenu
    {
        public void Main()
        {
            IBankRepo bankRepo = new BankRepoEFImpl();
            IBankManager bankManager = new BankManager(bankRepo);
            int ch;
            bool looping = true;
            while (looping)
            {
                Console.WriteLine("BANK MENU");
                Console.WriteLine("****************************");
                Console.WriteLine("1.Add Bank");
                Console.WriteLine("2.Display Banks");
                Console.WriteLine("Enter your choice");
                Console.WriteLine("****************************");
                ch = Convert.ToInt32(Console.ReadLine());
                switch (ch)
                {
                    case 1:
                        AddBank(bankManager);
                        break;
                    case 2:
                        DisplayBanks(bankManager);
                        break;
                    default: looping = false; break;
                }
                Console.WriteLine("Do you want to continue in Bank menu? y/n");
                String s = Console.ReadLine();
                if (String.Equals(s, "N", StringComparison.OrdinalIgnoreCase))
                    looping = false;
            }
        }

        private void DisplayBanks(IBankManager bankManager)
        {
            var banks = bankManager.GetBanks();
            Console.WriteLine("BankId\tBankName\t\tCity\tIFSC");
            foreach(var bank in banks)
            {
                Console.WriteLine($"{bank.BankId}\t{bank.BankName}\t\t{bank.City}\t{bank.IFSC}");
            }
        }

        private void AddBank(IBankManager bankManager)
        {
            Bank bank = new Bank()
            {
                BankName="HDFC",
                City="Banglore",
                IFSC = "HDFC0001"
            };
            Offer offer1 = new Offer()
            {
                Discount = 10,
                OfferType = "Diwali offer",
                Remark = "Get 10% off on HDFC credit card"
            };
            Offer offer2 = new Offer()
            {
                Discount = 30,
                OfferType = "NewYear offer",
                Remark = "Get 30% off on HDFC credit card"
            };
            bank.AddOffer(offer1);
            bank.AddOffer(offer2);
            try
            {
                if (bankManager.AddBank(bank))
                {
                    Console.WriteLine("Bank added");
                }
                else
                {
                    Console.WriteLine("Bank Not added");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}

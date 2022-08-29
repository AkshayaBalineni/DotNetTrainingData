using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZohoBankingCommonLayer;
using ZohoBankingRepo;

namespace ZohoBanking
{
    public class ZohoBankingMenu
    {
        long custId = 10000;
        long accountNumber = 20000;
        public void Main()
        {
            ZohoBankingRepoImpl bankingRepo = new ZohoBankingRepoImpl();
            long ch = 0;
            bool loop = true;
            Console.WriteLine("Banking Menu:");
            Console.WriteLine("1.Add Customer");
            Console.WriteLine("2.Display Customer");
            Console.WriteLine("3.Authentication");
            Console.WriteLine("4.ATM Withdrawl");
            Console.WriteLine("5.cash Deposit");
            Console.WriteLine("6.Account Transfer");
            Console.WriteLine("*****************************");
            while (loop)
            {
                Console.WriteLine("Enter your Choice:");
                ch = Convert.ToInt32(Console.ReadLine());
                switch(ch)
                {
                    case 1: AddCustomer(bankingRepo);
                        break;
                    case 2: DisplayCustomer(bankingRepo);
                        break;
                    case 3: Authentication(bankingRepo);
                        break;
                    case 4 : Withdrawal(bankingRepo);
                        break;
                    case 5: CashDeposit(bankingRepo);
                        break;
                    case 6: AccountTrasfer(bankingRepo);
                        break;
                    default:
                        Console.WriteLine("Invalid Choice");
                        loop = false;
                        break;
                }
            }
        }

        private void AccountTrasfer(ZohoBankingRepoImpl bankingRepo)
        {
            throw new NotImplementedException();
        }

        private void CashDeposit(ZohoBankingRepoImpl bankingRepo)
        {
            throw new NotImplementedException();
        }

        private void Withdrawal(ZohoBankingRepoImpl bankingRepo)
        {
            string isWithdraw = bankingRepo.WithDraw();
        }

        private void Authentication(ZohoBankingRepoImpl bankingRepo)
        {
            Console.WriteLine("Enter the customerId:");
            int customerId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the Password:");
            string password = Console.ReadLine();
            string isAuthenticated = bankingRepo.Authentication(customerId, password);
            Console.WriteLine(isAuthenticated);
        }

        private void DisplayCustomer(ZohoBankingRepoImpl bankingRepo)
        {
            List<Customer> customers = bankingRepo.DisplayCustomer().ToList();
            Console.WriteLine("CustomerId\tCustomerName\tEncryptedPassword\tIntial Amount\tAccountNumber");
            foreach(var customer in customers)
            {
                Console.WriteLine($"{customer.CustomerId}\t\t{customer.CustomerName}\t\t{customer.encryptedPassword}\t\t{customer.IntialAmount}\t\t{customer.AccountNumber}");
            }
        }

        private void AddCustomer(ZohoBankingRepoImpl bankingRepo)
        {
            Customer customer = new Customer();
            customer.CustomerId = custId+1;
            custId++;
            Console.WriteLine("Enter CustomerName:");
            customer.CustomerName = Console.ReadLine();
            Console.WriteLine("Enter Password:");
            customer.Password = Console.ReadLine();
            Console.WriteLine("Enter Confirm Password:");
            customer.RetypePassword = Console.ReadLine();
            customer.AccountNumber = accountNumber + 1;
            accountNumber++;
            customer.IntialAmount = 10000;
            customer.isAuthenticated = false;
            string isadded = bankingRepo.AddCustomer(customer);
            Console.WriteLine(isadded);
        }
    }
}

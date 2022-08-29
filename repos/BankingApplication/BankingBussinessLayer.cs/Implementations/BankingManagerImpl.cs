using BankingBussinessLayer.cs.Contracts;
using BankingCommonLayer.Models;
using BankingDataLayer.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingBussinessLayer.cs.Implementations
{
    public class BankingManagerImpl : IBankingManger
    {
        private readonly IManagerRepository managerRepository;

        public BankingManagerImpl(IManagerRepository  managerRepository)
        {
            this.managerRepository = managerRepository;
        }
        public string AddNewCustomer(Customer customer)
        {
            return managerRepository.AddNewCustomer(customer);
        }

        public string DeleteCustomer(string customerId)
        {
            return managerRepository.DeleteCustomer(customerId);
        }

        public string UpdateCustomer(Customer customer)
        {
            return managerRepository.UpdateCustomer(customer);
        }

        public string AddAccount(Account account)
        {
            return managerRepository.AddAccount(account);
        }

        public string DeleteAccount(string accountId)
        {
            return managerRepository.DeleteAccount(accountId);
        }

        public string UpdateAccount(AccountCopy account)
        {
            return managerRepository.UpdateAccount(account);
        }

        public string Withdraw(AccountCopy account)
        {
            return managerRepository.Withdraw(account);
        }

        public string Deposit(AccountCopy account)
        {
            return managerRepository.Deposit(account);
        }

        public IEnumerable<Transaction> Ministatement(string AccountNumber)
        {
            return managerRepository.Ministatement(AccountNumber);
        }

        public string FundTransfer(AccountCopy account)
        {
            return managerRepository.FundTransfer(account);
        }

        public double BalanceEnquiry(string id)
        {
            return managerRepository.BalanceEnquiry(id);
        }

        public IEnumerable<Customer> GetCustomer()
        {
            return managerRepository.GetCustomer();
        }

        public IEnumerable<AccountCopy> GetAccounts()
        {
            return managerRepository.GetAccounts();
        }

        public IEnumerable<Transaction> CustomizedStatement(AccountCopy accountCopy)
        {
            return managerRepository.CustomizedStatement(accountCopy);
        }

        public Customer GetCustomer(string customerId)
        {
            return managerRepository.GetCustomer(customerId);
        }
    }
}

using BankingCommonLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingDataLayer.Contracts
{
    public interface IManagerRepository
    {
        public BankingCommonLayer.Models.Customer GetCustomer(string customerId);
        IEnumerable<BankingCommonLayer.Models.Customer> GetCustomer();
        string AddNewCustomer(Customer customer);
        string UpdateCustomer(Customer customer);
        string DeleteCustomer(string customerId);
        string AddAccount(Account account);
        string DeleteAccount(string accountId);
        string UpdateAccount(AccountCopy account);
        string Withdraw(AccountCopy account);
        string Deposit(AccountCopy account);
        IEnumerable<Transaction> Ministatement(string AccountNumber);
        string FundTransfer(AccountCopy account);
        double BalanceEnquiry(string id);
        IEnumerable<BankingCommonLayer.Models.AccountCopy> GetAccounts();
        IEnumerable<BankingCommonLayer.Models.Transaction> CustomizedStatement(AccountCopy accountCopy);
    }
}

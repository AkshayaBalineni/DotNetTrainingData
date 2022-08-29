using BankingCommonLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingBussinessLayer.cs.Contracts
{
    public interface IBankingManger
    {
        IEnumerable<BankingCommonLayer.Models.Customer> GetCustomer();
        IEnumerable<BankingCommonLayer.Models.AccountCopy> GetAccounts();
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
        IEnumerable<BankingCommonLayer.Models.Transaction> CustomizedStatement(AccountCopy accountCopy);
        Customer GetCustomer(string customerId);
        
    }
}

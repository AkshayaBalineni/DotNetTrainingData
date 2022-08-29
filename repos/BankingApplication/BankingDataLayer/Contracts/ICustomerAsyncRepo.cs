using BankingCommonLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingDataLayer.Contracts
{
    public interface ICustomerAsyncRepo
    {
        /// <summary>
        /// Method that view balance of customers Account
        /// </summary>
        /// <param name="account">AccountCopy Model</param>
        /// <returns>returns balance</returns>
        Task<double> BalanceEnqiry(string custId, string accountNumber);
        Task<IEnumerable<Transaction>> Ministatement(string custId,string accountNumber);
        Task<IEnumerable<Transaction>> CustomisedStatement(string accountNumber, DateTime fromDate, DateTime toDate);
        Task<bool> FundTranser(string source, string destination, double amount);
    }
}

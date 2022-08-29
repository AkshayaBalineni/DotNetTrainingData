using BankingCommonLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingBussinessLayer.cs.Contracts
{
    public interface ICustomerAsyncManager
    {

        /// <summary>
        /// Method that view balance of customers Account
        /// </summary>
        /// <param name="accountNumber"></param>
        /// <param name="custId"></param>
        /// <returns>returns balance</returns>
        Task<double> BalanceEnqiry(string custId, string accountNumber);
        /// <summary>
        /// method that returns Minstatement for account
        /// </summary>
        /// <param name="custId"></param>
        /// <param name="accountNumber"></param>
        /// <returns></returns>
        Task<IEnumerable<Transaction>> Ministatement(string custId, string accountNumber);
        Task<IEnumerable<Transaction>> CustomisedStatement(String accountNumber, DateTime fromDate, DateTime toDate);
        Task<bool> FundTranser(string source, string destination, double amount);
    }
}

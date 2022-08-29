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
    public class CustomerManagerAsyncImpl : ICustomerAsyncManager
    {
        private readonly ICustomerAsyncRepo customerAsyncRepo;

        public CustomerManagerAsyncImpl(ICustomerAsyncRepo customerAsyncRepo)
        {
            this.customerAsyncRepo = customerAsyncRepo;
        }
        /// <summary>
        /// Method that view balance of customers Account
        /// </summary>
        /// <param name="account">AccountCopy Model</param>
        /// <returns>returns balance</returns>
        public Task<double> BalanceEnqiry(string custId, string accountNumber)
        {
            return this.customerAsyncRepo.BalanceEnqiry( custId, accountNumber);
        }
        public Task<IEnumerable<Transaction>> CustomisedStatement(string accountNumber, DateTime fromDate, DateTime toDate)
        {
            return this.customerAsyncRepo.CustomisedStatement(accountNumber, fromDate, toDate);
        }
        public Task<bool> FundTranser(string source, string destination, double amount)
        {
            return this.customerAsyncRepo.FundTranser(source, destination, amount);
        }
        public Task<IEnumerable<Transaction>> Ministatement(string custId, string accountNumber)
        {
            return this.customerAsyncRepo.Ministatement(custId, accountNumber);
        }
    }
}

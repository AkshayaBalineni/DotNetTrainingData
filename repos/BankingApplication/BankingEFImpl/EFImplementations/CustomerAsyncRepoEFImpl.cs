using BankingCommonLayer.Models;
using BankingDataLayer.Contracts;
using BankingEFImpl.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingEFImpl.EFImplementations
{
    public class CustomerAsyncRepoEFImpl : ICustomerAsyncRepo
    {
        private readonly db_bankingContext context;

        public CustomerAsyncRepoEFImpl(db_bankingContext context)
        {
            this.context = context;
        }
        public async Task<double> BalanceEnqiry(string custId, string accountNumber)
        {
            double balance = -1;
            if (accountNumber.Contains("CA"))
            {
                var caAcc = await this.context.CurrentAccounts.FirstOrDefaultAsync(x => x.CurrentAccountNo == accountNumber);
                var accountdb = await this.context.Accounts.FirstOrDefaultAsync(x => x.AccountNumber == caAcc.AccountNumber && x.IsDeleted == false && x.CustomerId == custId);
                if (accountdb != null)
                {
                    return accountdb.Balance;

                }
            }
            if (accountNumber.Contains("SA"))
            {
                var caAcc = await this.context.SavingsAccounts.FirstOrDefaultAsync (x => x.SavingsAccountNo == accountNumber);
                var accountdb = await this.context.Accounts.FirstOrDefaultAsync (x => x.AccountNumber == caAcc.AccountNumber && x.IsDeleted == false && x.CustomerId == custId);
                if (accountdb != null)
                {
                    return accountdb.Balance;

                }
            }
            if (accountNumber.Contains("CO"))
            {
                var caAcc = await this.context.CorporateAccounts.FirstOrDefaultAsync(x => x.CorporateAccountNo == accountNumber);
                var accountdb = await this.context.Accounts.FirstOrDefaultAsync(x => x.AccountNumber == caAcc.AccountNumber && x.IsDeleted == false && x.CustomerId == custId);
                if (accountdb != null)
                {
                    return accountdb.Balance;

                }
            }
            return balance;
        }

        public async Task<IEnumerable<BankingCommonLayer.Models.Transaction>> Ministatement(string customerId, string AccountNumber)
        {
            List<Models.Transaction> transactionsDb = new List<Models.Transaction>();
            if (AccountNumber.ToLower().Contains("sa"))
            {
                var savAcc = await this.context.SavingsAccounts.FirstOrDefaultAsync(x => x.SavingsAccountNo == AccountNumber);
                if (savAcc is not null)
                {
                    var accountDb = await this.context.Accounts.FirstOrDefaultAsync(x => x.AccountNumber == savAcc.AccountNumber && x.CustomerId == customerId);
                    if (accountDb != null)
                    {
                        transactionsDb = this.context.Transactions.Where(x => x.AccountNumber == accountDb.AccountNumber).ToList();
                    }
                }
                else
                {
                    return null;
                }

            }
            if (AccountNumber.ToLower().Contains("co"))
            {
                var coAcc = await this.context.CorporateAccounts.FirstOrDefaultAsync(x => x.CorporateAccountNo == AccountNumber);
                if (coAcc is not null)
                {
                    var accountDb = await this.context.Accounts.FirstOrDefaultAsync(x => x.AccountNumber == coAcc.AccountNumber && x.CustomerId == customerId);
                    if (accountDb != null)
                    {
                        transactionsDb = this.context.Transactions.Where(x => x.AccountNumber == accountDb.AccountNumber).ToList();
                    }
                }
                else
                {
                    return null;
                }
            }
            if (AccountNumber.ToLower().Contains("ca"))
            {
                var caAcc = await this.context.CurrentAccounts.FirstOrDefaultAsync(x => x.CurrentAccountNo == AccountNumber);
                if (caAcc is not null)
                {
                    var accountDb = await this.context.Accounts.FirstOrDefaultAsync(x => x.AccountNumber == caAcc.AccountNumber && x.CustomerId == customerId);
                    if (accountDb != null)
                    {
                        transactionsDb = this.context.Transactions.Where(x => x.AccountNumber == accountDb.AccountNumber).ToList();

                    }
                }
                else
                {
                    return null;
                }
            }
            if ( transactionsDb.Count() > 0)
            {
                var transactions = (from t in transactionsDb
                                    select new BankingCommonLayer.Models.Transaction()
                                    {
                                        TransactionId = t.TransactionId,
                                        AccountNo = t.AccountNumber,
                                        SourceAccountNo = t.SourceAccount,
                                        DestinationAccountNo = t.DestinationAccountNo,
                                        TransactionAmount = t.TransactionAmount,
                                        TransactionType = t.TransactionType,
                                        TransactionDescription = t.TransactionDescription
                                    }).Reverse().Take(5).ToList();
                return transactions;
            }
            return null;
        }

        public async Task<IEnumerable<BankingCommonLayer.Models.Transaction>> CustomisedStatement(string accountNumber, DateTime fromDate, DateTime toDate)
        {
            List<BankingCommonLayer.Models.Transaction> transactions = new List<BankingCommonLayer.Models.Transaction>();
            List<Models.Transaction> transactionsDb = await
                this.context.Transactions.Where(x => x.SourceAccount == accountNumber
                    || x.DestinationAccountNo == accountNumber).ToListAsync();
            if (transactionsDb.Count > 0)
            {
                for (int i = 0; i < transactionsDb.Count(); i++)
                {
                    if (transactionsDb[i].TransactionDate >= fromDate &&
                        transactionsDb[i].TransactionDate <= toDate && fromDate <= DateTime.UtcNow && toDate <= DateTime.UtcNow)
                    {
                        var transaction = new BankingCommonLayer.Models.Transaction()
                        {
                            TransactionId = transactionsDb[i].TransactionId,
                            SourceAccountNo = transactionsDb[i].SourceAccount,
                            DestinationAccountNo = transactionsDb[i].DestinationAccountNo,
                            TransactionAmount = transactionsDb[i].TransactionAmount,
                            TransactionDate = transactionsDb[i].TransactionDate,
                            TransactionDescription = transactionsDb[i].TransactionDescription,
                            TransactionType = transactionsDb[i].TransactionType
                        };
                        transactions.Add(transaction);
                    }
                }
            }
            return transactions;
        }

        public async Task<bool> FundTranser(string source, string destination, double amount)
        {
            bool isSuccess = false;
            if (amount > 0 && source.ToLower().Contains("co"))
            {
                var coAcc = await this.context.CorporateAccounts.FirstOrDefaultAsync(x => x.CorporateAccountNo == source);
                var accountdb = await this.context.Accounts.FirstOrDefaultAsync(x => x.AccountNumber == coAcc.AccountNumber && x.IsDeleted == false);
                if (accountdb != null)
                {
                    if (coAcc.WithdrawlLimit >= amount && accountdb.Balance >= amount)
                    {
                        accountdb.Balance = accountdb.Balance - amount;
                        coAcc.WithdrawlLimit = coAcc.WithdrawlLimit - amount;
                        Models.Transaction transaction = new Models.Transaction()
                        {
                            AccountNumber = accountdb.AccountNumber,
                            SourceAccount = source,
                            DestinationAccountNo = destination,
                            TransactionAmount = amount,
                            TransactionDate = DateTime.UtcNow,
                            TransactionType = "Transfer",
                            TransactionDescription = "transfering Amt"
                        };
                       await this.context.Transactions.AddAsync(transaction);
                        isSuccess = true;
                    }
                }
            }
            if (amount > 0 && source.ToLower().Contains("sa"))
            {
                var saAcc = await this.context.SavingsAccounts.FirstOrDefaultAsync(x => x.SavingsAccountNo == source);
                var accountdb = await this.context.Accounts.FirstOrDefaultAsync(x => x.AccountNumber == saAcc.AccountNumber && x.IsDeleted == false);
                if (accountdb != null)
                {
                    //double limit = coAcc.WithdrawlLimit;
                    if (saAcc.WithdrawlLimit >= amount && accountdb.Balance >= amount && (amount > saAcc.MinimumBalance) && ((accountdb.Balance - amount) >= saAcc.MinimumBalance))
                    {
                        accountdb.Balance = accountdb.Balance - amount;
                        saAcc.WithdrawlLimit = saAcc.WithdrawlLimit - amount;
                        Models.Transaction transaction = new Models.Transaction()
                        {
                            AccountNumber = accountdb.AccountNumber,
                            SourceAccount = source,
                            DestinationAccountNo = destination,
                            TransactionAmount = amount,
                            TransactionDate = DateTime.UtcNow,
                            TransactionType = "Transfer",
                            TransactionDescription = "transfering Amt"
                        };
                       await this.context.Transactions.AddAsync(transaction);
                        isSuccess = true;
                    }

                }
            }
            if (amount > 0 && source.ToLower().Contains("ca"))
            {
                var caAcc = await this.context.CurrentAccounts.FirstOrDefaultAsync(x => x.CurrentAccountNo == source);
                var accountdb = await this.context.Accounts.FirstOrDefaultAsync(x => x.AccountNumber == caAcc.AccountNumber && x.IsDeleted == false);
                if (accountdb != null)
                {
                    if (caAcc.WithdrawlLimit >= amount && accountdb.Balance >= amount && amount > caAcc.MinimumBalance && ((accountdb.Balance - amount) >= caAcc.MinimumBalance))
                    {
                        accountdb.Balance = accountdb.Balance - amount;
                        caAcc.WithdrawlLimit = caAcc.WithdrawlLimit - amount;
                        Models.Transaction transaction = new Models.Transaction()
                        {
                            AccountNumber = accountdb.AccountNumber,
                            SourceAccount =source,
                            DestinationAccountNo = destination,
                            TransactionAmount = amount,
                            TransactionDate = DateTime.UtcNow,
                            TransactionType = "Transfer",
                            TransactionDescription = "transfering Amt"
                        };
                        await this.context.Transactions.AddAsync(transaction);
                        isSuccess = true;
                    }
                }
            }
            if (isSuccess)
            {
                if (destination.ToLower().Contains("co"))
                {
                    var coAcc = await this.context.CorporateAccounts.FirstOrDefaultAsync(x => x.CorporateAccountNo == destination);
                    var accountdb = await this.context.Accounts.FirstOrDefaultAsync(x => x.AccountNumber == coAcc.AccountNumber && x.IsDeleted == false);
                    if (accountdb != null)
                    {
                        accountdb.Balance = accountdb.Balance + amount;
                        await this.context.SaveChangesAsync();
                    }
                }
                if (destination.ToLower().Contains("sa"))
                {
                    var saAcc = await this.context.SavingsAccounts.FirstOrDefaultAsync(x => x.SavingsAccountNo == destination);
                    var accountdb = await this.context.Accounts.FirstOrDefaultAsync(x => x.AccountNumber == saAcc.AccountNumber && x.IsDeleted == false);
                    if (accountdb != null)
                    {
                        accountdb.Balance = accountdb.Balance + amount;
                        await this.context.SaveChangesAsync();
                    }
                }
                if (destination.ToLower().Contains("ca"))
                {
                    var caAcc = await this.context.CurrentAccounts.FirstOrDefaultAsync(x => x.CurrentAccountNo == destination);
                    var accountdb = await this.context.Accounts.FirstOrDefaultAsync(x => x.AccountNumber == caAcc.AccountNumber && x.IsDeleted == false);
                    if (accountdb != null)
                    {
                        accountdb.Balance = accountdb.Balance + amount;
                        await this.context.SaveChangesAsync();
                    }
                }
            }
            return isSuccess;
        }
    }
}

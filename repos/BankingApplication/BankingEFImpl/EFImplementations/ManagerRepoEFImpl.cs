using BankingCommonLayer.Models;
using BankingDataLayer.Contracts;
using BankingEFImpl.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BankingEFImpl.EFImplementations
{
    public class ManagerRepoEFImpl : IManagerRepository
    {
        private readonly db_bankingContext context;

        public ManagerRepoEFImpl(db_bankingContext context)
        {
            this.context = context;
        }
        public BankingCommonLayer.Models.Customer GetCustomer(string customerId)
        {
            var customerDb = this.context.Customers.FirstOrDefault(x => x.CustomerId == customerId && x.IsDeleted == false);
            if (customerDb == null)
            {
                return null;
            }
            var customer = new BankingCommonLayer.Models.Customer()
            {
                CustomerId = customerDb.CustomerId,
                FirstName = customerDb.FirstName,
                LastName = customerDb.LastName,
                Gender = customerDb.Gender,
                Dob = customerDb.Dob,
                City = customerDb.City,
                State = customerDb.State,
                Pincode = customerDb.Pincode,
                MobileNumber = customerDb.MobileNumber,
                EmailId = customerDb.EmailId
            };

            return customer;
        }
        public string AddNewCustomer(BankingCommonLayer.Models.Customer customer)
        {
            try
            {
                var isDuplicate = this.context.Customers.FirstOrDefault(c => c.EmailId.Equals(customer.EmailId));
                if (isDuplicate == null)
                {
                    var customerDb = new Models.Customer()
                    {
                        FirstName = customer.FirstName,
                        LastName = customer.LastName,
                        Dob = customer.Dob,
                        EmailId = customer.EmailId,
                        Gender = customer.Gender,
                        City = customer.City,
                        ManagerId = customer.ManagerId,
                        State = customer.State,
                        Pincode = customer.Pincode,
                        MobileNumber = customer.MobileNumber,
                        IsDeleted = false
                    };
                    this.context.Customers.Add(customerDb);
                    this.context.SaveChanges();
                    return customerDb.CustomerId;
                }
                else
                {
                    return "Emaild Already Exists";
                }
            }
            catch (Exception e)
            {
                return e.Message;
            }

        }
        public string UpdateCustomer(BankingCommonLayer.Models.Customer updatedCustomer)
        {
            var customerDb = this.context.Customers.FirstOrDefault(x => x.CustomerId.Equals(updatedCustomer.CustomerId));
            try
            {
                if (customerDb != null)
                {
                    customerDb.FirstName = updatedCustomer.FirstName;
                    customerDb.LastName = updatedCustomer.LastName;
                    customerDb.Dob = updatedCustomer.Dob;
                    customerDb.EmailId = updatedCustomer.EmailId;
                    customerDb.Gender = updatedCustomer.Gender;
                    customerDb.City = updatedCustomer.City;
                    customerDb.ManagerId = updatedCustomer.ManagerId;
                    customerDb.State = updatedCustomer.State;
                    customerDb.Pincode = updatedCustomer.Pincode;
                    customerDb.MobileNumber = updatedCustomer.MobileNumber;

                    //this.context.Update(customerDb);
                    context.SaveChanges();
                    return customerDb.CustomerId;
                }
                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public string DeleteCustomer(string customerId)
        {
            var customerDb = this.context.Customers.FirstOrDefault(x => x.CustomerId.Equals(customerId));
            if (customerDb != null)
            {
                var accountCus = this.context.Accounts.FirstOrDefault(a => a.CustomerId.Equals(customerId) && a.IsDeleted == false);
                if (accountCus is null)
                {
                    customerDb.IsDeleted = true;
                    this.context.SaveChanges();
                    return customerId;
                }
                else
                {
                    return "Customer holding account can't be deleted";
                }
            }
            return "Customer doesn't exists";
        }
        public string AddAccount(BankingCommonLayer.Models.Account account)
        {
            /*var customerexists = this.context.Customers.FirstOrDefault(x => x.CustomerId == account.CustomerId);
            if (customerexists is null)
            {
                return null;
            }*/
            try
            {
                if ((account.AccountType.Equals("savings") || account.AccountType.Equals("current") || account.AccountType.Equals("corporate")))
                {
                    var dupTin = this.context.Accounts.FirstOrDefault(x => x.CustomerId != account.CustomerId && x.Tin == account.Tin);
                    if (dupTin is not null)
                    {
                        return "Tin Number Already Exists";
                    }
                    Models.Account accountdb = new Models.Account()
                    {
                        CustomerId = account.CustomerId,
                        Balance = account.Balance,
                        Ifsc = "HDFC0001",
                        Tin = account.Tin,
                        AccountType = account.AccountType
                    };

                    if (account.AccountType.Equals("savings"))
                    {
                        var duplicateSavings = context.Accounts.FirstOrDefault(x => x.CustomerId == account.CustomerId && x.AccountType == "savings" && x.IsDeleted == false);
                        if (duplicateSavings is null && dupTin is null)
                        {
                            BankingCommonLayer.Models.SavingsAccount savingsAccount = ((BankingCommonLayer.Models.SavingsAccount)account);
                            if (savingsAccount.Balance >= 1000)
                            {
                                this.context.Accounts.Add(accountdb);
                                this.context.SaveChanges();
                                Models.SavingsAccount savingdb = new Models.SavingsAccount()
                                {
                                    AccountNumber = accountdb.AccountNumber,
                                    MinimumBalance = 1000,
                                    WithdrawlLimit = 100000
                                };
                                this.context.SavingsAccounts.Add(savingdb);
                                this.context.SaveChanges();
                                return savingdb.SavingsAccountNo;
                            }
                            else
                            {
                                return "To Open Savings Account Minimum balance should be 1000";
                            }

                        }
                        else
                        {
                            return "Already Savings account Exits!";
                        }
                    }
                    if (account.AccountType.Equals("corporate"))
                    {

                        var corporateDuplicate = context.Accounts.FirstOrDefault(x => x.CustomerId == account.CustomerId && x.AccountType == "corporate" && x.IsDeleted == false);
                        if (corporateDuplicate is null && dupTin is null)
                        {

                            BankingCommonLayer.Models.CorporateAccount corporateAccount = ((BankingCommonLayer.Models.CorporateAccount)account);
                            if (corporateAccount.Balance >= 0)
                            {
                                this.context.Accounts.Add(accountdb);
                                this.context.SaveChanges();
                                Models.CorporateAccount corporatedb = new Models.CorporateAccount()
                                {
                                    AccountNumber = accountdb.AccountNumber,
                                    MinimumBalance = 0,
                                    WithdrawlLimit = 200000
                                };
                                this.context.CorporateAccounts.Add(corporatedb);
                                this.context.SaveChanges();
                                return corporatedb.CorporateAccountNo;
                            }
                        }
                        else
                        {
                            return "Already Corporate account Exits!";
                        }
                    }

                    if (account.AccountType.Equals("current"))
                    {
                        var duplicateCurrent = context.Accounts.FirstOrDefault(x => x.CustomerId == account.CustomerId && x.AccountType == "current" && x.Tin == account.Tin && x.IsDeleted == false);
                        if (duplicateCurrent is null && dupTin is null)
                        {
                            BankingCommonLayer.Models.CurrentAccount currentAccount = ((BankingCommonLayer.Models.CurrentAccount)account);
                            if (currentAccount.Balance >= 5000)
                            {
                                this.context.Accounts.Add(accountdb);
                                this.context.SaveChanges();
                                Models.CurrentAccount currentdb = new Models.CurrentAccount()
                                {
                                    AccountNumber = accountdb.AccountNumber,
                                    MinimumBalance = 5000,
                                    WithdrawlLimit = 500000
                                };
                                this.context.CurrentAccounts.Add(currentdb);
                                this.context.SaveChanges();
                                return currentdb.CurrentAccountNo;
                            }
                            else
                            {
                                return "To Open Current Account Minimum Balance should be 5000";
                            }
                        }
                        else
                        {
                            return "CurrentAccount with Same GSTIN Already Exits!";
                        }
                    }

                    // this.context.Accounts.Remove(accountdb);
                }
                return "Account is not Created Check the details";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        public string DeleteAccount(string accountId)
        {
            try
            {

                if (accountId.ToLower().Contains("sa"))
                {
                    var dbsaving = this.context.SavingsAccounts.FirstOrDefault(x => x.SavingsAccountNo == accountId);
                    var dbaccount = this.context.Accounts.FirstOrDefault(x => x.AccountNumber == dbsaving.AccountNumber);
                    if (dbaccount is not null)
                    {
                        dbaccount.IsDeleted = true;
                        context.SaveChanges();
                        return accountId;
                    }
                }
                if (accountId.ToLower().Contains("ca"))
                {
                    var dbsaving = this.context.CurrentAccounts.FirstOrDefault(x => x.CurrentAccountNo == accountId);
                    var dbaccount = this.context.Accounts.FirstOrDefault(x => x.AccountNumber == dbsaving.AccountNumber);
                    if (dbaccount is not null)
                    {
                        dbaccount.IsDeleted = true;
                        context.SaveChanges();
                        return accountId;
                    }
                }
                if (accountId.ToLower().Contains("co"))
                {
                    var dbsaving = this.context.CorporateAccounts.FirstOrDefault(x => x.CorporateAccountNo == accountId);
                    var dbaccount = this.context.Accounts.FirstOrDefault(x => x.AccountNumber == dbsaving.AccountNumber);
                    if (dbaccount is not null)
                    {
                        dbaccount.IsDeleted = true;
                        context.SaveChanges();
                        return accountId;
                    }
                }
                return null;
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public string UpdateAccount(AccountCopy account)
        {
            try
            {
                if (account.AccountNumber.ToLower().Contains("co"))
                {
                    var corporateAcc = this.context.CorporateAccounts.FirstOrDefault(x => x.CorporateAccountNo == account.AccountNumber);
                    var accountdb = this.context.Accounts.FirstOrDefault(x => x.AccountNumber == corporateAcc.AccountNumber);
                    var dupliacc = this.context.Accounts.FirstOrDefault(x => x.AccountType == account.AccountType && x.CustomerId == accountdb.CustomerId);
                    if (dupliacc == null) /* accountdb != null && */
                    {

                        if (account.AccountType == "savings")
                        {
                            accountdb.AccountType = account.AccountType;
                            var total = accountdb.Balance + account.Balance;
                            Models.SavingsAccount savingsAccount = new Models.SavingsAccount()
                            {
                                AccountNumber = accountdb.AccountNumber,
                                MinimumBalance = 1000,
                                WithdrawlLimit = 100000
                            };
                            if (total >= savingsAccount.MinimumBalance)
                            {
                                accountdb.Balance = total;
                                this.context.SavingsAccounts.Add(savingsAccount);
                                this.context.CorporateAccounts.Remove(corporateAcc);
                                this.context.SaveChanges();
                                return savingsAccount.SavingsAccountNo;
                            }
                            else
                            {
                                return "To Create Saving account Minimum Balance should be 1000";
                            }
                        }
                    }
                    else
                    {
                        return "You Can't Create Multiple Accounts of same type!";
                    }
                }
                if (account.AccountNumber.ToLower().Contains("sa"))
                {
                    var savingsAcc = this.context.SavingsAccounts.FirstOrDefault(x => x.SavingsAccountNo == account.AccountNumber);
                    var accountdb = this.context.Accounts.FirstOrDefault(x => x.AccountNumber == savingsAcc.AccountNumber);
                    var dupliacc = this.context.Accounts.FirstOrDefault(x => x.AccountType == account.AccountType && x.CustomerId == accountdb.CustomerId);
                    if (dupliacc == null)
                    {
                        if (account.AccountType == "corporate" && dupliacc == null)
                        {
                            accountdb.AccountType = account.AccountType;
                            var total = accountdb.Balance + account.Balance;

                            Models.CorporateAccount corporateDb = new Models.CorporateAccount()
                            {
                                AccountNumber = accountdb.AccountNumber,
                                MinimumBalance = 0,
                                WithdrawlLimit = 200000
                            };
                            if (total >= corporateDb.MinimumBalance)
                            {
                                accountdb.Balance = total;
                                this.context.CorporateAccounts.Add(corporateDb);
                                this.context.SavingsAccounts.Remove(savingsAcc);
                                this.context.SaveChanges();
                                return corporateDb.CorporateAccountNo;
                            }
                        }
                    }
                    else
                    {
                        return "You Can't Create Multiple Accounts of same type!";
                    }
                }
                return "Service is not available for current Account! Check Your Account Number";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        public string Withdraw(AccountCopy account)
        {
            try
            {
                if (account.AccountNumber.ToLower().Contains("co"))
                {
                    var coAcc = this.context.CorporateAccounts.FirstOrDefault(x => x.CorporateAccountNo == account.AccountNumber);
                    var accountdb = this.context.Accounts.FirstOrDefault(x => x.AccountNumber == coAcc.AccountNumber);
                    if (accountdb.Balance >= account.Amount)
                    {
                        if (coAcc.WithdrawlLimit >= account.Amount)
                        {
                            accountdb.Balance = accountdb.Balance - account.Amount;
                            coAcc.WithdrawlLimit = coAcc.WithdrawlLimit - account.Amount;
                            Models.Transaction transaction = new Models.Transaction()
                            {
                                AccountNumber = accountdb.AccountNumber,
                                SourceAccount = account.AccountNumber,
                                DestinationAccountNo = "null",
                                TransactionAmount = account.Amount,
                                TransactionDate = DateTime.UtcNow,
                                TransactionType = "withdraw",
                                TransactionDescription = account.description
                            };
                            this.context.Transactions.Add(transaction);
                            this.context.SaveChanges();
                            return account.AccountNumber;
                        }
                        else
                        {
                            return "Withdraw Limit Exceeded";
                        }
                    }
                    else
                    {
                        return "Insufficient Funds";
                    }
                }
                if (account.AccountNumber.ToLower().Contains("sa"))
                {
                    var saAcc = this.context.SavingsAccounts.FirstOrDefault(x => x.SavingsAccountNo == account.AccountNumber);
                    var accountdb = this.context.Accounts.FirstOrDefault(x => x.AccountNumber == saAcc.AccountNumber && x.IsDeleted == false);
                    if (saAcc.WithdrawlLimit >= account.Amount)
                    {
                        //double limit = coAcc.WithdrawlLimit;saAcc.WithdrawlLimit >= account.Amount &&
                        if (accountdb.Balance >= account.Amount && ((accountdb.Balance - account.Amount) >= saAcc.MinimumBalance))
                        {
                            accountdb.Balance = accountdb.Balance - account.Amount;
                            saAcc.WithdrawlLimit = saAcc.WithdrawlLimit - account.Amount;
                            Models.Transaction transaction = new Models.Transaction()
                            {
                                AccountNumber = accountdb.AccountNumber,
                                SourceAccount = account.AccountNumber,
                                DestinationAccountNo = "null",
                                TransactionAmount = account.Amount,
                                TransactionDate = DateTime.UtcNow,
                                TransactionType = "withdraw",
                                TransactionDescription = account.description
                            };
                            this.context.Transactions.Add(transaction);
                            this.context.SaveChanges();
                            return account.AccountNumber;
                        }
                        else
                        {
                            return "Insufficient Funds";
                        }
                    }
                    else
                    {
                        return "Withdraw Limit Exceded";
                    }
                }
                if (account.AccountNumber.ToLower().Contains("ca"))
                {
                    var caAcc = this.context.CurrentAccounts.FirstOrDefault(x => x.CurrentAccountNo == account.AccountNumber);
                    var accountdb = this.context.Accounts.FirstOrDefault(x => x.AccountNumber == caAcc.AccountNumber && x.IsDeleted == false);
                    if (caAcc.WithdrawlLimit >= account.Amount)
                    {
                        if (accountdb.Balance >= account.Amount && ((accountdb.Balance - account.Amount) >= caAcc.MinimumBalance))
                        {
                            accountdb.Balance = accountdb.Balance - account.Amount;
                            caAcc.WithdrawlLimit = caAcc.WithdrawlLimit - account.Amount;
                            Models.Transaction transaction = new Models.Transaction()
                            {
                                AccountNumber = accountdb.AccountNumber,
                                SourceAccount = account.AccountNumber,
                                DestinationAccountNo = "null",
                                TransactionAmount = account.Amount,
                                TransactionDate = DateTime.UtcNow,
                                TransactionType = "withdraw",
                                TransactionDescription = account.description
                            };
                            this.context.Transactions.Add(transaction);
                            this.context.SaveChanges();
                            return account.AccountNumber;
                        }
                        else
                        {
                            return "Insufficient Funds!";
                        }
                    }
                    else
                    {
                        return "Withdraw Limit Exceded!";
                    }
                }
                return "With-draw Failed!";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        public string Deposit(AccountCopy account)
        {
            try
            {
                if (account.AccountNumber.ToLower().Contains("co"))
                {
                    var coAcc = this.context.CorporateAccounts.FirstOrDefault(x => x.CorporateAccountNo == account.AccountNumber);
                    var accountdb = this.context.Accounts.FirstOrDefault(x => x.AccountNumber == coAcc.AccountNumber);
                    if (accountdb != null)
                    {
                        accountdb.Balance = accountdb.Balance + account.Amount;
                        Models.Transaction transaction = new Models.Transaction()
                        {
                            AccountNumber = accountdb.AccountNumber,
                            SourceAccount = account.AccountNumber,
                            DestinationAccountNo = "null",
                            TransactionAmount = account.Amount,
                            TransactionDate = DateTime.UtcNow,
                            TransactionType = "Deposit",
                            TransactionDescription = account.description
                        };
                        this.context.Transactions.Add(transaction);
                        this.context.SaveChanges();
                        return account.AccountNumber;

                    }
                }
                if (account.AccountNumber.ToLower().Contains("sa"))
                {
                    var saAcc = this.context.SavingsAccounts.FirstOrDefault(x => x.SavingsAccountNo == account.AccountNumber);
                    var accountdb = this.context.Accounts.FirstOrDefault(x => x.AccountNumber == saAcc.AccountNumber);
                    if (accountdb != null)
                    {
                        accountdb.Balance = accountdb.Balance + account.Amount;
                        Models.Transaction transaction = new Models.Transaction()
                        {
                            AccountNumber = accountdb.AccountNumber,
                            SourceAccount = account.AccountNumber,
                            DestinationAccountNo = "null",
                            TransactionAmount = account.Amount,
                            TransactionDate = DateTime.UtcNow,
                            TransactionType = "Deposit",
                            TransactionDescription = account.description
                        };
                        this.context.Transactions.Add(transaction);
                        this.context.SaveChanges();
                        return account.AccountNumber;
                    }
                }
                if (account.AccountNumber.ToLower().Contains("ca"))
                {
                    var caAcc = this.context.CurrentAccounts.FirstOrDefault(x => x.CurrentAccountNo == account.AccountNumber);
                    var accountdb = this.context.Accounts.FirstOrDefault(x => x.AccountNumber == caAcc.AccountNumber);
                    if (accountdb != null)
                    {
                        accountdb.Balance = accountdb.Balance + account.Amount;
                        Models.Transaction transaction = new Models.Transaction()
                        {
                            AccountNumber = accountdb.AccountNumber,
                            SourceAccount = account.AccountNumber,
                            DestinationAccountNo = "null",
                            TransactionAmount = account.Amount,
                            TransactionDate = DateTime.UtcNow,
                            TransactionType = "Deposit",
                            TransactionDescription = account.description
                        };
                        this.context.Transactions.Add(transaction);
                        this.context.SaveChanges();
                        return account.AccountNumber;
                    }
                }
                return "Transaction Failed!";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public IEnumerable<BankingCommonLayer.Models.Transaction> Ministatement(string AccountNumber)
        {
            try
            {
                var transactionsDb = this.context.Transactions.Where(x => x.DestinationAccountNo == AccountNumber || x.SourceAccount == AccountNumber).ToList();
                if (transactionsDb.Count > 0)
                {
                    var transactions = from t in transactionsDb
                                       select new BankingCommonLayer.Models.Transaction()
                                       {
                                           TransactionId = t.TransactionId,
                                           AccountNo = t.AccountNumber,
                                           SourceAccountNo = t.SourceAccount,
                                           DestinationAccountNo = t.DestinationAccountNo,
                                           TransactionAmount = t.TransactionAmount,
                                           TransactionType = t.TransactionType,
                                           TransactionDescription = t.TransactionDescription
                                       };
                    return transactions;
                }
                return null;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public string FundTransfer(AccountCopy account)
        {
            try
            {
                bool isSuccess = false;
                if (account.SourceAccount.ToLower().Contains("co"))
                {
                    var coAcc = this.context.CorporateAccounts.FirstOrDefault(x => x.CorporateAccountNo == account.SourceAccount);
                    var accountdb = this.context.Accounts.FirstOrDefault(x => x.AccountNumber == coAcc.AccountNumber && x.IsDeleted == false);
                    if (coAcc.WithdrawlLimit >= account.Amount)
                    {
                        if (accountdb.Balance >= account.Amount && (accountdb.Balance - account.Amount >= coAcc.MinimumBalance))
                        {
                            accountdb.Balance = accountdb.Balance - account.Amount;
                            coAcc.WithdrawlLimit = coAcc.WithdrawlLimit - account.Amount;
                            Models.Transaction transaction = new Models.Transaction()
                            {
                                AccountNumber = accountdb.AccountNumber,
                                SourceAccount = account.SourceAccount,
                                DestinationAccountNo = account.DestinationAccount,
                                TransactionAmount = account.Amount,
                                TransactionDate = DateTime.UtcNow,
                                TransactionType = "Transfer",
                                TransactionDescription = "transfering Amt"
                            };
                            this.context.Transactions.Add(transaction);
                            isSuccess = true;
                        }
                        else
                        {
                            return "Insufficient Funds!";
                        }
                    }
                    else
                    {
                        return "Withdraw Amount Exceded";
                    }
                }
                if (account.SourceAccount.ToLower().Contains("sa"))
                {
                    var saAcc = this.context.SavingsAccounts.FirstOrDefault(x => x.SavingsAccountNo == account.SourceAccount);
                    var accountdb = this.context.Accounts.FirstOrDefault(x => x.AccountNumber == saAcc.AccountNumber && x.IsDeleted == false);
                    if (saAcc.WithdrawlLimit >= account.Amount)
                    {
                        //double limit = coAcc.WithdrawlLimit;
                        if (accountdb.Balance >= account.Amount && ((accountdb.Balance - account.Amount) >= saAcc.MinimumBalance))
                        {
                            accountdb.Balance = accountdb.Balance - account.Amount;
                            saAcc.WithdrawlLimit = saAcc.WithdrawlLimit - account.Amount;
                            Models.Transaction transaction = new Models.Transaction()
                            {
                                AccountNumber = accountdb.AccountNumber,
                                SourceAccount = account.SourceAccount,
                                DestinationAccountNo = account.DestinationAccount,
                                TransactionAmount = account.Amount,
                                TransactionDate = DateTime.UtcNow,
                                TransactionType = "Transfer",
                                TransactionDescription = "transfering Amt"
                            };
                            this.context.Transactions.Add(transaction);
                            isSuccess = true;
                        }
                        else
                        {
                            return "Insufficienct Balance";
                        }
                    }
                    else
                    {
                        return "Withdraw Limit Exceded";
                    }
                }
                if (account.SourceAccount.ToLower().Contains("ca"))
                {
                    var caAcc = this.context.CurrentAccounts.FirstOrDefault(x => x.CurrentAccountNo == account.SourceAccount);
                    var accountdb = this.context.Accounts.FirstOrDefault(x => x.AccountNumber == caAcc.AccountNumber && x.IsDeleted == false);
                    if (caAcc.WithdrawlLimit >= account.Amount)
                    {
                        if (accountdb.Balance >= account.Amount &&  ((accountdb.Balance - account.Amount) >= caAcc.MinimumBalance))
                        {
                            accountdb.Balance = accountdb.Balance - account.Amount;
                            caAcc.WithdrawlLimit = caAcc.WithdrawlLimit - account.Amount;
                            Models.Transaction transaction = new Models.Transaction()
                            {
                                AccountNumber = accountdb.AccountNumber,
                                SourceAccount = account.SourceAccount,
                                DestinationAccountNo = account.DestinationAccount,
                                TransactionAmount = account.Amount,
                                TransactionDate = DateTime.UtcNow,
                                TransactionType = "Transfer",
                                TransactionDescription = "transfering Amt"
                            };
                            this.context.Transactions.Add(transaction);
                            isSuccess = true;
                        }
                        else
                        {
                            return "Insufficient Funds";
                        }
                    }
                    else
                    {
                        return "Withdraw Limit Exceeds";
                    }
                }
                if (isSuccess)
                {
                    if (account.DestinationAccount.ToLower().Contains("co"))
                    {
                        var coAcc = this.context.CorporateAccounts.FirstOrDefault(x => x.CorporateAccountNo == account.DestinationAccount);
                        var accountdb = this.context.Accounts.FirstOrDefault(x => x.AccountNumber == coAcc.AccountNumber);
                        if (accountdb != null)
                        {
                            accountdb.Balance = accountdb.Balance + account.Amount;
                        }
                    }
                    if (account.DestinationAccount.ToLower().Contains("sa"))
                    {
                        var saAcc = this.context.SavingsAccounts.FirstOrDefault(x => x.SavingsAccountNo == account.DestinationAccount);
                        var accountdb = this.context.Accounts.FirstOrDefault(x => x.AccountNumber == saAcc.AccountNumber);
                        if (accountdb != null)
                        {
                            accountdb.Balance = accountdb.Balance + account.Amount;
                        }
                    }
                    if (account.DestinationAccount.ToLower().Contains("ca"))
                    {
                        var caAcc = this.context.CurrentAccounts.FirstOrDefault(x => x.CurrentAccountNo == account.DestinationAccount);
                        var accountdb = this.context.Accounts.FirstOrDefault(x => x.AccountNumber == caAcc.AccountNumber);
                        if (accountdb != null)
                        {
                            accountdb.Balance = accountdb.Balance + account.Amount;
                        }
                    }
                    this.context.SaveChanges();
                    return account.SourceAccount;
                }
                return "Transaction Failed!";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        public double BalanceEnquiry(string id)
        {
            try
            {
                //double balance = 0;
                if (id.Contains("CA"))
                {
                    var caAcc = this.context.CurrentAccounts.FirstOrDefault(x => x.CurrentAccountNo == id);
                    var accountdb = this.context.Accounts.FirstOrDefault(x => x.AccountNumber == caAcc.AccountNumber && x.IsDeleted == false);
                    if (accountdb != null)
                    {
                        return accountdb.Balance;
                    }
                }
                if (id.Contains("SA"))
                {
                    var caAcc = this.context.SavingsAccounts.FirstOrDefault(x => x.SavingsAccountNo == id);
                    var accountdb = this.context.Accounts.FirstOrDefault(x => x.AccountNumber == caAcc.AccountNumber && x.IsDeleted == false);
                    if (accountdb != null)
                    {
                        return accountdb.Balance;
                    }
                }
                if (id.Contains("CO"))
                {
                    var caAcc = this.context.CorporateAccounts.FirstOrDefault(x => x.CorporateAccountNo == id);
                    var accountdb = this.context.Accounts.FirstOrDefault(x => x.AccountNumber == caAcc.AccountNumber && x.IsDeleted == false);
                    if (accountdb != null)
                    {
                        return accountdb.Balance;
                    }
                }
                return 0;
            }
            catch (Exception e)
            {
                return 0;
            }
        }
        public IEnumerable<BankingCommonLayer.Models.Customer> GetCustomer()
        {
            var customerDb = this.context.Customers;
            if (customerDb == null)
            {
                return null;
            }
            var customer = from c in customerDb
                           where c.IsDeleted == false
                           select new BankingCommonLayer.Models.Customer()
                           {
                               CustomerId = c.CustomerId,
                           };

            return customer.ToList();
        }
        public IEnumerable<BankingCommonLayer.Models.AccountCopy> GetAccounts()
        {
            List<AccountCopy> AccountNumbers = new List<AccountCopy>();
            var savingDB = this.context.SavingsAccounts;
            var corpoDB = this.context.CorporateAccounts;
            var currDB = this.context.CurrentAccounts;
           
            var saving = from s in savingDB
                         where s.AccountNumberNavigation.IsDeleted == false
                         select new AccountCopy()
                         {
                             AccountNumber = s.SavingsAccountNo
                         };
            var corporate = from co in corpoDB
                            where co.AccountNumberNavigation.IsDeleted == false
                            select new AccountCopy()
                            {
                                AccountNumber = co.CorporateAccountNo
                            };
            var current = from ca in currDB
                          where ca.AccountNumberNavigation.IsDeleted == false
                          select new AccountCopy()
                          {
                              AccountNumber = ca.CurrentAccountNo
                          };
            foreach (var item in saving)
                AccountNumbers.Add(item);
            foreach (var item in corporate)
                AccountNumbers.Add(item);
            foreach (var item in current)
                AccountNumbers.Add(item);

            return AccountNumbers;
        }
        public IEnumerable<BankingCommonLayer.Models.Transaction> CustomizedStatement(AccountCopy accountCopy)
        {
            try
            {
                List<BankingCommonLayer.Models.Transaction> transactions = new List<BankingCommonLayer.Models.Transaction>();
                List<Models.Transaction> transactionsDb =
                    this.context.Transactions.Where(x => x.SourceAccount == accountCopy.AccountNumber
                        || x.DestinationAccountNo == accountCopy.AccountNumber).ToList();
                if (transactionsDb.Count > 0)
                {
                    var actualNoOfTransactions = transactionsDb.Count();
                    if (accountCopy.NoOfTransactions == -1)
                    {
                        accountCopy.NoOfTransactions = actualNoOfTransactions;
                    }
                    else
                    {
                        accountCopy.NoOfTransactions = accountCopy.NoOfTransactions <= actualNoOfTransactions ?
                                                        accountCopy.NoOfTransactions : actualNoOfTransactions;
                    }
                    for (int i = 0; i < accountCopy.NoOfTransactions; i++)
                    {
                        if (transactionsDb[i].TransactionAmount <= accountCopy.LowerLimit
                            && (transactionsDb[i].TransactionDate >= accountCopy.FromDate &&
                            transactionsDb[i].TransactionDate <= accountCopy.ToDate))
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
            catch (Exception e)
            {
                return null;
            }
        }
    }
}

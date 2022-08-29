using BankingBussinessLayer.cs.Contracts;
using BankingCommonLayer.Models;
using BankingWebApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ShopOnWebApp.Util;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace BankingWebApp.Controllers
{
    public class ManagerController : Controller
    {
        private readonly IBankingManger bankingManger;

        public ManagerController(IBankingManger bankingManger)
        {
            this.bankingManger = bankingManger;
        }
        [HttpGet]
        public IActionResult AddCustomer()
        {
            if (HttpContext.Session.GetSession<ManagerLogin>("manager") is null)
            {
                return RedirectToAction("MangerLogin","Home");
            }
            return View();
        }
        [HttpPost]
        public IActionResult AddCustomer(NewCustomer newCustomer)
        {
            if (HttpContext.Session.GetSession<ManagerLogin>("manager") is null)
            {
                return RedirectToAction("MangerLogin", "Home");
            }
            if (ModelState.IsValid)
            {
                if(DateTime.UtcNow.Year - newCustomer.DOB.Year >= 18)
                {
                    string managerid = HttpContext.Session.GetString("managerId");
                    string customerId = bankingManger.AddNewCustomer(new BankingCommonLayer.Models.Customer()
                    {
                        FirstName = newCustomer.FirstName,
                        LastName = newCustomer.LastName,
                        Gender = newCustomer.Gender,
                        Dob = newCustomer.DOB,
                        EmailId = newCustomer.EmailId,
                        City = newCustomer.City,
                        State = newCustomer.State,
                        Pincode = newCustomer.Pincode,
                        ManagerId = managerid,
                        MobileNumber = newCustomer.MobileNumber
                    });
                    if (customerId.ToLower().Contains("c-"))
                    {
                        TempData["SuccessMessage"] = "Customer with " + customerId + " added successfully";
                        return RedirectToAction("SuccessAdd", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("", customerId);
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Only 18+ are allowed!");
                }
            }
            return View();
        }
        [HttpGet]
        public IActionResult TakeCustomerId()
        {
            if (HttpContext.Session.GetSession<ManagerLogin>("manager") is null)
            {
                return RedirectToAction("MangerLogin", "Home");
            }
            ViewBag.customers = this.bankingManger.GetCustomer();
            return View();
        }
        [HttpPost]
        public IActionResult TakeCustomerId(TakeCustomerId customer)
        {
            if (HttpContext.Session.GetSession<ManagerLogin>("manager") is null)
            {
                return RedirectToAction("MangerLogin", "Home");
            }
            ViewBag.customers = this.bankingManger.GetCustomer();
            HttpContext.Session.SetString("CustomerId", customer.CustomerId);
            var customerdata = bankingManger.GetCustomer(customer.CustomerId);
            if (customerdata is not null)
            {
                return RedirectToAction("UpdateCustomer");
            }
           return View();
         }
        [HttpGet]
        public IActionResult UpdateCustomer()
        {
            if (HttpContext.Session.GetSession<ManagerLogin>("manager") is null)
            {
                return RedirectToAction("MangerLogin", "Home");
            }
            ViewBag.CustomerData = bankingManger.GetCustomer(HttpContext.Session.GetString("CustomerId"));//JsonConvert.DeserializeObject(TempData["customer"].ToString());
            return View();
        }
        [HttpPost]
        public IActionResult UpdateCustomer(EditCustomer newCustomer)
        {
            if (HttpContext.Session.GetSession<ManagerLogin>("manager") is null)
            {
                return RedirectToAction("MangerLogin", "Home");
            }
            ViewBag.CustomerData = bankingManger.GetCustomer(HttpContext.Session.GetString("CustomerId"));
            if (ModelState.IsValid)
            {
                if(DateTime.UtcNow.Year - newCustomer.DOB.Year >= 18)
                {
                    string managerid = HttpContext.Session.GetString("managerId");
                    string customerId = bankingManger.UpdateCustomer(new BankingCommonLayer.Models.Customer()
                    {
                        CustomerId = newCustomer.CustomerId,
                        FirstName = newCustomer.FirstName,
                        LastName = newCustomer.LastName,
                        Gender = newCustomer.Gender,
                        Dob = newCustomer.DOB,
                        EmailId = newCustomer.EmailId,
                        City = newCustomer.City,
                        State = newCustomer.State,
                        Pincode = newCustomer.Pincode,
                        ManagerId = managerid,
                        MobileNumber = newCustomer.MobileNumber
                    });
                    if (customerId is not null)
                    {
                        TempData["SuccessMessage"] = "Customer with " + customerId + " Updated Successfully";
                        return RedirectToAction("SuccessAdd", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("", "No Such Customer");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Only 18+ are Allowed");
                }
            }
            return View("UpdateCustomer");
        } 
        [HttpGet]
        public IActionResult DeleteCustomer()
        {
            if (HttpContext.Session.GetSession<ManagerLogin>("manager") is null)
            {
                return RedirectToAction("MangerLogin", "Home");
            }
            ViewBag.customers = this.bankingManger.GetCustomer();
            return View();
        }
        [HttpPost]
        public IActionResult DeleteCustomer(TakeCustomerId DelCustomer)
        {
            if (HttpContext.Session.GetSession<ManagerLogin>("manager") is null)
            {
                return RedirectToAction("MangerLogin", "Home");
            }
            ViewBag.customers = this.bankingManger.GetCustomer();
            if (ModelState.IsValid)
            {
                string delId = DelCustomer.CustomerId;
                string deletedId = bankingManger.DeleteCustomer(delId);
                if (deletedId.ToLower().Contains("c-"))
                {
                    TempData["SuccessMessage"] = "Customer with " + deletedId + " Deleted Successfully";
                    return RedirectToAction("SuccessAdd", "Home");
                }
                else
                {
                    ModelState.AddModelError("", deletedId);
                }
                ModelState.AddModelError("", "Deletion Failed");
            }
            return View();
        }
        [HttpGet]
        public IActionResult AddAccount()
        {
            if (HttpContext.Session.GetSession<ManagerLogin>("manager") is null)
            {
                return RedirectToAction("MangerLogin", "Home");
            }
            var customers = this.bankingManger.GetCustomer();
            ViewBag.customers = customers;
            return View();
        }
        [HttpPost]
        public IActionResult AddAccount(NewAccount accountVM)
        {
            if (HttpContext.Session.GetSession<ManagerLogin>("manager") is null)
            {
                return RedirectToAction("MangerLogin", "Home");
            }
            ViewBag.customers = this.bankingManger.GetCustomer();
            if (ModelState.IsValid)
            {
                if (accountVM.DOC <= DateTime.UtcNow)
                {
                    if (accountVM.AccountType.ToLower().Equals("savings"))
                    {
                        string id = bankingManger.AddAccount(((Account)new SavingsAccount()
                        {
                            AccountType = accountVM.AccountType,
                            CustomerId = accountVM.CustomerId,
                            Balance = accountVM.Balance,
                            Doc = accountVM.DOC,
                            Tin = accountVM.Tin
                        }));
                        if (id.ToLower().Contains("sa-"))
                        {
                            TempData["SuccessMessage"] = "Account with " + id + " Created Successfully";
                            return RedirectToAction("SuccessAdd", "Home");
                        }
                        ModelState.AddModelError("", id);
                    }
                    if (accountVM.AccountType.ToLower().Equals("current"))
                    {
                        string id = bankingManger.AddAccount(((Account)new CurrentAccount()
                        {
                            AccountType = accountVM.AccountType,
                            CustomerId = accountVM.CustomerId,
                            Balance = accountVM.Balance,
                            Doc = accountVM.DOC,
                            Tin = accountVM.Tin
                        }));
                        if (id.ToLower().Contains("ca-"))
                        {
                            TempData["SuccessMessage"] = "Account with " + id + " Created Successfully";
                            return RedirectToAction("SuccessAdd", "Home");
                        }
                        ModelState.AddModelError("", id);
                    }
                    if (accountVM.AccountType.ToLower().Equals("corporate"))
                    {
                        string id = bankingManger.AddAccount((Account)new CorporateAccount()
                        {
                            AccountType = accountVM.AccountType,
                            CustomerId = accountVM.CustomerId,
                            Balance = accountVM.Balance,
                            Doc = accountVM.DOC,
                            Tin = accountVM.Tin
                        });
                        if (id.ToLower().Contains("co-"))
                        {
                            TempData["SuccessMessage"] = "Account with " + id + " Created Successfully";
                            return RedirectToAction("SuccessAdd", "Home");
                        }
                        ModelState.AddModelError("", id);
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Invalid Date!");
                }
                ModelState.AddModelError("", "Account is not Created!");
            }
            return View();
        }
        [HttpGet]
        public IActionResult DeleteAccount()
        {
            if (HttpContext.Session.GetSession<ManagerLogin>("manager") is null)
            {
                return RedirectToAction("MangerLogin", "Home");
            }
            ViewBag.accounts = bankingManger.GetAccounts();
            var customers = this.bankingManger.GetCustomer();
            ViewBag.customers = customers;
            return View();
        }
        [HttpPost]
        public IActionResult DeleteAccount(DeleteAccount deleteAccount)
        {
            if (HttpContext.Session.GetSession<ManagerLogin>("manager") is null)
            {
                return RedirectToAction("MangerLogin", "Home");
            }
            ViewBag.accounts = bankingManger.GetAccounts();
            if (ModelState.IsValid)
            {
                var customers = this.bankingManger.GetCustomer();
                ViewBag.customers = customers;
                string delId = bankingManger.DeleteAccount(deleteAccount.AccountId);
                if (delId != null)
                {
                    TempData["SuccessMessage"] = "Account with " + delId + " Deleted Successfully";
                    return RedirectToAction("SuccessAdd", "Home");
                }
                ModelState.AddModelError("", "Account is not Deleted.Try Again!");
            }
            return View();
        }
        [HttpGet]
        public IActionResult UpdateAccount()
        {
            ViewBag.accounts = bankingManger.GetAccounts();
            if (HttpContext.Session.GetSession<ManagerLogin>("manager") is null)
            {
                return RedirectToAction("MangerLogin", "Home");
            }
            ViewBag.accounts = bankingManger.GetAccounts();
            return View();
        }
        [HttpPost]
        public IActionResult UpdateAccount(UpdateAccount account)
        {
            if (HttpContext.Session.GetSession<ManagerLogin>("manager") is null)
            {
                return RedirectToAction("MangerLogin", "Home");
            }
            ViewBag.accounts = bankingManger.GetAccounts();
            if (ModelState.IsValid)
            {
                var id = bankingManger.UpdateAccount(new AccountCopy()
                {
                    AccountNumber = account.AccountNumber,
                    AccountType = account.AccountType,
                    Balance = account.Balance
                });
                if (id.ToLower().Contains("sa-") || id.ToLower().Contains("co-"))
                {
                    TempData["SuccessMessage"] = "Account with " + id + " Updated Successfully";
                    return RedirectToAction("SuccessAdd", "Home");
                }
                else
                {
                    ModelState.AddModelError("", id);
                }
                ModelState.AddModelError("", "Upadtion Failed");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Withdraw()
        {
            if (HttpContext.Session.GetSession<ManagerLogin>("manager") is null)
            {
                return RedirectToAction("MangerLogin", "Home");
            }
            ViewBag.accounts = bankingManger.GetAccounts();
            return View();
        }
        [HttpPost]
        public IActionResult Withdraw(WithDrawVM account)
        {
            if (HttpContext.Session.GetSession<ManagerLogin>("manager") is null)
            {
                return RedirectToAction("MangerLogin", "Home");
            }
            ViewBag.accounts = bankingManger.GetAccounts();
            if (ModelState.IsValid)
            {
                if(account.Amount > 0)
                {
                    var id = bankingManger.Withdraw(new AccountCopy()
                    {
                        AccountNumber = account.AccountNumber,
                        Amount = account.Amount,
                        description = account.Descrption
                    });
                    if (id.ToLower().Contains("sa-") || id.ToLower().Contains("co-")|| id.ToLower().Contains("ca-"))
                    {
                        TempData["SuccessMessage"] = "Amount : " + account.Amount + "/- withdrawn Successfully " + " from account " + id;
                        return RedirectToAction("SuccessAdd", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("", id);
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Amount Sholud be Greater than 0.");
                }
               // ModelState.AddModelError("", "Transaction Failed!");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Deposit()
        {
            if (HttpContext.Session.GetSession<ManagerLogin>("manager") is null)
            {
                return RedirectToAction("MangerLogin", "Home");
            }
            ViewBag.accounts = bankingManger.GetAccounts();
            return View();
        }
        [HttpPost]
        public IActionResult Deposit(WithDrawVM account)
        {
            if (HttpContext.Session.GetSession<ManagerLogin>("manager") is null)
            {
                return RedirectToAction("MangerLogin", "Home");
            }
            ViewBag.accounts = bankingManger.GetAccounts();
            if (ModelState.IsValid)
            {
                if(account.Amount > 0)
                {
                    var id = bankingManger.Deposit(new AccountCopy()
                    {
                        AccountNumber = account.AccountNumber,
                        Amount = account.Amount,
                        description = account.Descrption
                    });
                    if (id.ToLower().Contains("sa-") || id.ToLower().Contains("co-") || id.ToLower().Contains("ca-"))
                    {
                        TempData["SuccessMessage"] = "Amount : " + account.Amount + "/-  Deposited Successfully " + " to account " + id;
                        return RedirectToAction("SuccessAdd", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("", id);
                    }
                    
                }
                else
                {
                    ModelState.AddModelError("", "Invalid Amount!");
                }
                
            }
            return View("Withdraw");
        }
        [HttpGet]
        public IActionResult Ministatement()
        {
            if (HttpContext.Session.GetSession<ManagerLogin>("manager") is null)
            {
                return RedirectToAction("MangerLogin", "Home");
            }
           /* dynamic mymodel = new ExpandoObject();
            mymodel.accounts = bankingManger.GetAccounts();
            mymodel.customers = bankingManger.GetCustomer();*/
            ViewBag.accounts = bankingManger.GetAccounts();
            return View();
        }
        [HttpPost]
        public IActionResult Ministatement(DeleteAccount account)
        {
            if (HttpContext.Session.GetSession<ManagerLogin>("manager") is null)
            {
                return RedirectToAction("MangerLogin", "Home");
            }
            ViewBag.accounts = bankingManger.GetAccounts();
            if (ModelState.IsValid)
            {
                TempData["account"] = account.AccountId;
                return RedirectToAction("Transaction");
            }
            return View();
        }
        public IActionResult Transaction()
        {
            if (HttpContext.Session.GetSession<ManagerLogin>("manager") is null)
            {
                return RedirectToAction("MangerLogin", "Home");
            }
            var result = bankingManger.Ministatement(TempData["account"].ToString());
            if(result is not null)
            {
                ViewBag.transaction = Enumerable.Reverse(result).Take(5).ToList();
            }
            else
            {
                TempData["SuccessMessage"] = "No Transaction Found!";
                return RedirectToAction("SuccessAdd", "Home");
            }
            return View();
        }
        [HttpGet]
        public IActionResult FundTransfer()
        {
            ViewBag.accounts = bankingManger.GetAccounts();
            if (HttpContext.Session.GetSession<ManagerLogin>("manager") is null)
            {
                return RedirectToAction("MangerLogin", "Home");
            }
            return View();
        }

        [HttpPost]
        public IActionResult FundTransfer(FundTransfer fundTransfer)
        {
            if (HttpContext.Session.GetSession<ManagerLogin>("manager") is null)
            {
                return RedirectToAction("MangerLogin", "Home");
            }
            ViewBag.accounts = bankingManger.GetAccounts();
            if (ModelState.IsValid)
            {
                if(fundTransfer.Amount > 0)
                {
                    if (fundTransfer.PayeesAccountNo != fundTransfer.PayersAccountNo)
                    {
                        var result = bankingManger.FundTransfer(new AccountCopy()
                        {
                            SourceAccount = fundTransfer.PayersAccountNo,
                            DestinationAccount = fundTransfer.PayeesAccountNo,
                            Amount = fundTransfer.Amount
                        });
                        if (result.ToLower().Contains("sa-") || result.ToLower().Contains("co-") || result.ToLower().Contains("ca-"))
                        {
                            TempData["SuccessMessage"] = "Amount " + fundTransfer.Amount + " is transfered from source account : " + fundTransfer.PayersAccountNo + " to " + fundTransfer.PayeesAccountNo + " Successfully";
                            return RedirectToAction("SuccessAdd", "Home");
                        }
                        else
                        {
                            ModelState.AddModelError("", result);
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "Source And destination accounts should not be the same!");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Invaild Amount!");
                }
            }
            return View();
        }
        [HttpGet]
        public IActionResult BalanceEnquiry()
        {
            if (HttpContext.Session.GetSession<ManagerLogin>("manager") is null)
            {
                return RedirectToAction("MangerLogin", "Home");
            }
            ViewBag.accounts = bankingManger.GetAccounts();
            return View();
        }

        [HttpPost]
        public IActionResult BalanceEnquiry(DeleteAccount balanceEnquiry)
        {
            if (HttpContext.Session.GetSession<ManagerLogin>("manager") is null)
            {
                return RedirectToAction("MangerLogin", "Home");
            }
            ViewBag.accounts = bankingManger.GetAccounts();
            if (ModelState.IsValid)
            {
                double balance = this.bankingManger.BalanceEnquiry(balanceEnquiry.AccountId);
                if (balance >=0 )
                {
                    TempData["SuccessMessage"] = $"Balance is {balance}";
                    return RedirectToAction("SuccessAdd", "Home");
                }
                ModelState.AddModelError("", "TryAgain!");
            }
            return View();
        }
        [HttpGet]
        public IActionResult CustomizedStatement()
        {
            if (HttpContext.Session.GetSession<ManagerLogin>("manager") is null)
            {
                return RedirectToAction("MangerLogin", "Home");
            }
            ViewBag.accounts = bankingManger.GetAccounts();
            return View();
        }
        
        [HttpPost]
        public IActionResult CustomizedStatement(CustomizedStatementVM customizedStatement)
        {
            if (HttpContext.Session.GetSession<ManagerLogin>("manager") is null)
            {
                return RedirectToAction("MangerLogin", "Home");
            }
            ViewBag.accounts = bankingManger.GetAccounts();
            if (ModelState.IsValid)
            {   if (customizedStatement.LowerLimit > 0)
                {
                    if (customizedStatement.FromDate <= DateTime.UtcNow && customizedStatement.ToDate <= DateTime.UtcNow && customizedStatement.FromDate <= customizedStatement.ToDate)
                    {
                        TempData["customAccountNo"] = customizedStatement.AccountNumber;
                        TempData["Customized"] = JsonConvert.SerializeObject(customizedStatement);
                        return RedirectToAction("CustomizedStatements");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Invalid Date!");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Below 0/- no transactions will perform");
                }
            }
            return View();
        }

        public IActionResult CustomizedStatements()
        {
            if (HttpContext.Session.GetSession<ManagerLogin>("manager") is null)
            {
                return RedirectToAction("MangerLogin", "Home");
            }
            ViewBag.accounts = bankingManger.GetAccounts();
            ViewBag.Customized = JsonConvert.DeserializeObject(TempData["Customized"].ToString());
            var result = this.bankingManger.CustomizedStatement(new AccountCopy()
            {
                AccountNumber = ViewBag.Customized.AccountNumber,
                FromDate = ViewBag.Customized.FromDate,
                ToDate = ViewBag.Customized.ToDate,
                LowerLimit = ViewBag.Customized.LowerLimit,
                NoOfTransactions = ViewBag.Customized.NoOfTransactions == null ? -1 : ViewBag.Customized.NoOfTransactions
            });
            if (result == null || result.Count() == 0 )
            {
                TempData["SuccessMessage"] = $"No Transaction Found";
                return RedirectToAction("SuccessAdd", "Home");
            }
            if (result is not null)
            {
                ViewBag.allCustomStatements = result.ToList();
                return View();
            }
            return View();
        }

    }
}

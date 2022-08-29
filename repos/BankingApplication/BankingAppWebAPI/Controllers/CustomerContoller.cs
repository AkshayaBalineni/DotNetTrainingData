using BankingBussinessLayer.cs.Contracts;
using BankingCommonLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankingAppWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerContoller : ControllerBase
    {
        private readonly ICustomerAsyncManager customerAsyncManager;

        public CustomerContoller(ICustomerAsyncManager customerAsyncManager)
        {
            this.customerAsyncManager = customerAsyncManager;
        }
        //GET: /api/controller/{custumerId}/{accountNumber}
        /// <summary>
        /// Returns balance
        /// </summary>
        /// <returns>Balance Enquiry </returns>
        /// <remarks>
        ///  Sample Request :
        /// 
        ///     GET: /api/controller/{custumerId}/{accountNumber}
        /// </remarks>
        [HttpGet("{custumerId}/{accountNumber}")]
        public async Task<ActionResult> BalanceEnquiry(string custumerId, string accountNumber)
        {
            try
            {
                var balance = await this.customerAsyncManager.BalanceEnqiry(custumerId, accountNumber);
                if(balance >= 0)
                {
                    return Ok(balance);
                }
                return NotFound($"Invalid CustomerId or AccountNumber");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error Occured while Retriving balance!");
            }
        }
        //GET: /api/customer/ministatement/{custumerId}/{accountNumber}
        /// <summary>
        /// Returns ministatement
        /// </summary>
        /// <returns>Minisatement</returns>
        /// <remarks>
        /// Sample Request :
        /// 
        ///      GET: /api/customer/ministatement/{custumerId}/{accountNumber}
        /// </remarks>
        [HttpGet("/ministatement/{custumerId}/{accountNumber}")]
        public async Task<ActionResult> Ministatement(string custumerId, string accountNumber)
        {
            try
            {
                var transactions =await this.customerAsyncManager.Ministatement(custumerId, accountNumber);
                if(transactions is null)
                {
                    return NotFound($"Invalid CustomerId or AccountNumber");
                }
                if (transactions.Count() == 0)
                {
                    return NotFound($"No transactions as for now!");
                }
                if (transactions != null)
                {
                    return Ok(transactions);
                }
                
                return BadRequest();
            }
            catch(Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error Occured while Retriving Ministatement!");
            }
        }
        //GET: /api/customer/{AccountNumber}/{fromDate}/{toDate}
        /// <summary>
        /// Returns Customized satement
        /// </summary>
        /// <returns>Customized satement</returns>
        /// <remarks>
        ///     Sample Request :
        /// 
        ///  GET: /api/customer/{AccountNumber}/{fromDate}/{toDate}
        /// </remarks>
        [HttpGet("{AccountNumber}/{fromDate}/{toDate}")]
        public async Task<ActionResult> CustomisedStatement(string AccountNumber,DateTime fromDate,DateTime toDate)
        {
            try
            {
                var transactions = await this.customerAsyncManager.CustomisedStatement(AccountNumber,fromDate,toDate);
                if (transactions.Count() == 0)
                {
                    return NotFound($"No transactions as for now!");
                }
                if(transactions != null)
                {
                    return Ok(transactions);
                }
                return NotFound($"Invalid data entry");
            }
            catch(Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error Occured while Retriving CustomisedStatement!");
            }
        }
        //GET: /api/customer/fundTransfer/{source}/{destination}/{amount}
        /// <summary>
        /// Returns transaction
        /// </summary>
        /// <returns>Fund Transfer</returns>
        /// <remarks>
        /// Sample Request : 
        /// 
        ///     GET: /api/customer/fundTransfer/{source}/{destination}/{amount}
        /// </remarks>
        [HttpGet("fundTransfer/{source}/{destination}/{amount}")]
        public async Task<ActionResult> FundTransfer(string source,string destination,double amount)
        {
            try
            {
                bool value = await this.customerAsyncManager.FundTranser(source, destination, amount);
                if(value)
                {
                    return Ok($"Transaction Successfully completed");
                }
                else
                {
                    return NotFound($"Transaction failed");
                }
            }
            catch(Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error Occured while Retriving Ministatement!");
            }
        }

    }
}

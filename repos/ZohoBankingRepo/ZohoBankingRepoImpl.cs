using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZohoBankingCommonLayer;

namespace ZohoBankingRepo
{
    public class ZohoBankingRepoImpl
    {
        List<Customer> customers = new List<Customer>(); 
        public string AddCustomer(Customer customer)
        {
            if(customer.Password.Equals(customer.RetypePassword))
            {
                //char[] passwordHash = new Char[customer.Password.Length];
                for(int i=0;i<customer.Password.Length;i++)
                {
                    customer.encryptedPassword = customer.encryptedPassword+Convert.ToChar(customer.Password[i]+1);
                }
                customers.Add(customer);
            }
            else
            {
                return "Password and confirm password should be Same!";
            }
            return $"Customer Added With CustomerId = " + customer.CustomerId+" Intial Balance ="+customer.IntialAmount;
        }
        public IEnumerable<Customer> DisplayCustomer()
        {
            return customers;
        }
        public string Authentication(int customerId,string password)
        {
            Customer customer = customers.FirstOrDefault(x => x.CustomerId == customerId);
            if(customer is not null && customer.Password.Equals(password))
            {
                customer.isAuthenticated = true;
                return "Logged In Successfully";
            }
            return "Invalid customerId or Password";
        }
       
    }
}

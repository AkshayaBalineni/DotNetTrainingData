using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akshaya_Assessment2
{
    public class Company
    {
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }

        private List<Branch> branches = new List<Branch>();
        private List<Employee> employees = new List<Employee>();
        private List<Customer> customers = new List<Customer>();
        public void AddBranch(Branch branch)
        {
            this.branches.Add(branch);
        }

        public IEnumerable<Branch> GetBranches()
        {
            return this.branches;
        }
        public void AddEmployee(Employee employee)
        {
            this.employees.Add(employee);
        }
        public IEnumerable<Employee> GetEmployees()
        {
            return this.employees;
        }
        public void AddCustomer(Customer customer)
        {
            this.customers.Add(customer);
        }
        public IEnumerable<Customer> GetCustomers()
        {
            return this.customers;
        }
    }
}

using System;

namespace Akshaya_Assessment2
{
    class Program
    {
        static void Main()
        {
            Department department1= new Department() { DepartmentId = 501, DepartmentName = "dept1" };
            Department department2 = new Department() { DepartmentId = 502, DepartmentName = "dept2" };
            Department department3 = new Department() { DepartmentId = 503, DepartmentName = "dept3" };

            Employee manager1 = new Manager(20000) { EmployeeId = 101, Name = "manager1", Age = 25, BasicSalary = 30000 };
            Employee manager2 = new Manager(15000) { EmployeeId = 102, Name = "manager2", Age = 20, BasicSalary = 30000 };

            Employee employee3= new SalesPerson(200,2000) { EmployeeId = 103, Name = "sales1", Age = 25, BasicSalary = 30000 };
            Employee employee4 = new SalesPerson(350, 3500) { EmployeeId = 104, Name = "sales2", Age = 30, BasicSalary = 30000 };

            manager1.Department = department1;
            manager2.Department = department2;
            employee3.Department = department3;
            employee4.Department = department1;

            Customer customer1 = new Customer() { Name = "Cust1", CustomerId = 201, Age = 20, Date = DateTime.UtcNow };
            Customer customer2 = new Customer() { Name = "Cust2", CustomerId = 202, Age = 20, Date = DateTime.UtcNow };
            Customer customer3 = new RegisteredCustomer(2000,DateTime.UtcNow) { Name = "Cust3", CustomerId = 203, Age = 20, Date = DateTime.UtcNow };
            Customer customer4 = new RegisteredCustomer(2000, DateTime.UtcNow) { Name = "Cust4", CustomerId = 204, Age = 20, Date = DateTime.UtcNow };

            Address address1 = new Address() { AddressId = 701, State = "AndhraPradesh" };
            Address address2 = new Address() { AddressId = 702, State = "TamilNadu" };

            Branch branch1 = new Branch() { BranchId = 901, BranchName = "branch1" };
            Branch branch2 = new Branch() { BranchId = 902, BranchName = "branch2" };

            branch1.Manager = (Manager)manager1;
            branch2.Manager = (Manager)manager2;

            Company company = new Company() { CompanyId = 601, CompanyName = "Company1" };

            company.AddEmployee(manager1);
            company.AddEmployee(manager2);
            company.AddEmployee(employee3);
            company.AddEmployee(employee4);


        }
    }
}

using ShopOnCommonLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ShopOnConsoleApp
{
    public class CustomerOrder
    {
        public void Main()
        {
            //1. Create Products
            Product product1 = new Product() { PId = 101, ProductName = "iphone 13", ProductPrice = 97000 };
            Product product2 = new Product() { PId = 102, ProductName = "iphone 10", ProductPrice = 76000 };
            Product product3 = new Product() { PId = 103, ProductName = "iphone 10 pro", ProductPrice = 67000};
            Product product4 = new Product() { PId = 104, ProductName = "iphone 8s", ProductPrice = 74000 };
            Product product5 = new Product() { PId = 105, ProductName = "iphone 9s", ProductPrice = 58000 };
            Product product6 = new Product() { PId = 106, ProductName = "iphone 8s", ProductPrice = 62000 };
            Product product7 = new Product() { PId = 107, ProductName = "iphone 7s", ProductPrice = 60000 };
            Product product8 = new Product() { PId = 108, ProductName = "iphone 5s", ProductPrice = 59000 };
            Product product9 = new Product() { PId = 109, ProductName = "iphone 4s", ProductPrice = 58000 };
            Product product10 = new Product() { PId = 110, ProductName = "iphone Mini", ProductPrice = 45000 };
            //2. create Company
            Company company = new Company() { CompanyId = 9001, CompanyName = "ShopOn" };
            //3. Add products to company
            company.AddProduct(product1);
            company.AddProduct(product2);
            company.AddProduct(product3);
            company.AddProduct(product4);
            company.AddProduct(product5);
            company.AddProduct(product6);
            company.AddProduct(product7);
            company.AddProduct(product8);
            company.AddProduct(product9);
            company.AddProduct(product10);
            //4. create customer
            Customer customer1 = new Customer() { CustomerId = 301, CustomerName = "Akshaya", CustomerMobileNumber = "8976453429" };
            Customer customer2 = new Customer() { CustomerId = 302, CustomerName = "Maneesha", CustomerMobileNumber = "9976453429" };
            Customer customer3 = new Customer() { CustomerId = 303, CustomerName = "Kusuma", CustomerMobileNumber = "7865453429" };
            Customer customer4 = new Customer() { CustomerId = 304, CustomerName = "Priya", CustomerMobileNumber = "9455453429" };
            Customer customer5 = new RegisteredCustomer(10) { CustomerId = 305, CustomerName = "Kavya", CustomerMobileNumber = "7776458929" };
            //5. Add customers to the company
            company.AddCustomer(customer1);
            company.AddCustomer(customer2);
            company.AddCustomer(customer3);
            company.AddCustomer(customer4);
            company.AddCustomer(customer5);
            //6. Add company to the customer
            customer1.Company = company;
            customer2.Company = company;
            customer3.Company = company;
            customer4.Company = company;
            customer5.Company = company;
            //7. Create orders
            Order order1 = new Order() { OrderId = 801, OrderDate = new System.DateTime(2015, 3, 07, 2, 15, 10) };
            Order order2 = new Order() { OrderId = 802, OrderDate = new System.DateTime(2022, 2, 05, 3, 12, 10) };
            Order order3 = new Order() { OrderId = 803, OrderDate = new System.DateTime(2021, 1, 09, 4, 14, 10) };
            Order order4 = new Order() { OrderId = 804, OrderDate = new System.DateTime(2019, 4, 01, 6, 09, 10) };
            Order order5 = new Order() { OrderId = 805, OrderDate = new System.DateTime(2008, 5, 12, 7, 45, 10) };
            //8. Add customer to the orders
            order1.Customer = customer1;
            order1.Customer = customer3;
            order2.Customer = customer2;
            order2.Customer = customer1;
            order3.Customer = customer3;
            order3.Customer = customer2;
            order4.Customer = customer4;
            order5.Customer = customer4;
            order5.Customer = customer5;
            //9. Add orders to the customer
            customer1.AddOrders(order1);
            customer2.AddOrders(order2);
            customer3.AddOrders(order3);
            customer4.AddOrders(order4);
            customer5.AddOrders(order5);
            customer1.AddOrders(order2);
            customer2.AddOrders(order3);
            customer4.AddOrders(order5);
            customer3.AddOrders(order1);
            /*//10. Add Products to the order
            order1.Addproduct(product1);
            order1.Addproduct(product2);
            order1.Addproduct(product3);
            order4.Addproduct(product4);
            order2.Addproduct(product2);
            order2.Addproduct(product3);
            order3.Addproduct(product5);
            order4.Addproduct(product6);
            order5.Addproduct(product7);
            order5.Addproduct(product8);*/
            //10. create oderItems
            OrderItem orderItem1 = new OrderItem() { ProductQty = 1 };
            OrderItem orderItem2 = new OrderItem() { ProductQty = 2 };
            OrderItem orderItem3 = new OrderItem() { ProductQty = 3 };
            OrderItem orderItem4 = new OrderItem() { ProductQty = 2 };
            OrderItem orderItem5 = new OrderItem() { ProductQty = 1 };
            OrderItem orderItem6 = new OrderItem() { ProductQty = 3 };
            OrderItem orderItem7 = new OrderItem() { ProductQty = 2 };
            OrderItem orderItem8 = new OrderItem() { ProductQty = 2 };
            //11.Add product to the orderItem
            orderItem1.Product = product1;
            orderItem2.Product = product2;
            orderItem3.Product = product3;
            orderItem4.Product = product4;
            orderItem5.Product = product5;
            orderItem6.Product = product6;
            orderItem7.Product = product7;
            orderItem8.Product = product8;
            //.Add orderItem to the orders
            order1.AddOrderItem(orderItem1);
            order2.AddOrderItem(orderItem2);
            order3.AddOrderItem(orderItem3);
            order4.AddOrderItem(orderItem4);
            order5.AddOrderItem(orderItem5);
            order1.AddOrderItem(orderItem6);
            order2.AddOrderItem(orderItem7);
            order3.AddOrderItem(orderItem2);
            order4.AddOrderItem(orderItem1);
            order5.AddOrderItem(orderItem3);


            DisplayCustomerOrderDetails(company);
        }

        private void DisplayCustomerOrderDetails(Company company)
        {
            Console.WriteLine("company Data");
            DrawLine(20, "-");
            Console.WriteLine($"company ID : {company.CompanyId}\t\t company Name : {company.CompanyName}");

            DrawLine(30, "-");
            foreach (var customer in company.GetCustomers())
            {
                Console.WriteLine($"Customer ID : {customer.CustomerId}\t\t Customer Name : {customer.CustomerName}");
                Console.WriteLine($"Total Customer Value: \t\t{customer.GetCustomerTotal()}");
                /*if(customer is RegisteredCustomer)
                {
                    var regCustomer = (RegisteredCustomer)customer;
                    var discount = regCustomer.Discount;
                    var discountAmount = customer.GetCustomerTotal()*discount/100;
                    var afterDiscount = customer.GetCustomerTotal() - discountAmount;
                    Console.WriteLine($"After discount = {afterDiscount}");
                }*/
                Console.WriteLine("**************************************************************");
                foreach (var order in customer.GetOrders())
                {
                    Console.WriteLine($"OrderId :{order.OrderId} \t OrderDate : {order.OrderDate}");
                    DrawLine(100, "-");
                    Console.WriteLine("PId\t\tProductName\t\tPrice\t\tQty\t\tAmount");
                    foreach (var orderItem in order.GetOrderItems())
                    {               
                        Console.WriteLine($"{orderItem.Product.PId}\t\t{orderItem.Product.ProductName}\t\t{orderItem.Product.ProductPrice}\t\t{orderItem.ProductQty}\t\t{orderItem.GetOrderItemTotal()}");
                    }
                    DrawLine(100, "-");
                    Console.WriteLine($"Order Total :\t\t\t{order.GetOrderTotal()}");
                    DrawLine(100, "-");
                }
            }


        }

        private void DrawLine(int v1, string v2)
        {
            for (int i = 0; i < v1; i++)
            {
                Console.Write(v2);
            }
            Console.WriteLine();
        }
    }
}
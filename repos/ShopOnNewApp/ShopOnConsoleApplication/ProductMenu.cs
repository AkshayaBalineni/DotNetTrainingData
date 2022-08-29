using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopOnBussinessLayer.Contracts;
using ShopOnBussinessLayer.Implementation;
using ShopOnCommonLayer.CustomExceptions;
using ShopOnCommonLayer.Logger;
using ShopOnCommonLayer.Models;
using ShopOnDataLayer;
using ShopOnDataLayer.Contracts;
using ShopOnDataLayer.Implementation;
using ShopOnDataLayerx;
using ShopOnEFLayer.Impl;

namespace ShopOnConsoleApp
{
    public class ProductMenu
    {
        public void Main()
        {
            // InterfaceProductRepository productRepository = new ProductRepoInMemoryDictionary();
            /*string folderPath = @"D:\filrStreamOperations\logs\";
            ILogger logger = new LoggerImplementation(folderPath);
            InterfaceProductRepository productRepository = new ProductRepoInMemoryArray(logger);*/
            ICompanyRepo companyRepo = new CompanyRepoDBImpl();
            InterfaceProductRepository productRepository = new ProductRepoDB(companyRepo);
           // InterfaceProductRepository productRepository = new ProductRepoEFImpl();
            InterfaceProductManager productManager = new ProductManager(productRepository)
            ;
            int ch ;
            bool looping = true;
            while (looping)
            {
                Console.WriteLine("PRODUCT MENU");
                Console.WriteLine("****************************");
                Console.WriteLine("1.Add Product");
                Console.WriteLine("2.Display Product");
                Console.WriteLine("3.Get ProductById");
                Console.WriteLine("4.Update Product");
                Console.WriteLine("5.Delete Product");
                Console.WriteLine("6.Sort By Id");
                Console.WriteLine("7.Search By Key");
                Console.WriteLine("8.Discount By Key");
                Console.WriteLine("9.Pagination");
                //Console.WriteLine("9.Get Dicounted products by key(delegates): ");
                Console.WriteLine("Enter your choice");
                Console.WriteLine("****************************");
                ch = Convert.ToInt32(Console.ReadLine());
                switch (ch)
                {
                    case 1: Console.WriteLine("add products");
                        AddProduct(productManager);
                        break;
                    case 2:
                        DisplayProduct(productManager);
                        break;
                    case 3:
                        GetProductById(productManager);
                        break;
                    case 4:
                        UpdateProduct(productManager);
                        break;
                    case 5:
                        DeleteProduct(productManager);
                        break;
                    case 6: SortById(productManager);
                        break;
                    case 7: SearchBykey(productManager);
                        break;
                    case 8: GetDiscountedProductByKey(productManager);
                        break;
                    case 9:
                        Pagination(productManager);
                        break;
                    default: looping = false; break;
                }
                Console.WriteLine("Do you want to continue in product menu? y/n");
                String s = Console.ReadLine();
                if (String.Equals(s, "N", StringComparison.OrdinalIgnoreCase))
                    looping = false;
            }
        }

        private void Pagination(InterfaceProductManager productManager)
        {
            Console.WriteLine("Enter the pageNumber 1 to 5:");
            int pageNumber = Convert.ToInt32(Console.ReadLine());
            var products = productManager.Pagination(pageNumber).ToList();
            Console.WriteLine("ProductId\t\tProductName\t\tProductPrice\tStatus\t\tImageURL");
            Console.WriteLine("*******************************************************************************");
            foreach (var product in products)
            {
                Console.WriteLine($"{product.PId}\t\t{product.ProductName}\t\t{product.ProductPrice}\t\t" +
                    $"{product.AvailableStatus}\t\t{product.ImageUrl}");
            }
        }

        /*private void GetDiscountedProductByKeyV1(InterfaceProductManager productManager)
{
   Console.WriteLine("Enter the key to get discounted products:");
   string key = Console.ReadLine();
   try
   {
       var products = productManager.GetDiscountedProductByKeyV1(key).ToList();
       DisplayProductInfo(products);
   }
   catch (InvalidProductException excep)
   {
       Console.WriteLine(excep.Message);
       if (excep.InnerException != null)
           Console.WriteLine($"Actual msg :{excep.InnerException.Message}");
       //store it in db/file but should not display 
       // Console.WriteLine(excep.StackTrace);
       WriteLogs(excep);
   }
}*/
        private void GetDiscountedProductByKey(InterfaceProductManager productManager)
        {
            Console.WriteLine("Enter the key to get discounted products:");
            string key = Console.ReadLine();
            try
            {
                var products = productManager.GetDiscountedProductByKey(key).ToList();
                DisplayProductInfo(products);
            }
            catch (InvalidProductException excep)
            {
                Console.WriteLine(excep.Message);
                if (excep.InnerException != null)
                    Console.WriteLine($"Actual msg :{excep.InnerException.Message}");
                //store it in db/file but should not display 
                // Console.WriteLine(excep.StackTrace);
                WriteLogs(excep);
            }
        }
        private void SearchBykey(InterfaceProductManager productManager)
        {
            Console.WriteLine("Enter the Key :");
            string key = Console.ReadLine();
            try
            {
                var products = productManager.SearchBykey(key).ToList();
                DisplayProductInfo(products);
            }
            catch (InvalidProductException excep)
            {
                Console.WriteLine(excep.Message);
                if (excep.InnerException != null)
                    Console.WriteLine($"Actual msg :{excep.InnerException.Message}");
                //store it in db/file but should not display 
                // Console.WriteLine(excep.StackTrace);
                WriteLogs(excep);
            }
        }
        private void SortById(InterfaceProductManager productManager)
        {
            var products = productManager.SortById();
            DisplayProductInfo(products);
        }
        private void AddProduct(InterfaceProductManager productManager)
        {
            string errorMsg = string.Empty;
            Product prod = new Product();
            Console.WriteLine("Enter the ProductId:");
            prod.PId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the ProductName:");
            prod.ProductName = Console.ReadLine();
            Console.WriteLine("Enter the ProductPrice:");
            prod.ProductPrice = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter ImageURL");
            prod.ImageUrl = Console.ReadLine();
            Console.WriteLine("Enter Avaliable Status");
            prod.AvailableStatus = Convert.ToChar(Console.ReadLine());
            Console.WriteLine("Enter companyId : ");
            prod.CompanyId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter categoryId :");
            prod.CategoryId = Convert.ToInt32(Console.ReadLine());

            try
            {
                if (productManager.AddProduct(prod, out errorMsg) && string.IsNullOrEmpty(errorMsg))
                    Console.WriteLine("Product Saved");
                else
                    Console.WriteLine("Product Not saved");
            }
            catch (DuplicateProductException excep)
            {
                Console.WriteLine(excep.Message);
                if (excep.InnerException != null)
                    Console.WriteLine($"Actual msg :{excep.InnerException.Message}");
                //store it in db/file but should not display 
                // Console.WriteLine(excep.StackTrace);
                WriteLogs(excep);

            }
            /*string errorMsg = string.Empty;
            Product product1 = new Product() { PId = 101, ProductName = "Apple 5s", ProductPrice = 50000 };
            Product product2 = new Product() { PId = 102, ProductName = "samsung mini ", ProductPrice = 20000 };
            Product product3 = new Product() { PId = 103, ProductName = "Apple ipad mini",ProductPrice = 29000 };
            Product product4 = new Product() { PId = 104, ProductName = "Apple 6s plus", ProductPrice = 59000 };
            Product product5 = new Product() { PId = 105, ProductName = "oneplus 7s", ProductPrice = 64000 };
            Product product6 = new Product() { PId = 106, ProductName = "oppo 8s", ProductPrice = 72000 };
            Product product7 = new Product() { PId = 107, ProductName = "oppo 10s", ProductPrice = 112900};
            Product product8 = new Product() { PId = 108, ProductName = "Apple 10s max", ProductPrice = 129600};
            Product product9 = new Product() { PId = 109, ProductName = "Apple 10s pro", ProductPrice = 132000 };
            Product product10 = new Product() { PId = 110, ProductName = "samsung 4s", ProductPrice = 48000 };

            productManager.AddProduct(product1, out errorMsg);
            productManager.AddProduct(product2, out errorMsg);
            productManager.AddProduct(product3, out errorMsg);
            productManager.AddProduct(product4, out errorMsg);
            productManager.AddProduct(product5, out errorMsg);
            productManager.AddProduct(product6, out errorMsg);
            productManager.AddProduct(product7, out errorMsg);
            productManager.AddProduct(product8, out errorMsg);
            productManager.AddProduct(product9, out errorMsg);
            productManager.AddProduct(product10, out errorMsg);*/
        }
        private void WriteLogs(Exception excep)
        {
            string date = DateTime.Now.ToString("yyyy-MM-dd");
            string today = @"D:\filrStreamOperations\logs\" + date + ".txt";
            using (StreamWriter sw = File.AppendText(today))
            {
                sw.WriteLine($"{DateTime.Now}");
                Console.WriteLine("**************************");
                sw.WriteLine(excep.StackTrace);
            }
            /*var yesterday = DateTime.Today.AddDays(-1).ToString("yyyy-MM-dd");
            string previous = @"D:\filrStreamOperations\logs\" + yesterday + ".txt";
            if (File.Exists(previous))
            {
                File.Delete(previous);
            }*/
        }
        private void DisplayProduct(InterfaceProductManager productManager)
        {
            bool isCompanyRequired = true;
            var products = productManager.GetProducts(isCompanyRequired).ToList();
            DisplayProductInfo(products);
            
        }
        private void DisplayProductInfo(List<Product> products)
        {
            Console.WriteLine("List of Products");
            Console.WriteLine("************************************************");
            Console.WriteLine("ProductId\t\tProductName\t\tProductPrice\tStatus\t\tImageURL\t\tCompanyName");
            Console.WriteLine("**********************************************************************************************************************");
            foreach (var product in products)
            {
                Console.WriteLine($"{product.PId}\t\t{product.ProductName}\t\t{product.ProductPrice}\t\t" +
                    $"{product.AvailableStatus}\t\t{product.ImageUrl}\t\t{product.Company.CompanyName}");
            }
        }
        private void GetProductById(InterfaceProductManager productManager)
        {
            Console.WriteLine("Enter the productId to be searched:");
            int prodId = Convert.ToInt32(Console.ReadLine());
            Product prod = productManager.GetProductById(prodId);
            if(prod != null) 
            {
                Console.WriteLine("************************************************");
                Console.WriteLine("ProductId\t\tProductName\t\tProductPrice\t\tAvaliableStatus\t\tImageURL");
                Console.WriteLine("************************************************");
                Console.WriteLine($"{prod.PId}\t\t{prod.ProductName}\t\t{prod.ProductPrice}\t\t" +
                    $"{prod.AvailableStatus}\t\t{prod.ImageUrl}");
            }
            else
            {
                Console.WriteLine($"No such element found with {prodId}");
            }   
        }
        private void UpdateProduct(InterfaceProductManager productManager)
        {
            Console.WriteLine("Enter the productId to be updated:");
            int prodId = Convert.ToInt32(Console.ReadLine());
            Product updatedproduct = productManager.GetProductById(prodId);
            Console.WriteLine("Enter the updated ProductName:");
            updatedproduct.ProductName = Console.ReadLine();
            Console.WriteLine("Enter the updated ProductPrice:");
            updatedproduct.ProductPrice = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter ImageURL");
            updatedproduct.ImageUrl = Console.ReadLine();
            Console.WriteLine("Enter Avaliable Status");
            updatedproduct.AvailableStatus = Convert.ToChar(Console.ReadLine());
            Console.WriteLine("Enter companyId : ");
            updatedproduct.CompanyId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter categoryId :");
            updatedproduct.CategoryId = Convert.ToInt32(Console.ReadLine());
            if (productManager.UpdateProduct(updatedproduct))
                Console.WriteLine("Product updated");
            else
                Console.WriteLine("Product Not updated");
        }
        private void DeleteProduct(InterfaceProductManager productManager)
        {
            Console.WriteLine("Enter the productId to be deleted:");
            int prodId = Convert.ToInt32(Console.ReadLine());
            Product deleteProduct = productManager.GetProductById(prodId);
            if (productManager.DeleteProduct(deleteProduct))
                Console.WriteLine("Product deleted");
            else
                Console.WriteLine("Product Not deleted");
        }
    }
}

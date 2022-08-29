using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ShopOnCommonLayer.CustomExceptions;
using ShopOnCommonLayer.Logger;
using ShopOnCommonLayer.Models;
using ShopOnDataLayer.Contracts;

namespace ShopOnDataLayer.Implementation
{
    public class ProductRepoInMemoryArray : InterfaceProductRepository
    {
       // private int count = -1;
        private List<Product> products = new List<Product>();
        private ILogger logger;
        public ProductRepoInMemoryArray(ILogger logger)
        {
            this.logger = logger;
        }
        public bool AddProduct(Product product , out String errorMsg)
        {
            bool isInserted = false;
            errorMsg = string.Empty;
            if (product.PId == 0 || product.ProductPrice == 0|| string.IsNullOrEmpty(product.ProductName))
            {
                errorMsg = "Pid or product name , price can't be null";
                return false;
            }
            var isDuplicate = this.GetProductById(product.PId);
            if(isDuplicate == null)
            {
                products.Add(product);
                isInserted = true;
            }
            else
            {
                throw new DuplicateProductException($"Duplicate with product id ={product.PId} exists");
            }
            return isInserted;
            /*if(count >= products.Length-1)
            {
                Product[] temp = new Product[products.Length];
                Array.Copy(products, temp, products.Length);
                products = new Product[products.Length * 2];
                Array.Copy(temp, products, temp.Length);
                temp = null;
            }
            products[++count] = product;*/

        }
        public IEnumerable<Product> GetProducts(bool isCompanyRequired = false)
        {/*
            Product[] temp = new Product[count + 1];
            Array.Copy(products, temp, count + 1);
            return temp;*/
             return products;
            /* List<Product> temp = new List<Product>();
             foreach(var product in products)
            {
                if (products.Count < count)
                    temp.Add(product);   
            }
            return temp;*/
        }
        [Obsolete("This Method is Obsolete.Use searchByKey(string key)",false)]
        public Product GetProductById(int prodId)
        {
            /* Product[] tempArr = new Product[count + 1];
             Array.Copy(products, tempArr, count + 1);*/
            return this.products.SingleOrDefault(product => product.PId == prodId);
            /*Product temp = null;
            foreach(var product in products)
            {
                if (prodId == product.PId)
                {
                    temp = product;
                    break;
                }
            }
            return temp;*/
        }
        public bool UpdateProduct(Product updatedproduct)
        { int index = 0;
            foreach (var product in products)
            { 
                if (updatedproduct.PId == product.PId)
                {
                    products[index] = updatedproduct;
                    break;
                }
                index++;
            }
            return true;
        }
        public bool DeleteProduct(Product deleteProduct)
        {/*
            for (int i = 0; i < count; i++)
            {
                if (products[i].PId == deleteProduct.PId)
                {
                    for (int j = i; j < count; j++)
                        products[j] = products[j + 1];
                }
            }*/
            products.Remove(deleteProduct);
            return true;
        }

        public IEnumerable<Product> SearchBykey(string key)
        {
            int n; 
            List<Product> products = new List<Product>();
            bool isNumeric = int.TryParse(key, out n);
            if(isNumeric)
            {
                products = this.products.FindAll(x => x.PId == n);
            }
            else
            {
                products = this.products.FindAll(x => x.ProductName.ToLower().Contains(key));
            }
            if (products.Count() > 0)
            return products;
           else 
            throw new InvalidProductException($"no products found with key = {key}");
        }

        public IEnumerable<Product> Pagination(int pageNumber)
        {
            throw new NotImplementedException();
        }
    }
}

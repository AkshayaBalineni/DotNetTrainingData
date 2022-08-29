using System;
using System.Collections.Generic;
using System.Text;
using ShopOnDataLayer.Implementation;
using ShopOnCommonLayer.Models;
using ShopOnDataLayer.Contracts;
using System.Linq;
using ShopOnCommonLayer.CustomExceptions;
using ShopOnBussinessLayer.Contracts;
using ShopOnBussinessLayer.Util;

namespace ShopOnBussinessLayer.Implementation
{
    public class ProductManager : InterfaceProductManager
    {
        private readonly InterfaceProductRepository productRepository;
        // ProductRepoInMemoryArray productRepo = new ProductRepoInMemoryArray();
        public ProductManager(InterfaceProductRepository productRepo)
        {
            this.productRepository = productRepo;
        }
        public bool AddProduct(Product product, out string errorMsg)
        {
            try
            {
                return productRepository.AddProduct(product, out errorMsg);
            }
            catch (DuplicateProductException de)
            {
                throw new DuplicateProductException("Duplicate Product Entry in other language", de);

            }
        }
        public IEnumerable<Product> GetProducts(bool isCompanyRequired)
        {
            return productRepository.GetProducts(isCompanyRequired);
        }
        public Product GetProductById(int prodId)
        {
            return productRepository.GetProductById(prodId);
        }
        public bool UpdateProduct(Product updatedproduct)
        {
            return productRepository.UpdateProduct(updatedproduct);
        }
        public bool DeleteProduct(Product deleteProduct)
        {
            return productRepository.DeleteProduct(deleteProduct);
        }
        public List<Product> SortById()
        {
            var result = this.productRepository.GetProducts();
            var sortData = result.ToList();
            sortData.Sort();
            return sortData;
        }
        public IEnumerable<Product> SearchBykey(string key)
        {
            try
            {
                return productRepository.SearchBykey(key);
            }
            catch(InvalidProductException ie)
            {
                throw new InvalidProductException("products not found",ie);
            }
            
        }
        public IEnumerable<Product> GetDiscountedProductByKey(string key)
        {
            try
            {
                var products = productRepository.SearchBykey(key);
                double discount = 10;
                foreach(var prod in products)
                {
                    prod.ProductPrice = prod.ProductPrice - (prod.ProductPrice * discount / 100);
                }
                return products;
            }
            catch (InvalidProductException ie)
            {
                throw new InvalidProductException("products not found", ie);
            }
        }

        public IEnumerable<Product> Pagination(int pageNumber)
        {
            return productRepository.Pagination(pageNumber);
        }
        /* public IEnumerable<Product> GetDiscountedProductByKeyV1(string key)
{
    // delegate bool isDiscounted(Product prod, string key);

    DiscountForProducts discountForProducts = new DiscountForProducts(key);
    var products = discountForProducts.DiscountImpl();
    return products;
}*/
    }
}


using ShopOnBussinessLayer.Contracts;
using ShopOnCommonLayer.Models;
using ShopOnDataLayer.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnBussinessLayer.Implementation
{
    public class ProductAsyncManager : IProductAsyncManager
    {
        private readonly IProductRepoAsync productRepoAsync;

        public ProductAsyncManager(IProductRepoAsync productRepoAsync)
        {
            this.productRepoAsync = productRepoAsync;
        }
        public Task<Product> AddProduct(Product product)
        {
            return productRepoAsync.AddProduct(product);
        }
        public Task DeleteProduct(int productId)
        {
            return productRepoAsync.DeleteProduct(productId);
        }
        public Task<Product> GetProductById(int productId)
        {
            return productRepoAsync.GetProductById(productId);
        }
        public Task<IEnumerable<Product>> GetProducts()
        {
            return productRepoAsync.GetProducts();
        }
        public Task<IEnumerable<Product>> Search(string key)
        {
            return productRepoAsync.Search(key);
        }
        public Task<Product> UpdateProduct(Product product)
        {
            return productRepoAsync.UpdateProduct(product);
        }
    }
}

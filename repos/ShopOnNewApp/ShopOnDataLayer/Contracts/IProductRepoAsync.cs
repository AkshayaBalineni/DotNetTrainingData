using ShopOnCommonLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnDataLayer.Contracts
{
   public interface IProductRepoAsync
    {
        /// <summary>
        /// Method to Add Product
        /// </summary>
        /// <param name="product"></param>
        /// <returns>Product</returns>
        Task<Product> AddProduct(Product product);
        Task<IEnumerable<Product>> GetProducts();
        Task<Product> GetProductById(int productId);
        Task<IEnumerable<Product>> Search(string key);
        Task<Product> UpdateProduct(Product product);
        Task DeleteProduct(int productId);
    }
}

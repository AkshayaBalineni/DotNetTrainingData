using ShopOnCommonLayer.CustomExceptions;
using ShopOnCommonLayer.Models;
using ShopOnDataLayer.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnDataLayerx
{
    public class ProductRepoInMemoryDictionary : InterfaceProductRepository
    {
        private Dictionary<int,Product> products = new Dictionary<int,Product>();
        public bool AddProduct(Product product , out string errorMsg)
        {
            bool isInsterted = false;
            errorMsg = string.Empty;
            if (product.PId == 0 || product.ProductPrice == 0 || string.IsNullOrEmpty(product.ProductName))
            {
                errorMsg = "Pid or product name , price can't be null";
                return false;
            }
            var isDuplicate = this.GetProductById(product.PId);
            if(isDuplicate == null)
            {
                products.Add(product.PId, product);
                isInsterted = true;
            }
            else
            {
                throw new DuplicateProductException($"Duplicate Product with product id = {product.PId}");
            }
           
            return isInsterted;
        }

        public bool DeleteProduct(Product deleteProduct)
        {
            bool isDeleted = false;
            products.Remove(deleteProduct.PId);
            isDeleted = true;
            return isDeleted;
        }

        public Product GetProductById(int prodId)
        {
           //return this.products.GetValueOrDefault(prodId);
            Product prod = null;
            foreach(var search in products)
            {
                if (search.Key == prodId)
                    prod = search.Value;
            }
            return prod;

        }

        public IEnumerable<Product> GetProducts(bool isCompanyRequired = false)
        {
             var result = this.products.Values;
            return result;

        }

        public IEnumerable<Product> Pagination(int pageNumber)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> SearchBykey(string key)
        {
            throw new NotImplementedException();
        }

        public bool UpdateProduct(Product updatedproduct)
        {
            throw new NotImplementedException();
        }
    }
}

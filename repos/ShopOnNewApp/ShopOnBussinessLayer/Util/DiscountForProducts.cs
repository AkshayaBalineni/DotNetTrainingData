/*using ShopOnBussinessLayer.Contracts;
using ShopOnBussinessLayer.Implementation;
using ShopOnCommonLayer.Models;
using ShopOnDataLayer.Contracts;
using ShopOnDataLayer.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnBussinessLayer.Util
{
    public class DiscountForProducts
    {
        public delegate bool isDiscounted(Product product, string key);
        string key;
        public DiscountForProducts(string key)
        {
            this.key = key;
        }
        public DiscountForProducts()
        {

        }
        public IEnumerable<Product> DiscountedProducts(List<Product> products, isDiscounted discounted)
        {
            List<Product> discountedProducts = new List<Product>();
            foreach (var prod in products)
            {
                if (discounted(prod, key))
                {
                    prod.ProductPrice = prod.ProductPrice - (prod.ProductPrice * 10 / 100);
                    discountedProducts.Add(prod);
                }
            }
            return discountedProducts;
        }
        public IEnumerable<Product> DiscountImpl()
        {

            InterfaceProductRepository productRepository = new ProductRepoInMemoryArray();
            InterfaceProductManager productManager = new ProductManager(productRepository);
            isDiscounted discounted = new isDiscounted(GetProductByProductName);
           // isDiscounted discounted = new isDiscounted(GetProductByCompanyName);
            var products = productManager.GetProducts().ToList();
            DiscountForProducts discountForProducts = new DiscountForProducts();
            return discountForProducts.DiscountedProducts(products, discounted);

        }
        private bool GetProductByProductName(Product product, string key)
        {
            bool approve = false;
            if (product.ProductName.ToLower().Contains(key))
                approve = true;
            return approve;
        }
    }
}
*/
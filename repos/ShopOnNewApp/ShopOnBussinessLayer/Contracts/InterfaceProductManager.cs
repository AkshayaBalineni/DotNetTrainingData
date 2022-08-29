using ShopOnCommonLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnBussinessLayer.Contracts
{
    public interface InterfaceProductManager
    {
        bool AddProduct(Product product, out string errorMsg);
        IEnumerable<Product> GetProducts(bool isCompanyRequired = false);
        Product GetProductById(int prodId);
        bool UpdateProduct(Product updatedproduct);
        bool DeleteProduct(Product deleteProduct);
        List<Product> SortById();
        IEnumerable<Product> SearchBykey(string key);
        IEnumerable<Product> GetDiscountedProductByKey(string key);
        IEnumerable<Product> Pagination(int pageNumber);
       // IEnumerable<Product> GetDiscountedProductByKeyV1(string key);
    }
}

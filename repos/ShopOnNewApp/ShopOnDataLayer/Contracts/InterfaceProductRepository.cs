using ShopOnCommonLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnDataLayer.Contracts
{ 
    public interface InterfaceProductRepository
    {
        bool AddProduct(Product product, out string errorMsg);       
        IEnumerable<Product> GetProducts(bool isCompanyRequired = false);
        Product GetProductById(int prodId);
        bool UpdateProduct(Product updatedproduct);
        bool DeleteProduct(Product deleteProduct);
        IEnumerable<Product> SearchBykey(string key);
        IEnumerable<Product> Pagination(int pageNumber);

    }
}

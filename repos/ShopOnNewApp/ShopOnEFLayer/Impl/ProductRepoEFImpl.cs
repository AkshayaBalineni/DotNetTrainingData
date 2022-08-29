using Microsoft.EntityFrameworkCore;
using ShopOnCommonLayer.Models;
using ShopOnDataLayer.Contracts;
using ShopOnEFLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Product = ShopOnCommonLayer.Models.Product;

namespace ShopOnEFLayer.Impl
{
    public class ProductRepoEFImpl : InterfaceProductRepository
    {
        private readonly db_shoponContext context;

        public ProductRepoEFImpl(db_shoponContext context)
        {
            this.context = context;
        }
        public bool AddProduct(Product product, out string errorMsg)
        {
            bool isInserted = false;
            errorMsg = string.Empty;
            try
            { 
                var isDuplicate = context.Products.ToList().FirstOrDefault(x => x.Pid == product.PId);
                if (isDuplicate == null)
                {
                    var dbProduct = new Models.Product()
                    {
                        Pid = product.PId,
                        Productname = product.ProductName,
                        Price = product.ProductPrice,
                        Availablestatus = product.AvailableStatus.ToString(),
                        ImageUrl = product.ImageUrl,
                        Companyid = product.CompanyId,
                        Categoryid = product.CategoryId,
                        IsDeleted = false
                    };
                    this.context.Products.Add(dbProduct);
                    context.SaveChanges();
                    isInserted = true;
                }
                else
                {
                    errorMsg = "Products already exits";
                }
                
            }
            catch (Exception)
            {

                throw;
            }
            return isInserted;
        }

        public bool DeleteProduct(Product deleteProduct)
        {
            bool isDeleted = false;
            var product = context.Products.ToList().FirstOrDefault(x => x.Pid == deleteProduct.PId);
            product.IsDeleted = true;
            this.context.SaveChanges();
            isDeleted = true;
            return isDeleted;
        }

        public Product GetProductById(int prodId)
        {
            var dbProduct = context.Products.FirstOrDefault(x => x.Pid == prodId);
            var product = new Product()
            {
                PId = dbProduct.Pid,
                ProductName = dbProduct.Productname,
                ProductPrice = dbProduct.Price??0,
                AvailableStatus = Convert.ToChar(dbProduct.Availablestatus),
                ImageUrl = dbProduct.ImageUrl,

            };
            return product;
        }
        public IEnumerable<Product> GetProducts(bool isCompanyRequired =false)
        {
            List<Product> products = new List<Product>(); ;
           var productsDb = context.Products.Include(x => x.Company);
           //  var productsDb = context.Products.ToList();
            foreach (var Dbproduct in productsDb)
            {
                if (Dbproduct.IsDeleted == false)
                {
                    Product product = new Product()
                    {
                        PId = Dbproduct.Pid,
                        AvailableStatus = Convert.ToChar(Dbproduct.Availablestatus),
                        CategoryId = Dbproduct.Categoryid.Value,
                        CompanyId = Dbproduct.Companyid.Value,
                        ProductPrice = Dbproduct.Price ?? 0,
                        ProductName = Dbproduct.Productname,
                        ImageUrl = Dbproduct.ImageUrl,
                        Company = new ShopOnCommonLayer.Models.Company()
                        {
                            CompanyId = Dbproduct.Company.Companyid,
                            CompanyName = Dbproduct.Company.Companyname
                        }

                    };
                    products.Add(product);
                }
            }
            return products;
        }
        public IEnumerable<Product> Pagination(int pageNumber)
        {
            //var dbProdducts = context.Products.ExecuteReader("sp_Pagination @pageNo", pageNumber);
            throw new NotImplementedException();
        }
        public IEnumerable<Product> SearchBykey(string key)
        {
            List<Product> products = new List<Product>();
            var productsDb = context.Products.Include(x => x.Company);
            //  var productsDb = context.Products.ToList();
            foreach (var Dbproduct in productsDb)
            {
                if (Dbproduct.IsDeleted == false && Dbproduct.Productname.ToLower().Contains(key.ToLower()))
                {
                        Product product = new Product()
                        {
                            PId = Dbproduct.Pid,
                            AvailableStatus = Convert.ToChar(Dbproduct.Availablestatus),
                            CategoryId = Dbproduct.Categoryid.Value,
                            CompanyId = Dbproduct.Companyid.Value,
                            ProductPrice = Dbproduct.Price ?? 0,
                            ProductName = Dbproduct.Productname,
                            ImageUrl = Dbproduct.ImageUrl,
                            Company = new ShopOnCommonLayer.Models.Company()
                            {
                                CompanyId = Dbproduct.Company.Companyid,
                                CompanyName = Dbproduct.Company.Companyname
                            }

                        };
                        products.Add(product);
                }
            }
            return products;
        }

        public bool UpdateProduct(Product updatedproduct)
        {
            bool isUpdated = false;
            var product = context.Products.ToList().FirstOrDefault(x => x.Pid == updatedproduct.PId);

            product.Pid = updatedproduct.PId;
            product.Productname = updatedproduct.ProductName;
            product.Price = updatedproduct.ProductPrice;
            product.Availablestatus = updatedproduct.AvailableStatus.ToString();
            product.ImageUrl = updatedproduct.ImageUrl;
            product.Companyid = updatedproduct.CompanyId;
            product.Categoryid = updatedproduct.CategoryId;

            this.context.SaveChanges();
            isUpdated = true;
            return isUpdated;
        }
    }
}
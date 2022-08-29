using Microsoft.EntityFrameworkCore;
using ShopOnDataLayer.Contracts;
using ShopOnEFLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnEFLayer.Impl
{
    public class ProductRepoAsyncImpl : IProductRepoAsync
    {
        private readonly db_shoponContext context;
        public ProductRepoAsyncImpl(db_shoponContext context)
        {
            this.context = context;
        }
        public async Task<ShopOnCommonLayer.Models.Product> AddProduct(ShopOnCommonLayer.Models.Product product)
        {
            try
            {
                var isDuplicate = await this.context.Products.FirstOrDefaultAsync(x => x.Pid == product.PId);
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
                    var result = await this.context.Products.AddAsync(dbProduct);
                    await context.SaveChangesAsync();
                    return new ShopOnCommonLayer.Models.Product()
                    {
                        PId = result.Entity.Pid,
                        AvailableStatus = Convert.ToChar(result.Entity.Availablestatus),
                        ProductName = result.Entity.Productname,
                        ImageUrl = result.Entity.ImageUrl,
                        CompanyId = result.Entity.Companyid.Value,
                        ProductPrice=result.Entity.Price.Value,
                        CategoryId = result.Entity.Categoryid.Value,
                        IsDeleted = Convert.ToInt32(result.Entity.IsDeleted)
                    };
                }
                return null;
            }
            catch (Exception e)
            {
                throw;
            }
        }
        public async Task<ShopOnCommonLayer.Models.Product> GetProductById(int productId)
        {
            var productDb = await this.context.Products
               .Include(x => x.Company)
               .FirstOrDefaultAsync(x => x.Pid == productId);
            if (productDb != null)
            {
                var company = new ShopOnCommonLayer.Models.Company()
                {
                    CompanyName = productDb.Company.Companyname,
                    CompanyId = productDb.Companyid.Value
                };
                return new ShopOnCommonLayer.Models.Product()
                {
                    PId = productDb.Pid,
                    AvailableStatus = Convert.ToChar(productDb.Availablestatus),
                    ImageUrl = productDb.ImageUrl,
                    ProductName = productDb.Productname,
                    ProductPrice = productDb.Price.Value,
                    CategoryId = productDb.Categoryid.Value,
                    CompanyId = productDb.Companyid.Value,
                    Company = company
                }; 
            }
            return null;
        }
        public async Task<IEnumerable<ShopOnCommonLayer.Models.Product>> GetProducts()
        {
            var productsDb = await this.context.Products.ToListAsync();
            var products = (from p in productsDb
                           where p.IsDeleted == false
                           select new ShopOnCommonLayer.Models.Product()
                           {
                               PId = p.Pid,
                               ImageUrl = p.ImageUrl,
                               ProductName = p.Productname,
                               ProductPrice = p.Price.Value,
                               AvailableStatus = Convert.ToChar(p.Availablestatus),
                               CompanyId = p.Companyid.Value,
                               CategoryId = p.Categoryid.Value
                           }).ToList();
             return products;
         }
           
        public async Task<IEnumerable<ShopOnCommonLayer.Models.Product>> Search(string key)
        {
            if(string.IsNullOrEmpty(key))
            {
                return null;
            }
            var dbProducts = await this.context.Products.Where(x => x.Productname.ToLower().Contains(key.ToLower())).ToListAsync();
            var products = from p in dbProducts
                           where p.IsDeleted == false
                           select new ShopOnCommonLayer.Models.Product()
                           {
                               PId = p.Pid,
                               ImageUrl = p.ImageUrl,
                               ProductName = p.Productname,
                               ProductPrice = p.Price.Value,
                               AvailableStatus = Convert.ToChar(p.Availablestatus),
                               CompanyId = p.Companyid.Value,
                               CategoryId = p.Categoryid.Value
                           };
            return products;

        }
        public async Task<ShopOnCommonLayer.Models.Product> UpdateProduct(ShopOnCommonLayer.Models.Product product)
        {
            var productDb = await this.context.Products.FirstOrDefaultAsync(x => x.Pid == product.PId);
            if(productDb != null)
            {
                productDb.Pid = product.PId;
                productDb.Availablestatus = product.AvailableStatus.ToString();
                productDb.Price = product.ProductPrice;
                productDb.Companyid = product.CompanyId;
                productDb.Categoryid = product.CategoryId;
                productDb.IsDeleted = false;

                await this.context.SaveChangesAsync();
                return product;
            }
            return null;
        }
        public async Task DeleteProduct(int productId)
        {
            var productsDB = await this.context.Products.FirstOrDefaultAsync(x => x.Pid == productId);
            if (productsDB != null)
            {
                productsDB.IsDeleted = true;
                await this.context.SaveChangesAsync();
            }
        }
    }
}

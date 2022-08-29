using ShopOnCommonLayer.Models;
using ShopOnDataLayer.Contracts;
using ShopOnDataLayer.Util;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnDataLayer.Implementation
{
    public class ProductRepoDB : InterfaceProductRepository
    {
        private readonly string connectionString = null;
        private readonly ICompanyRepo companyRepo;

        public ProductRepoDB(ICompanyRepo companyRepo)
        {
            this.companyRepo = companyRepo;
            ConnectionUtil connectionUtil = ConnectionUtil.GetInstance();
            connectionString = connectionUtil.GetConnectionString();
        }
        public bool AddProduct(Product product, out string errorMsg)
        {
            bool isInserted = false;
            errorMsg = string.Empty;
            //Product product = new Product();
            try
            {
                string sqlst = $"insert into dbo.product " +
                    $"(pid, " +
                    $"productname, " +
                    $"price, " +
                    $"availablestatus, " +
                    $"isDeleted, "+
                    $"imageUrl)  " +
                    $"values(" +
                    $"{product.PId}, " +
                    $"'{product.ProductName}', " +
                    $"{product.ProductPrice}, " +
                    $"'{product.AvailableStatus}', " +
                    $"{product.IsDeleted} ,"+
                    $"'{product.ImageUrl}');";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(sqlst, connection))
                    {
                        command.Connection.Open();
                        var prod = command.ExecuteNonQuery();
                        isInserted = true;
                    }
                }
            }
            catch (Exception)
            {

            }
            return isInserted;
        }
        public Product GetProductById(int prodId)
        {
            Product product = null;
            try
            {
                string sqlst = $"SELECT p.pid, " +
                        $"p.productname, " +
                        $"p.price, " +
                        $"p.availablestatus, " +
                        $"p.imageUrl  " +
                        $"FROM dbo.product AS p WITH(NOLOCK) " +
                        $"WHERE p.pid=" + prodId ;

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(sqlst, connection))
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            product = new Product() {
                                PId = Convert.ToInt32(reader["pid"]),
                                ProductName = reader["productname"].ToString(),
                                ProductPrice = Convert.ToDouble(reader["price"]),
                                AvailableStatus = Convert.ToChar(reader["availablestatus"]),
                                ImageUrl = reader["imageUrl"].ToString() 
                            };
                        }
                    }
                }
            }
            catch (Exception)
            {

            }
            return product;
        }

        public IEnumerable<Product> GetProducts(bool isCompanyRequired)
        {
            List<Product> products = new List<Product>();
            try
            {
                string sqlst = $"SELECT p.pid, " +
                        $"p.productname, " +
                        $"p.price, " +
                        $"p.availablestatus, " +
                        $"p.imageUrl  " +
                        $"FROM dbo.product AS p WITH(NOLOCK) " +
                        $"WHERE p.isDeleted=0; ";
                
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(sqlst, connection))
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            Product product = new Product();
                            product.PId = Convert.ToInt32(reader["pid"]);
                            product.ProductName = reader["productname"].ToString();
                            product.ProductPrice = Convert.ToDouble(reader["price"]);
                            product.AvailableStatus = Convert.ToChar(reader["availablestatus"]);
                            product.ImageUrl = reader["imageUrl"].ToString();

                            products.Add(product);
                        }
                    }
                }
            }
            catch (Exception)
            {
                
            }
            return products;
        }

        public IEnumerable<Product> SearchBykey(string key)
        {
            throw new NotImplementedException();
        }
        public bool UpdateProduct(Product updatedproduct)
        {
            SqlTransaction transaction = null;
            bool isUpdated = false;
             string sqlst = $"update dbo.product " +
                    $"SET productname = '{updatedproduct.ProductName}', " +
                    $" price = {updatedproduct.ProductPrice}, " +
                    $" availablestatus = '{updatedproduct.AvailableStatus}', " +
                    $"imageUrl = '{updatedproduct.ImageUrl}', " +
                    $" isDeleted = {updatedproduct.IsDeleted}  " +
                    $"WHERE pid = {updatedproduct.PId}; ";
            try
            {

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    transaction = connection.BeginTransaction();
                    using (SqlCommand command = new SqlCommand(sqlst, connection,transaction))
                    {
                        try
                        {
                            var noOfrows = command.ExecuteNonQuery();
                            if(noOfrows >0)
                                 transaction.Commit();
                            isUpdated = true;
                        }
                        catch (Exception)
                        {
                            transaction.Rollback();
                        }
                    }
                }
            }
            catch (Exception)
            {
                transaction.Rollback();
            }
            return isUpdated;

        }
        public bool DeleteProduct(Product deleteProduct)
        {
            bool isDeleted = false;
            SqlTransaction transaction = null;
            string sqlst = $" delete from dbo.product where pid = @deleteId ;";
            try
            {
                using(SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    transaction = connection.BeginTransaction();
                    using (SqlCommand command = new SqlCommand(sqlst,connection,transaction))
                    {
                        command.Parameters.AddWithValue("@deleteId", deleteProduct.PId);
                        try
                        {
                            var noOfrows = command.ExecuteNonQuery();
                            if (noOfrows > 0)
                                transaction.Commit();
                            isDeleted = true;
                        }
                        catch (Exception)
                        {
                            transaction.Rollback();
                        }
                    }
                }

            }
            catch (Exception )
            {
                throw;
            }
            return isDeleted;
            // throw new NotImplementedException();
        }

        public IEnumerable<Product> Pagination(int pageNumber)
        {
            List<Product> products = new List<Product>();
            string sqlst = "sp_Pagination";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(sqlst,connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    SqlParameter pageNo = command.Parameters.Add("@pageNo", System.Data.SqlDbType.Int);
                    pageNo.Value = pageNumber;
                    pageNo.Direction = System.Data.ParameterDirection.Input;
                    SqlDataReader reader = command.ExecuteReader();
                     while (reader.Read())
                    {
                        Product product = new Product();
                        product.PId = Convert.ToInt32(reader["rownumber"]);
                        product.ProductName = reader["productname"].ToString();
                        product.ProductPrice = Convert.ToDouble(reader["price"]);
                        product.AvailableStatus = Convert.ToChar(reader["availablestatus"]);
                        product.ImageUrl = reader["imageUrl"].ToString();

                        products.Add(product);
                    }
                }
            }
            return products;
        }
    }
}

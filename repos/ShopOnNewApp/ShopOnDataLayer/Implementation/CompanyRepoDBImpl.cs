using ShopOnCommonLayer.CustomExceptions;
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
    public class CompanyRepoDBImpl : ICompanyRepo
    {
        private readonly string connectionString=null;
        public CompanyRepoDBImpl()
        {
            ConnectionUtil connectionUtil = ConnectionUtil.GetInstance();
            connectionString = connectionUtil.GetConnectionString();
        }
        public bool AddCompany(Company company)
        {
            bool isAdded = false;
            SqlTransaction transaction = null;
            Company Existed = GetCompany(company.CompanyId);
            if (Existed is not null)
            {
                throw new Exception();
            }
            string sqlst = "insert " +
                               "into " +
                               "company (companyname)    " +
                               "values" +
                               "(@companyName)";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    transaction = connection.BeginTransaction();
                    using (SqlCommand command = new SqlCommand(sqlst, connection, transaction))
                    {
                        command.Parameters.AddWithValue("@companyname", company.CompanyName);
                        command.ExecuteNonQuery();
                        transaction.Commit();
                        isAdded = true;
                    }
                }
            }
            catch (Exception)
            {
                transaction.Rollback();
                throw;
            }
            return isAdded;
        }

        public IEnumerable<Company> GetCompanies()
        {
            List<Company> companies = new List<Company>();
            string sqlst = "select companyid ," +
                                    "companyname ," +
                                    "companystatus ," +
                                    "isdeleted " +
                                    "from company as c with(Nolock) " +
                                    "where c.isdeleted=0";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(sqlst, connection))
                {
                    SqlDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        Company company = new Company();
                        company.CompanyId = Convert.ToInt32(dataReader["companyid"]);
                        company.CompanyName = dataReader["companyname"].ToString();
                        company.CompanyStatus = dataReader["companystatus"].ToString();
                        company.IsDeleted = Convert.ToBoolean(dataReader["isDeleted"]);
                        companies.Add(company);
                    }
                }
            }
            return companies;
        }

        public Company GetCompany(int companyId)
        {
            Company company = null;
            string query = $"select " +
                                $"companyid ," +
                                $"companyname ," +
                                $"companystatus " +
                                $"from company as c with(NOLOCK) " +
                                $"where c.companyid=@companyid ";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@companyid", companyId);
                    SqlDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        company = new Company();
                        company.CompanyId = Convert.ToInt32(dataReader["companyid"]);
                        company.CompanyName = dataReader["companyname"].ToString();
                        company.CompanyStatus = dataReader["companystatus"].ToString();
                    }
                }
            }
            if(company == null)
            {
                throw new CompanyNotFoundException($"Company with {companyId} not found");
            }
            return company;
        }

        public bool UpdateCompany(Company company)
        {
            bool isUpdated = false;
            SqlTransaction transaction = null;
            string sqlst = $"update company " +
                                $"set " +
                                $"companyname=@companyName ," +
                                $"companystatus=@companyStatus ," +
                                $"isdeleted=@isDeleted " +
                                $"where companyid=@companyId ";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    transaction = connection.BeginTransaction();
                    using (SqlCommand command = new SqlCommand(sqlst, connection, transaction))
                    {
                        command.Parameters.AddWithValue("@companyName", company.CompanyName);
                        command.Parameters.AddWithValue("@companyStatus", company.CompanyStatus);
                        command.Parameters.AddWithValue("@isDeleted", company.IsDeleted);
                        command.Parameters.AddWithValue("@companyId", company.CompanyId);
                        command.ExecuteNonQuery();
                        isUpdated = true;
                        transaction.Commit();
                    }
                }
            }
            catch (Exception)
            {
                transaction.Rollback();
                throw;
            }
            return isUpdated;
        }

        public bool DeleteComapny(Company company)
        {
            bool isDeleted = false;
            SqlTransaction transaction = null;
            string sqlst = $"update company " +
                                $"set " +
                                $"isdeleted=@isDeleted " +
                                $"where companyid=@companyId ";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    transaction = connection.BeginTransaction();
                    using (SqlCommand command = new SqlCommand(sqlst, connection, transaction))
                    {
                        command.Parameters.AddWithValue("@isDeleted", company.IsDeleted);
                        command.Parameters.AddWithValue("@companyId", company.CompanyId);
                        command.ExecuteNonQuery();
                        isDeleted = true;
                        transaction.Commit();
                    }
                }
            }
            catch (Exception)
            {
                transaction.Rollback();
            }
            return isDeleted;
        }
    }
}

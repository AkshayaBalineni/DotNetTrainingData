using ShopOnBussinessLayer.Contracts;
using ShopOnCommonLayer.CustomExceptions;
using ShopOnCommonLayer.Models;
using ShopOnDataLayer.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnBussinessLayer.Implementation
{
    public class CompanyManager : ICompanyManager
    {
        private readonly ICompanyRepo companyRepository;

        public CompanyManager(ICompanyRepo companyRepo)
        {
            this.companyRepository = companyRepo;
        }
        public bool AddCompany(Company company)
        {
           return companyRepository.AddCompany(company);
        }

        public bool DeleteComapny(Company company)
        {
            return companyRepository.DeleteComapny(company);
        }

        public IEnumerable<Company> GetCompanies()
        {
            return companyRepository.GetCompanies();
        }

        public Company GetCompany(int companyId)
        {
            try
            {
                return companyRepository.GetCompany(companyId);
            }
            catch (Exception e)
            {

                throw new CompanyNotFoundException("Company not found", e.InnerException);
            }
        }

        public bool UpdateCompany(Company company)
        {
            return companyRepository.UpdateCompany(company);
        }
    }
}

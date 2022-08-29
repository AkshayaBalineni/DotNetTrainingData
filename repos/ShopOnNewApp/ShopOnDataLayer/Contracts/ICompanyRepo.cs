using ShopOnCommonLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnDataLayer.Contracts
{
    public interface ICompanyRepo
    {
        bool AddCompany(Company company);
        IEnumerable<Company> GetCompanies();
        Company GetCompany(int companyId);
        bool UpdateCompany(Company company);
        bool DeleteComapny(Company company);
    }
}

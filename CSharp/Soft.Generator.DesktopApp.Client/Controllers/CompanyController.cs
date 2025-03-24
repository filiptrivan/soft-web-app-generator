using Spider.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spider.DesktopApp.Client.Controllers
{
    public class CompanyController
    {
        public Company SaveCompany(Company company, List<long> selectedPermissionIds)
        {
            throw new NotImplementedException();
        }

        public List<Company> GetCompanyList()
        {
            throw new NotImplementedException();
        }

        public Company GetCompany(long id)
        {
            throw new NotImplementedException();
        }

        public void DeleteCompany(long id)
        {
            throw new NotImplementedException();
        }

        public List<Permission> GetPermissionList() 
        {
            throw new NotImplementedException();
        }

        public List<Permission> GetPermissionListForTheCompany(long companyId)
        {
            throw new NotImplementedException();
        }
    }
}

using Soft.Generator.DesktopApp.Entities;
using Soft.Generator.DesktopApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soft.Generator.DesktopApp.Controllers
{
    public class CompanyController
    {
        DesktopAppBusinessService _desktopAppBusinessService;

        public CompanyController(DesktopAppBusinessService desktopAppBusinessService)
        {
            _desktopAppBusinessService = desktopAppBusinessService;
        }

        public Company Login(Company company)
        {
            return _desktopAppBusinessService.Login(company);
        }

        public Company SaveCompany(Company company, List<long> selectedPermissionIds, Company currentCompany)
        {
            return _desktopAppBusinessService.SaveCompanyExtended(company, selectedPermissionIds, currentCompany);
        }

        public List<Company> GetCompanyList()
        {
            return _desktopAppBusinessService.GetCompanyList();
        }

        public Company GetCompany(long id)
        {
            return _desktopAppBusinessService.GetCompany(id);
        }

        public void DeleteCompany(long id, Company currentCompany)
        {
            _desktopAppBusinessService.DeleteCompany(id);
        }

        public List<Permission> GetPermissionList() 
        {
            return _desktopAppBusinessService.GetPermissionList();
        }

        public List<Permission> GetPermissionListForTheCompany(long companyId)
        {
            return _desktopAppBusinessService.GetPermissionListForCompanyList(new List<long> { companyId });
        }
    }
}

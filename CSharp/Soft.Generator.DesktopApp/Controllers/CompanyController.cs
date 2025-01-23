using Spider.DesktopApp.Entities;
using Spider.DesktopApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spider.DesktopApp.Controllers
{
    public class CompanyController
    {
        DesktopAppBusinessService _desktopAppBusinessService;

        public CompanyController(DesktopAppBusinessService desktopAppBusinessService)
        {
            _desktopAppBusinessService = desktopAppBusinessService;
        }

        public Company SaveCompany(Company company, List<long> selectedPermissionIds)
        {
            return _desktopAppBusinessService.SaveCompanyExtended(company, selectedPermissionIds);
        }

        public List<Company> GetCompanyList()
        {
            return _desktopAppBusinessService.GetCompanyList();
        }

        public Company GetCompany(long id)
        {
            return _desktopAppBusinessService.GetCompany(id);
        }

        public void DeleteCompany(long id)
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

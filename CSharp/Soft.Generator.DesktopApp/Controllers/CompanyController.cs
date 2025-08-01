using Soft.Generator.DesktopApp.Entities;
using Soft.Generator.DesktopApp.Services;
using Soft.Generator.Shared.Interfaces;
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
        ISqlConnection _connection;

        public CompanyController(DesktopAppBusinessService desktopAppBusinessService, ISqlConnection connection)
        {
            _desktopAppBusinessService = desktopAppBusinessService;
            _connection = connection;
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
            return new GetCompanyListSO(_connection).Execute();
        }

        public Company GetCompany(long id)
        {
            return new GetCompanySO(_connection, id).Execute();
        }

        public void DeleteCompany(long id, Company currentCompany)
        {
            new DeleteCompanySO(_connection, id).Execute();
        }

        public List<Permission> GetPermissionList() 
        {
            return new GetPermissionListSO(_connection).Execute();
        }

        public List<Permission> GetPermissionListForTheCompany(long companyId)
        {
            return new GetPermissionListForCompanyListSO(_connection, new List<long> { companyId }).Execute();
        }
    }
}

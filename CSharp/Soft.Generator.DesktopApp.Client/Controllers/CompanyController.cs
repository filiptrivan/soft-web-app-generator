using Soft.Generator.Shared.Classes;
using Soft.Generator.Shared.Shared;
using Spider.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Spider.DesktopApp.Client.Controllers
{
    public class CompanyController
    {
        public Company SaveCompany(Company company, List<long> selectedPermissionIds)
        {
            return Helpers.Request<Company>(new RequestBody
            {
                Args = [JsonSerializer.Serialize(company), JsonSerializer.Serialize(selectedPermissionIds)],
            });
        }

        public List<Company> GetCompanyList()
        {
            return Helpers.Request<List<Company>>(new RequestBody());
        }

        public Company GetCompany(long id)
        {
            return Helpers.Request<Company>(new RequestBody
            {
                Args = [$"{id}"],
            });
        }

        public void DeleteCompany(long id)
        {
            Helpers.Request(new RequestBody
            {
                Args = [$"{id}"],
            });
        }

        public List<Permission> GetPermissionList()
        {
            return Helpers.Request<List<Permission>>(new RequestBody());
        }

        public List<Permission> GetPermissionListForTheCompany(long companyId)
        {
            return Helpers.Request<List<Permission>>(new RequestBody
            {
                Args = [$"{companyId}"],
            });
        }
    }
}

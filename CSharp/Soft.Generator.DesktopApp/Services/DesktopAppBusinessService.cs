using Microsoft.Data.SqlClient;
using Soft.Generator.DesktopApp.Entities;
using Soft.Generator.DesktopApp.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soft.Generator.DesktopApp.Services
{
    /// <summary>
    /// Every get method is returning only flat data without any related data, because of performance
    /// When inserting data with a foreign key, only the Id field in related data is mandatory. Additionally, the Id must correspond to an existing record in the database.
    /// </summary>
    public class DesktopAppBusinessService : DesktopAppBusinessServiceGenerated
    {
        private readonly SqlConnection _connection;

        public DesktopAppBusinessService(SqlConnection connection)
            : base(connection)
        {
            _connection = connection;
        }

        public Company SaveCompanyExtended(Company company, List<long> selectedPermissionIds)
        {
            return _connection.WithTransaction(() =>
            {
                Company savedCompany = SaveCompany(company);

                UpdateCompanyPermissionListForCompany(company, selectedPermissionIds);

                return savedCompany;
            });
        }

        #region WebApplication

        [Obsolete("Delete if you don't need this method")]
        public WebApplication SaveWebApplicationExtended(WebApplication webApplication, List<long> selectedDllPathIds)
        {
            return _connection.WithTransaction(() =>
            {
                WebApplication savedWebApplication = SaveWebApplication(webApplication);

                return savedWebApplication;
            });
        }

        [Obsolete("Delete if you don't need this method")]
        public void DeleteWebApplicationFile(long webApplicationId, long dllPathId)
        {
            _connection.WithTransaction(() =>
            {
                WebApplicationFile webApplicationFile = GetWebApplicationFileList()
                    .Where(x => x.WebApplication.Id == webApplicationId && x.DllPath.Id == dllPathId)
                    .Single();

                DeleteEntity<WebApplicationFile, long>(webApplicationFile.Id);
            });
        }

        public List<WebApplicationFile> GenerateWebApplication(long webApplicationId)
        {
            _connection.WithTransaction(() =>
            {
                // dovuci web aplikaciju
                // dovuci sve asembli path-ove za web aplikaciju
                // 
            });

            return null;
        }

        #endregion
    }
}

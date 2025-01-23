using Microsoft.Data.SqlClient;
using Spider.DesktopApp.Entities;
using Spider.DesktopApp.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spider.DesktopApp.Services
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

        public void GenerateNetAndAngularStructure(long webApplicationId)
        {
            _connection.WithTransaction(() =>
            {
                WebApplication webApplication = GetWebApplication(webApplicationId);

                GeneratorService generatorService = new GeneratorService(null);

                generatorService.GenerateNetAndAngularStructure(Settings.ProjectsPath, webApplication.Name, Settings.PrimaryColor);
            });
        }

        public void GenerateBusinessFiles(long webApplicationId)
        {
            _connection.WithTransaction(() =>
            {
                WebApplication webApplication = GetWebApplication(webApplicationId);
                List<DllPath> dllPaths = GetDllPathListForWebApplication(webApplicationId);

                GeneratorService generatorService = new GeneratorService(dllPaths);

                generatorService.GenerateBusinessFiles(webApplication);
            });
        }

        #endregion
    }
}

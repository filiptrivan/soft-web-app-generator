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

        #region Company

        public Company Login(Company login)
        {
            return _connection.WithTransaction(() =>
            {
                Company company = GetCompanyList()
                    .Where(x => x.Email == login.Email && x.Password == login.Password)
                    .SingleOrDefault();

                if (company == null)
                    throw new Exception("Pogrešni kredencijali.");

                company.Permissions = GetPermissionListForCompanyList([company.Id]);

                return company;
            });
        }

        public Company SaveCompanyExtended(Company company, List<long> selectedPermissionIds, Company currentCompany)
        {
            return _connection.WithTransaction(() =>
            {
                if (
                    company.Id == 0 && currentCompany.Permissions.Any(x => x.Code == "InsertCompany") == false ||
                    company.Id > 0 && currentCompany.Permissions.Any(x => x.Code == "UpdateCompany") == false
                )
                {
                    throw new Exception("Greška: Nemate potrebna prava da biste izvršili operaciju.");
                }

                Company savedCompany = SaveCompany(company);

                UpdateCompanyPermissionListForCompany(company, selectedPermissionIds);

                return savedCompany;
            });
        }

        #endregion

        #region WebApplication

        public void GenerateNetAndAngularStructure(long webApplicationId)
        {
            _connection.WithTransaction(() =>
            {
                WebApplication webApplication = GetWebApplication(webApplicationId);

                GeneratorService generatorService = new GeneratorService(null);

                generatorService.GenerateNetAndAngularStructure(Settings.ProjectsPath, webApplication.Name, Settings.PrimaryColor);
            });
        }

        #endregion

    }
}

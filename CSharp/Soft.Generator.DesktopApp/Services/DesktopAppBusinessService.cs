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

        public GeneratedFile InsertGeneratedFile(GeneratedFile entity)
        {
            if (entity == null)
                throw new Exception("Ne možete da ubacite prazan objekat.");

            // FT: Not validating here property by property, because sql server will throw exception, we should already validate object on the form.

            string query = $"UPDATE GeneratedFile SET Id = @Id, DisplayName, ClassName, Namespace, Regenerate, ApplicationId, DomainFolderPathId) VALUES (@Id, @DisplayName, @ClassName, @Namespace, @Regenerate, @ApplicationId, @DomainFolderPathId);";

            _connection.WithTransaction(() =>
            {
                using (SqlCommand cmd = new SqlCommand(query, _connection))
                {
                    cmd.Parameters.AddWithValue("@Id", entity.Id);
                    cmd.Parameters.AddWithValue("@DisplayName", entity.DisplayName);
                    cmd.Parameters.AddWithValue("@ClassName", entity.ClassName);
                    cmd.Parameters.AddWithValue("@Namespace", entity.Namespace);
                    cmd.Parameters.AddWithValue("@Regenerate", entity.Regenerate);
                    cmd.Parameters.AddWithValue("@ApplicationId", entity.Application.Id);
                    cmd.Parameters.AddWithValue("@DomainFolderPathId", entity.DomainFolderPath.Id);

                    cmd.ExecuteNonQuery();
                }
            });

            return entity;
        }

        public Company SaveCompanyExtended(Company company, List<int> selectedPermissionIds)
        {
            return _connection.WithTransaction(() =>
            {
                Company savedCompany = SaveCompany(company);

                UpdateCompanyPermissionListForCompany(company, selectedPermissionIds);

                return savedCompany;
            });
        }

        public void UpdateCompanyPermissionListForCompany(Company company, List<int> selectedPermissionIds)
        {
            if (selectedPermissionIds == null)
                return;

            List<int> selectedIdsHelper = selectedPermissionIds.ToList();

            _connection.WithTransaction(() =>
            {
                // FT: Not doing authorization here, because we can not figure out here if we are updating while inserting object (eg. User), or updating object, we will always get the id which is not 0 here.

                List<Permission> permissionList = GetPermissionListForCompanyList(new List<int> { company.Id });

                foreach (Permission permission in permissionList.ToList())
                {
                    if (selectedIdsHelper.Contains(permission.Id))
                        selectedIdsHelper.Remove(permission.Id);
                    else
                        DeleteCompanyPermission(company.Id, permission.Id);
                }

                List<Permission> permissionListToInsert = GetPermissionList().Where(x => selectedIdsHelper.Contains(x.Id)).ToList(); // TODO FT: Add this to the generator so it is working in the SQL

                foreach (Permission permissionToInsert in permissionListToInsert)
                {
                    InsertCompanyPermission(new CompanyPermission
                    {
                        Company = company,
                        Permission = permissionToInsert
                    });
                }
            });
        }

//        public void DeleteCompanyPermission(int companyId, int permissionId)
//        {
//            string query = @$"
//DELETE
//FROM CompanyPermission
//WHERE CompanyId = @companyId && PermissionId = @permissionId
//";

//            _connection.WithTransaction(() =>
//            {
//                using (SqlCommand cmd = new SqlCommand(query, _connection))
//                {
//                    cmd.Parameters.AddWithValue("@companyId", companyId);
//                    cmd.Parameters.AddWithValue("@permissionId", permissionId);

//                    int rowsAffected = cmd.ExecuteNonQuery();

//                    if (rowsAffected == 0)
//                        throw new Exception("U sistemu nismo pronašli objekat koji želite da obrišete.");
//                }
//            });
//        }
    }
}

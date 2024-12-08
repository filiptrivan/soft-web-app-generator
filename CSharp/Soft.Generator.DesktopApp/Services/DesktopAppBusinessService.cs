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

        //public void UpdateCompanyPermissionListForCompany(Company company, List<long> selectedPermissionIds)
        //{
        //    if (selectedPermissionIds == null)
        //        return;

        //    List<long> selectedIdsHelper = selectedPermissionIds.ToList();

        //    _connection.WithTransaction(() =>
        //    {
        //        // FT: Not doing authorization here, because we can not figure out here if we are updating while inserting object (eg. User), or updating object, we will always get the id which is not 0 here.

        //        List<Permission> permissionList = GetPermissionListForCompanyList(new List<long> { company.Id });

        //        foreach (Permission permission in permissionList.ToList())
        //        {
        //            if (selectedIdsHelper.Contains(permission.Id))
        //                selectedIdsHelper.Remove(permission.Id);
        //            else
        //                DeleteCompanyPermission(company.Id, permission.Id);
        //        }

        //        List<Permission> permissionListToInsert = GetPermissionList().Where(x => selectedIdsHelper.Contains(x.Id)).ToList(); // TODO FT: Add this to the generator so it is working in the SQL

        //        foreach (Permission permissionToInsert in permissionListToInsert)
        //        {
        //            InsertCompanyPermission(new CompanyPermission
        //            {
        //                Company = company,
        //                Permission = permissionToInsert
        //            });
        //        }
        //    });
        //}

        #region WebApplication

        public List<DllPath> GetDllPathListForWebApplication(long webApplicationId)
        {
            List<DllPath> result = new List<DllPath>();

            List<WebApplicationFile> webApplicationFiles = base.GetWebApplicationFileListForWebApplication(webApplicationId);

            foreach (WebApplicationFile webApplicationFile in webApplicationFiles)
            {
                if (result.Contains(webApplicationFile.DllPath) == false)
                    result.Add(webApplicationFile.DllPath);
            }

            return result;
        }

        public WebApplication SaveWebApplicationExtended(WebApplication webApplication, List<long> selectedDllPathIds)
        {
            return _connection.WithTransaction(() =>
            {
                WebApplication savedWebApplication = SaveWebApplication(webApplication);

                //UpdateWebApplicationDllPathListForWebApplication(webApplication, selectedDllPathIds);

                return savedWebApplication;
            });
        }

        //public void UpdateWebApplicationDllPathListForWebApplication(WebApplication webApplication, List<long> selectedDllPathIds)
        //{
        //    if (selectedDllPathIds == null)
        //        return;

        //    List<long> selectedIdsHelper = selectedDllPathIds.ToList();

        //    _connection.WithTransaction(() =>
        //    {
        //        // FT: Not doing authorization here, because we can not figure out here if we are updating while inserting object (eg. User), or updating object, we will always get the id which is not 0 here.

        //        List<DllPath> dllPathList = GetDllPathListForWebApplicationList(new List<long> { webApplication.Id });

        //        foreach (DllPath dllPath in dllPathList.ToList())
        //        {
        //            if (selectedIdsHelper.Contains(dllPath.Id))
        //                selectedIdsHelper.Remove(dllPath.Id);
        //            else
        //                DeleteWebApplicationFile(webApplication.Id, dllPath.Id);
        //        }

        //        List<DllPath> dllPathListToInsert = GetDllPathList().Where(x => selectedIdsHelper.Contains(x.Id)).ToList(); // TODO FT: Add this to the generator so it is working in the SQL

        //        foreach (DllPath dllPathToInsert in dllPathListToInsert)
        //        {
        //            InsertWebApplicationFile(new WebApplicationFile
        //            {
        //                WebApplication = webApplication,
        //                DllPath = dllPathToInsert,
                        
        //            });
        //        }
        //    });
        //}

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

        #endregion
    }
}

using Spider.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spider.DesktopApp.Client.Controllers
{
    public class WebApplicationController
    {
        public WebApplication SaveWebApplication(WebApplication webApplication)
        {
            throw new NotImplementedException();
        }

        public void DeleteWebApplication(long id)
        {
            return;
        }

        public List<WebApplication> GetWebApplicationList()
        {
            throw new NotImplementedException();
        }

        public WebApplication GetWebApplication(long id)
        {
            throw new NotImplementedException();
        }

        public List<Company> GetCompanyList()
        {
            throw new NotImplementedException();
        }

        public List<Setting> GetSettingList()
        {
            throw new NotImplementedException();
        }

        public List<DllPath> GetDllPathList()
        {
            throw new NotImplementedException();
        }

        public List<DllPath> GetDllPathListForTheWebApplication(long webApplicationId)
        {
            throw new NotImplementedException();
        }

        public void GenerateNetAndAngularStructure(long webApplicationId)
        {
            return;
        }

        public void GenerateBusinessFiles(long webApplicationId)
        {
            return;
        }
    }
}

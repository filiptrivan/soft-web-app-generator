using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spider.DesktopApp
{
    public static class Settings
    {
        public static string ConnectionString = "Data source=DESKTOP-LRUAM92\\SQLEXPRESS;Initial Catalog=SoftGeneratorDA;Integrated Security=True;Encrypt=false";

        public static string EntitiesNamespaceEnding = "Entities";
        public static string DTONamespaceEnding = "DTO";
        public static string DownloadPath = @"C:\Users\user\Downloads";
        public static string ClientApplicationBasePath = @""; // Dodaj dodatno dugme, generisi UI strukturu
        public static string GeneralStylesFrontendPath = @"C:\Users\user\Documents\Projects\PlayertyLoyals\playerty-loyals\Angular\src\assets\primeng\styles";
        public static string GeneralCoreFrontendPath = @"C:\Users\user\Documents\Projects\PlayertyLoyals\playerty-loyals\Angular\src\app\core";
        public static string PrimaryColor = @"#cccccc";
        public static string ProjectsPath = @"C:\Users\user\Documents\Projects"; // Add this into Company table.
    }
}

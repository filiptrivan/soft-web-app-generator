﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soft.Generator.DesktopApp
{
    public static class Settings
    {
        public static string ConnectionString = "Data source=DESKTOP-LRUAM92\\SQLEXPRESS;Initial Catalog=SoftGeneratorDA;Integrated Security=True;Encrypt=false";

        public static string EntitiesNamespaceEnding = "Entities";
        public static string DTONamespaceEnding = "DTO";
        public static string BaseProjectNamespace = "Playerty.Loyals";
        public static string BaseBusinessServiceName = "Loyals";
        public static string DownloadPath = @"C:\Users\user\Downloads";
        public static int LimitLengthForTextArea = 256;
        public static string ClientApplicationBasePath = @""; // Dodaj dodatno dugme, generisi UI strukturu
    }
}

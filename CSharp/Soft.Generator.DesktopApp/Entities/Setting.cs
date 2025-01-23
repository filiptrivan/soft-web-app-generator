using Spider.DesktopApp.Attributes;
using Spider.DesktopApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spider.DesktopApp.Entities
{
    public class Setting : ISoftEntity
    {
        [Identifier]
        public long Id { get; set; }

        public string Name { get; set; }

        public bool HasGoogleAuth { get; set; }

        public string PrimaryColor { get; set; }

        public bool HasLatinTranslate { get; set; }

        public bool HasDarkMode { get; set; }

        public bool HasNotifications { get; set; }

        public virtual Framework Framework { get; set; }

        public virtual List<WebApplication> Applications { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}

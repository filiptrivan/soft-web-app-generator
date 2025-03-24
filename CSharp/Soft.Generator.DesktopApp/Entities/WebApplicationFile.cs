using Spider.Shared.Attributes;
using Spider.DesktopApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spider.DesktopApp.Entities
{
    public class WebApplicationFile : ISoftEntity
    {
        [Identifier]
        public long Id { get; set; }

        public string DisplayName { get; set; }

        public string ClassName { get; set; }

        public string Namespace { get; set; }

        public bool Regenerate { get; set; }

        public bool Generated { get; set; }

        [ManyToOneRequired]
        public virtual WebApplication WebApplication { get; set; }

        public virtual DllPath DllPath { get; set; }

        public override string ToString()
        {
            return DisplayName;
        }
    }
}

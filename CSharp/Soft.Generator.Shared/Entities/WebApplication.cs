using Spider.Shared.Attributes;
using Spider.DesktopApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spider.Shared.Entities
{
    public class WebApplication : ISoftEntity
    {
        [Identifier]
        public long Id { get; set; }

        public string Name { get; set; }

        [ManyToOneRequired]
        public virtual Company Company { get; set; }

        public virtual Setting Setting { get; set; }

        public virtual List<DllPath> DllPaths { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}

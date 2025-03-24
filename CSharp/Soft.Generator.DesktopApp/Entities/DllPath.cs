using Spider.Shared.Attributes;
using Spider.DesktopApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spider.DesktopApp.Entities
{
    public class DllPath : ISoftEntity
    {
        [Identifier]
        public long Id { get; set; }

        public string Path { get; set; }

        public virtual WebApplication WebApplication { get; set; }

        public override string ToString()
        {
            return Path;
        }
    }
}

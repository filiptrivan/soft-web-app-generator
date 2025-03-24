using Spider.Shared.Attributes;
using Spider.DesktopApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spider.Shared.Entities
{
    public class Framework : ISoftEntity
    {
        [Identifier]
        public long Id { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }

        public virtual List<Setting> Settings { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}

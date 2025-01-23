using Spider.DesktopApp.Attributes;
using Spider.DesktopApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spider.DesktopApp.Entities
{
    /// <summary>
    /// Cascade delete is done in sql
    /// </summary>
    [ManyToMany]
    public class CompanyPermission
    {
        public virtual Company Company { get; set; }

        public virtual Permission Permission { get; set; }
    }
}

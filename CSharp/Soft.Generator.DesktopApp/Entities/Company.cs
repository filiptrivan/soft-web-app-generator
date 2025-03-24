using Spider.Shared.Attributes;
using Spider.Shared.Attributes.UI;
using Spider.DesktopApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spider.DesktopApp.Entities
{
    [MenuName("PartnerAdministration")]
    public class Company : ISoftEntity
    {
        [Identifier]
        public long Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public virtual List<WebApplication> Applications { get; set; }

        [ManyToMany("CompanyPermission")]
        public virtual List<Permission> Permissions { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}

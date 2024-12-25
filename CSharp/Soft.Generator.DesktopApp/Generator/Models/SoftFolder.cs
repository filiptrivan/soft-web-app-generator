using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soft.Generator.DesktopApp.Generator.Models
{
    public class SoftFolder
    {
        public string Name { get; set; }
        public List<SoftFolder> ChildFolders { get; set; } = new();
        public List<SoftFile> SoftFiles { get; set; } = new();
    }
}

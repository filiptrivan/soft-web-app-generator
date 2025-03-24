using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spider.Shared.Attributes.UI
{
    public class MenuNameAttribute : Attribute
    {
        public string Name { get; }

        public MenuNameAttribute(string name)
        {
            Name = name;
        }
    }
}

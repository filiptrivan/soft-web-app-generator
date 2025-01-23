using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spider.DesktopApp.Attributes
{
    public class ManyToManyAttribute : Attribute
    {
        /// <summary>
        /// For the properties
        /// </summary>
        /// <param name="value">ManyToMany table</param>
        public ManyToManyAttribute(string value) { }

        public ManyToManyAttribute() { }
    }
}

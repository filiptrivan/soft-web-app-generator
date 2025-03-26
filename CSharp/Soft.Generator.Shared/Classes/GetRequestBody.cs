using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soft.Generator.Shared.Classes
{
    public class GetRequestBody
    {
        public string ControllerName { get; set; }
        public string MethodName { get; set; }
        public List<string> Args { get; set; } = new();
    }
}

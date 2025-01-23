using Spider.DesktopApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spider.DesktopApp.Interfaces
{
    public interface IFileGenerator
    {
        void Generate(List<Type> entities, WebApplication webApplication);
    }
}

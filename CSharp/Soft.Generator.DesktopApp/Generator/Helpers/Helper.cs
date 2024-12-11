using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soft.Generator.DesktopApp.Generator.Helpers
{
    public class Helper
    {
        public static void WriteToTheFile(string data, string path)
        {
            if (data != null)
            {
                StreamWriter sw = new StreamWriter(path, false);
                sw.WriteLine(data);
                sw.Close();
            }
        }

        public static void WriteToTheFile(StringBuilder data, string path)
        {
            if (data != null)
            {
                StreamWriter sw = new StreamWriter(path, false);
                sw.WriteLine(data);
                sw.Close();
            }
        }
    }
}

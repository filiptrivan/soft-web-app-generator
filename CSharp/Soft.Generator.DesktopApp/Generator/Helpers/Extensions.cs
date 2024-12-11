using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Soft.Generator.DesktopApp.Generator.Helpers
{
    public static class Extensions
    {
        public static string FirstCharToLower(this string input)
        {
            switch (input)
            {
                case null: throw new ArgumentNullException(nameof(input));
                case "": throw new ArgumentException($"{nameof(input)} cannot be empty", nameof(input));
                default: return input.First().ToString().ToLower() + input.Substring(1);
            }
        }

        public static bool IsManyToOneType(this Type type)
        {
            return type.IsClass || type.IsInterface;
        }

        //private List<PropertyInfo> GetPropertiesForTheTable(this Type DTOEntity)
        //{
        //    return DTOEntity.GetProperties().Where(x => x.);
        //}
    }
}

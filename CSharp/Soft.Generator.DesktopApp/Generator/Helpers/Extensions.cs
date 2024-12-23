using Pluralize.NET;
using Soft.Generator.DesktopApp.Attributes.UI;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Soft.Generator.DesktopApp.Generator.Helpers
{
    public static class Extensions
    {

        public static bool IsManyToOneType(this Type type)
        {
            return (type.IsClass || type.IsInterface) && type != typeof(string);
        }

        #region Case

        public static string FirstCharToLower(this string input)
        {
            switch (input)
            {
                case null: throw new ArgumentNullException(nameof(input));
                case "": throw new ArgumentException($"{nameof(input)} cannot be empty", nameof(input));
                default: return input.First().ToString().ToLower() + input.Substring(1);
            }
        }

        public static string SpaceEveryUpperChar(this string input)
        {
            if (string.IsNullOrEmpty(input))
                return input;

            var result = new System.Text.StringBuilder();
            foreach (char c in input)
            {
                if (char.IsUpper(c) && result.Length > 0)
                {
                    result.Append(' ');
                }
                result.Append(c);
            }

            return result.ToString();
        }

        #endregion

        #region Is Type

        public static bool IsDTOType(this Type type)
        {
            try
            {
                return type != null && type.IsClass && type.Namespace != null && type.Namespace.EndsWith($".{Settings.DTONamespaceEnding}");
            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.Message);
                return false;
            }
        }

        public static bool IsEntityType(this Type type)
        {
            try
            {
                return type != null && type.IsClass && type.Namespace != null && type.Namespace.EndsWith($".{Settings.EntitiesNamespaceEnding}");
            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.Message);
                return false;
            }
        }

        public static bool IsWholeNumber(this Type type)
        {
            return type == typeof(byte) || type == typeof(byte?) || type == typeof(int) || type == typeof(int?) || type == typeof(long) || type == typeof(long?);
        }

        public static bool IsDecimal(this Type type)
        {
            return type == typeof(decimal) || type == typeof(decimal?);
        }

        public static int GetDecimalScale(this PropertyInfo property)
        {
            return (int)property.SafeGetAttribute<PrecisionAttribute>().Scale;
        }

        public static bool IsDateTime(this Type type)
        {
            return type == typeof(DateTime) || type == typeof(DateTime?);
        }

        public static bool IsAutocomplete(this PropertyInfo property)
        {
            return property.SafeGetAttribute<AutocompleteAttribute>() != null;
        }

        public static bool IsDropdown(this PropertyInfo property)
        {
            return property.SafeGetAttribute<DropdownAttribute>() != null;
        }

        public static bool IsListType(this Type type)
        {
            return type.Name.Contains("List<");
        }

        #endregion

        #region Case

        public static string FromPascalToKebabCase(this string pascalCaseString)
        {
            if (string.IsNullOrEmpty(pascalCaseString))
            {
                return string.Empty;
            }

            string kebabCaseString = Regex.Replace(pascalCaseString, "([a-z])([A-Z])", "$1-$2");
            kebabCaseString = kebabCaseString.ToLower();

            return kebabCaseString;
        }

        public static string Pluralize(this string value)
        {
            IPluralize pluralizer = new Pluralizer();
            return pluralizer.Pluralize(value);
        }

        #endregion

        #region Reflection

        public static List<T> SafeGetAttributes<T>(this Type type) where T : Attribute
        {
            try
            {
                return type.GetCustomAttributes<T>().ToList();
            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.Message);

                return new List<T>();
            }
        }

        public static T SafeGetAttribute<T>(this Type type) where T : Attribute
        {
            try
            {
                return type.GetCustomAttribute<T>();
            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.Message);

                return null;
            }
        }

        public static List<T> SafeGetAttributes<T>(this PropertyInfo property) where T : Attribute
        {
            try
            {
                return property.GetCustomAttributes<T>().ToList();
            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.Message);

                return new List<T>();
            }
        }

        public static T SafeGetAttribute<T>(this PropertyInfo property) where T : Attribute
        {
            try
            {
                return property.GetCustomAttribute<T>();
            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.Message);

                return null;
            }
        }

        //private List<PropertyInfo> GetPropertiesForTheTable(this Type DTOEntity)
        //{
        //    return DTOEntity.GetProperties().Where(x => x.);
        //}

        #endregion
    }
}

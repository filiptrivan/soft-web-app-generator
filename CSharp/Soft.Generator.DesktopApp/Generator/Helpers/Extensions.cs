﻿using System;
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

        public static bool IsDateTime(this Type type)
        {
            return type == typeof(DateTime) || type == typeof(DateTime?);
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

        #endregion

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
    }
}

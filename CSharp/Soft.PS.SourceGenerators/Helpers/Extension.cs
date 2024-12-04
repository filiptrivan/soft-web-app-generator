﻿using Microsoft.CodeAnalysis.CSharp.Syntax;
using Soft.SourceGenerator.NgTable.Helpers;
using Soft.SourceGenerators.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace Soft.SourceGenerators.Helpers
{
    public static class Extension
    {
        /// <summary>
        /// There is more performant way but this is NET2
        /// </summary>
        public static string FirstCharToUpper(this string input)
        {
            switch (input)
            {
                case null: throw new ArgumentNullException(nameof(input));
                case "": throw new ArgumentException($"{nameof(input)} cannot be empty", nameof(input));
                default: return input.First().ToString().ToUpper() + input.Substring(1);
            }
        }

        /// <summary>
        /// There is more performant way but this is NET2
        /// </summary>
        public static string FirstCharToLower(this string input)
        {
            switch (input)
            {
                case null: throw new ArgumentNullException(nameof(input));
                case "": throw new ArgumentException($"{nameof(input)} cannot be empty", nameof(input));
                default: return input.First().ToString().ToLower() + input.Substring(1);
            }
        }

        /// <summary>
        /// User -> true
        /// string -> false
        /// List<User> -> false
        /// </summary>
        public static bool PropTypeIsManyToOne(this string propType)
        {
            if (propType.IsEnumerable())
                return false;
            if (propType.IsBaseType())
                return false;

            return true;
        }

        public static bool IsEnumerable(this string propType)
        {
            return propType.Contains("List") || propType.Contains("IList") || propType.Contains("[]");
        }

        public static bool IsBaseType(this string propType)
        {
            return
                propType == "string" ||
                propType == "bool" ||
                propType == "bool?" ||
                propType == "DateTime" ||
                propType == "DateTime?" ||
                propType == "long" ||
                propType == "long?" ||
                propType == "int" ||
                propType == "int?" ||
                propType == "decimal" ||
                propType == "decimal?" ||
                propType == "float" ||
                propType == "float?" ||
                propType == "double" ||
                propType == "double?" ||
                propType == "byte" ||
                propType == "byte?" ||
                propType == "Guid";
        }

        public static bool IsIdentifier(this SoftProperty property)
        {
            return property.Attributes.Any(x => x.Name == "Identifier");
        }

        /// <summary>
        /// The same method is in the .NET8 linq, but source generator is .NET2
        /// </summary>
        public static IEnumerable<T> DistinctBy<T, TKey>(this IEnumerable<T> items, Func<T, TKey> property)
        {
            return items.GroupBy(property).Select(x => x.First());
        }

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

        public static string GetBaseType(this ClassDeclarationSyntax c)
        {
            TypeSyntax baseType = c.BaseList?.Types.FirstOrDefault()?.Type; //BaseClass<long>

            if (baseType != null)
                return baseType.ToString();

            return null; // FT: many to many doesn't have base class
        }
    }
}

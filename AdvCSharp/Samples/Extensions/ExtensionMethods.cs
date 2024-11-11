using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace AdvancedCSharp.Samples.Extensions
{
    public class Ext
    {
        static void Main()
        {
            var list = new List<string>();
            //list.GetDefaultfNull().Count;
            var newList = list.GetDefaultfNull("Hi");


            list.AddOneElement("newElement");

            //list.Count == 1;

            var newerList = list.AddOneElementImmutable("newElement");
            //list.Count == 1;
            //newerList.Count == 2;

        }
    }
    public static class ExtensionMethods
    {


        public static void AddOneElement<T>(this List<T> items, T newelement)
        {
            items.Add(newelement);
        }
        public static IList<T> AddOneElementImmutable<T>(this List<T> items, T newelement)
        {
            items = new List<T>();
            items.Add(newelement);
            return items;
        }

        public static IEnumerable<T> GetDefaultfNull<T>(this IEnumerable<T> items, T defaultVal)
        {
            if (items == null)
            {
                return new List<T>() { defaultVal };
            }
            return items;
        }
        public static IEnumerable<T> Reverse<T>(this IEnumerable<T> items, T defaultVal)
        {
            items = new List<T>(items.Reverse());
            return items;
        }


        public static string GetAssemblyRootPath(this Assembly assembly)
        {
            return Path.GetDirectoryName(new Uri(assembly.Location).LocalPath);
        }

        public static bool IsValidEmailAddress(this string email)
        {
            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$");
            return regex.IsMatch(email);
        }
    }
}

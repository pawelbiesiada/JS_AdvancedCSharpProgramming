﻿using System;
using System.Reflection;
using System.IO;
using System.Linq;
using AdvancedCSharp.Samples.Class;

namespace AdvancedCSharp.Samples.Reflection
{
    class ReflectionOverview
    {
        static void Main(string[] args)
        {
            var assembly = Assembly.GetExecutingAssembly();
            //var assembly = Assembly.LoadFile(@"C:\Program Files (x86)\Microsoft\ILMerge\MergedLibrary.dll");

            Console.WriteLine("Assembly Full Name:");
            Console.WriteLine(assembly.FullName);

            var classCar = assembly.DefinedTypes.FirstOrDefault(c => c.IsClass && c.Name.StartsWith("Car"));

           // classCar.Attributes

            if (classCar != null)
            {
                var m = classCar.GetMethod("Drive");
                //m.

                var c = new Car(10);

                c.Distance = 3;

                Console.WriteLine($"Property {nameof(c.Distance)} has value {c.Distance}");



            }

            AssemblyName assemblyName = assembly.GetName();
            Console.WriteLine("\nName: {0}", assemblyName.Name);
            Console.WriteLine("Version: {0}.{1}", assemblyName.Version.Major, assemblyName.Version.Minor);
            Console.WriteLine("Build time: {0}", GetAssemblyBuildTime(assembly));

            Console.WriteLine("\nAssembly Location:");
            Console.WriteLine(assembly.Location);

            Console.WriteLine("\nAssembly entry point:");
            Console.WriteLine(assembly.EntryPoint);

            Console.ReadKey();
        }

        public static DateTime GetAssemblyBuildTime( Assembly assembly, TimeZoneInfo target = null)
        {
            var filePath = assembly.Location;
            const int cPeHeaderOffset = 60;
            const int cLinkerTimestampOffset = 8;
            var b = new byte[2048];
            Stream s = null;

            try
            {
                s = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                s.Read(b, 0, 2048);
            }
            finally
            {
                if (s != null)
                {
                    s.Close();
                }
            }

            var i = BitConverter.ToInt32(b, cPeHeaderOffset);
            var secondsSince1970 = BitConverter.ToInt32(b, i + cLinkerTimestampOffset);
            var dt = new DateTime(1970, 1, 1, 0, 0, 0);
            dt = dt.AddSeconds(secondsSince1970);
            var tz = target ?? TimeZoneInfo.Local;
            dt = dt.AddHours(tz.GetUtcOffset(dt).Hours);
            return dt;
        }
    }
}

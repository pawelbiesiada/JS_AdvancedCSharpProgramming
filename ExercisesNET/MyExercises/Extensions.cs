using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercisesNET.MyExercises
{
    public static class Extensions
    {
        public static string GetFirstOrEmptyIfNullOrEmpty(this IEnumerable<string> collection)
        {
            return collection.FirstOrDefault() ?? string.Empty;
        }
        public static int CountWords(this string text)
        {
            return text.Split(" ").Length;
        }

        public static T ToEnum<T>(this string value, bool ignorecase) where T : struct
        {
            var result = Enum.TryParse<T>(value, ignorecase, out var resultEnum);
            
            return result ? resultEnum : throw new Exception();
        }

        public static void Convert()
        {
            var par = "warning";

            var enumLogLevel = par.ToEnum<LogLevel>(true);
        }


        public enum LogLevel
        {
            Debug,
            Warning,
            Error
        }
    }
}

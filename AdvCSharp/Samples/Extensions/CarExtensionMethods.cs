using AdvancedCSharp.Samples.Class.Inheritance;

namespace AdvancedCSharp.Samples.Extensions
{
    public static class CarExtensionMethods
    {
        public static void WorkHard(this Bulldozer bulldozer)
        {
            while (!bulldozer.IsServiceCheckNeeded())
            {
                bulldozer.DoSomeWork();
            }
        }
        public static string WorkHard(this Bulldozer bulldozer, int times)
        {
            while (!bulldozer.IsServiceCheckNeeded() && times > 0)
            {
                bulldozer.DoSomeWork();
                times--;
            }

            return "Work completed";
        }
    }
}

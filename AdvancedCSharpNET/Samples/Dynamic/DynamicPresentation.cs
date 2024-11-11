using System;
using System.Reflection;
using AdvancedCSharp.Samples.Reflection;

namespace AdvancedCSharp.Samples.Dynamic
{
    class DynamicPresentation
    {
        static void Main()
        {
            byte b = 1;
            dynamic d = b;
            Console.WriteLine("Value: {0} \tType: {1}", d, d.GetType());
            d += 1;
            Console.WriteLine("Value: {0} \tType: {1}", d, d.GetType());
            d = "Text";
            Console.WriteLine("Value: {0} \tType: {1}", d, d.GetType());
            d = 1 + "1";
            Console.WriteLine("Value: {0} \tType: {1}",d, d.GetType());
            
            var asm = Assembly.GetExecutingAssembly();
            d = asm.CreateInstance(CreateInstance.SampleClass, false, BindingFlags.ExactBinding, null, new object[] { 0 }, null, null);
            Console.WriteLine("\nType is: {0} \nPropertyFactor property value is: {1}", d.GetType(), d.PropertyFactor);
            Console.WriteLine("Sum 0 + 2 = {0}", d.Sum(2));
            var sumBefore = d.Sum();
            d.Divide();
            d.IncrementField();
            var sumAfter = d.Sum();
            Console.WriteLine("Sum before increment is: {0} and after increment: {1}.", sumBefore, sumAfter);
            //Console.WriteLine("Say sth: {0}", d.SayHello()); //This violates visibility contraint - RuntimeBinderException from Microsoft.CSharp assembly
            //d.Divide(); // this throws RuntimeBinderException for no such method

            Console.ReadKey();
        }

    }
}

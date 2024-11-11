using System;
using System.Linq;
using System.Reflection;

namespace AdvancedCSharp.Samples.Reflection
{
    class CreateInstance
    {
        public const string SampleClass = "AdvancedCSharp.Samples.Reflection.SampleClass";
        public const string MyGenericClass = "AdvancedCSharp.Samples.Reflection.MyGeneric`1";

        static void Main()
        {
            var assembly = Assembly.GetExecutingAssembly();
            //object initialization
            object sampleClassObject = assembly.CreateInstance(SampleClass, false,
                BindingFlags.ExactBinding,
                null, new object[] { 2 }, null, null);
            var classType = assembly.GetType(SampleClass);

            //generic type initialization
            var genericType = assembly.GetType("AdvancedCSharp.Samples.Reflection.VersionUpdate");
            
            //var genericTypeReadyToCreate = genericType.MakeGenericType(classType);
            //var obj = Activator.CreateInstance(genericTypeReadyToCreate);

            //Invokin a method via Reflection
            MethodInfo sum = classType.GetMethod("Sum", new Type[] { typeof(Int32) });
            object ret = sum.Invoke(sampleClassObject, new object[] { 10 }); 
            Console.WriteLine("Sum returned {0}.", ret); // 2+0+10=12   _fieldFactor + PropertyFactor + parameter

            PropertyInfo prop = classType.GetProperty("PropertyFactor");
            prop.SetValue(sampleClassObject, 3);
            ret = sum.Invoke(sampleClassObject, new Object[] { 10 });
            Console.WriteLine("Sum returned {0}.", ret); // 2+3+10=15

            var field = classType.GetField("_fieldFactor", BindingFlags.NonPublic|BindingFlags.Instance);
            field.SetValue(sampleClassObject, 33);
            ret = sum.Invoke(sampleClassObject, new Object[] { 20 });
            Console.WriteLine("Sum returned {0}.", ret); // 33+3+20=56
            
            var increment = classType.GetMethod("IncrementField");
            var voidRes = increment.Invoke(sampleClassObject, new object[] { }); 
            ret = sum.Invoke(sampleClassObject, new object[] { 3 }); 
            Console.WriteLine("Sum returned {0}.", ret); // 34+3+3=40

            //var hello = classType.GetMethod("SayHello"); // this returns null - can't find nonPublic members
            var hello = classType.GetMethod("SayHello", BindingFlags.NonPublic | BindingFlags.Instance);
            var str = hello.Invoke(sampleClassObject, new object[0]);
            Console.WriteLine(str);

            Console.WriteLine();
            var methods = classType.GetMethods(BindingFlags.Public | BindingFlags.NonPublic 
                | BindingFlags.Instance | BindingFlags.Static
                | BindingFlags.DeclaredOnly).ToList();
            methods.ForEach(mth => Console.WriteLine(PrintMethodDeclaration(mth)));
            Console.ReadKey();
        }

        static string PrintMethodDeclaration(MethodInfo method)
        {
            string parameters = "";
            foreach (var param in method.GetParameters())
            {
                parameters += param.ParameterType.Name + " " + param.Name + ", "; 
            }
            parameters = parameters.Substring(0, Math.Max(0,parameters.Length - 2));

            return string.Format("{0} {1}({2})", method.ReturnType.Name, method.Name, parameters);
        }
    }

    public class SampleClass
    {
        public int PropertyFactor { get; private set; }
        private int _fieldFactor;

        public SampleClass(int f)
        {
            _fieldFactor = f;
        }

        public int Sum(int parameter)
        {
            return PropertyFactor + _fieldFactor + parameter;
        }
        public int Sum(int parameter1, int parameter2)
        {
            return PropertyFactor + _fieldFactor + parameter1 + parameter2;
        }
        public int Sum()
        {
            return PropertyFactor + _fieldFactor;
        }

        public void IncrementField()
        {
            _fieldFactor++;
        }

        private string SayHello()
        {
            return "Hello";
        }
    }

    public struct Complex
    {
        public double Real;
        public double Imaginary;

        public Complex(double real, double imaginary)
        {
            Real = real;
            Imaginary = imaginary;
        }
    }

    public enum Count
    {
        Zero = 0,
        One = 1,
        Many = 2
    }

    public class MyGeneric<T> where T : class
    {
        public string GetTypeName()
        {
            return typeof(T).Name;
        }
    }
}

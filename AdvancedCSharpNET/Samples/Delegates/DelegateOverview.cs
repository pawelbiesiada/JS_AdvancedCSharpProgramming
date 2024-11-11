using System;

namespace AdvancedCSharp.Samples.Delegates
{
    public delegate int IntOperation(int x, int y);

    internal class DelegateOverview
    {
        private static Action<int, int> _action;
        static void Main()
        {
            var a = 3;
            var b = 2;

            IntOperation operation = (x, y) => { Console.WriteLine("add"); return x + y; };
            //var operation = new IntOperation((x, y) => { return x - y; });  //or this
             //var operation = new IntOperation(Math.Min);                    //or this

            var ret = operation.Invoke(a,b); //sum
            Console.WriteLine("Sum on {0} and {1} is {2}", a,b, ret);

            operation = (x, y) => { Console.WriteLine("sub"); return x - y; };
            ret = operation.Invoke(a, b); //subtraction
            Console.WriteLine("Subtraction on {0} and {1} is {2}", a, b, ret);

            operation = (x, y) => { Console.WriteLine("prod"); return x * y; }; //what about += events
            ret = operation.Invoke(a, b); //product
            Console.WriteLine("Product on {0} and {1} is {2}", a, b, ret);

            /*
             * Action  void Foo()
             * Action<T,U> void Foo(T a, U b) 
             * 
             * Func<R> R Foo()
             * 
             * Func<T, U> U Foo(T a)
             * 
             * 
             * Func<Action<string>, List<int>>    List<int> Foo(Action<string> str)
             */

            Func<int, int, int> func = Func;//new Func<int, int, int>(operation);
            Action<int, int> action = ((x, y) =>
            {
                Console.WriteLine(ret);
                Console.WriteLine(operation(x, y));
            });
            _action = action;
            _action(4, 5); //_action.Invoke(4, 5);
            Console.ReadKey();
        }

        private static int Func(int arg1, int arg2)
        {
            throw new NotImplementedException();
        }

    }
}

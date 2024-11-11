using System;
using System.Reflection;
using Exercises;

namespace HelloWorldPlugin
{
    public class Hello : IPlugin
    {
        private const string helloText = "Hello from {0}!";

        public void Execute()
        {
            Console.WriteLine(helloText);
        }

        public string GetText()
        {
            return string.Format(helloText, Assembly.GetExecutingAssembly().CodeBase);
        }
    }
}

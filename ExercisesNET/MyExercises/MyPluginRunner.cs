using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Exercises;

namespace ExercisesNET.MyExercises
{
    public class PLuginTester
    {
        static void Main()
        {
            var pluginRunner = new MyPluginRunner();
            pluginRunner.Load();

            pluginRunner.Execute();

            Console.ReadLine();
        }
    }

    internal class MyPluginRunner
    {
        List<IPlugin> _plugins = new List<IPlugin>();

        public void Load()
        {
            var path = Directory.GetCurrentDirectory();
            foreach (var file in Directory.GetFiles(path, "*.dll"))
            {
                var asm = Assembly.LoadFrom(file);

                var plugins = asm.DefinedTypes
                    .Where(t => t.IsClass && t.ImplementedInterfaces.Contains(typeof(IPlugin)));

                foreach (var plugin in plugins)
                {
                    if (plugin != null && plugin.FullName is not null)
                    {
                        var instance = asm.CreateInstance(plugin.FullName);

                        if(instance != null)
                            _plugins.Add((IPlugin)instance);
                    }
                }
            }
        }

        public void Execute() 
        {
            foreach (var plugin in _plugins)
            {
                Console.WriteLine(plugin.GetText());
            }
        }
    }
}

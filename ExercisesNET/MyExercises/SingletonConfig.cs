using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Globalization;

namespace ExercisesNET.MyExercises
{
    public class SingletonConfig
    {
        private static SingletonConfig instance = new SingletonConfig();

        public CultureInfo Culture { get; set; }
        //


        //public SingletonConfig Instance => instance ;

        private SingletonConfig() { }

        public static SingletonConfig GetInstance()
        {
            //if(instance == null)
            //    instance = new SingletonConfig();

            return instance;
        }
    }
}

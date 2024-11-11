namespace AdvancedCSharp.Samples.Class
{
    public class Car
    {
        //Constant Field
        private const int ServiceCheckAfter = 10000;

        // Fields
        private readonly int _speed;

        // Constructor
        public Car(int avgSpeed)
        {
            //var car = new Car(100); initialization sample
            _speed = avgSpeed;
        }

        // Properties
        public int Distance { get; set; }


        // Methods
        public void Drive(int duration)
        {
            Distance = CalculateDistance(_speed, duration);
        }

        public bool IsServiceCheckNeeded()
        {
            return Distance > ServiceCheckAfter;
        }

        private static int CalculateDistance(int speed, int duration)
        {
            return speed * duration;
        }
    }

    public class ClassTest
    {
        public static void Main()
        {
            Car c1 = new Car(30);
            Car c2 = new Car(50);
            Car c3 = new Car(30);

            c1.Drive(10);

            var areEqual = c1 == c2; //false
            areEqual = c1 == c3; //false

            areEqual = c1.Equals(c2); //false
            areEqual = c1.Equals(c3); //false

            c1.Distance = 50;
            areEqual = c1.Equals(c2); //false
            areEqual = c1.Equals(c3); //false

            var copyCar = c1;
            areEqual = c1.Equals(copyCar); //true
            c1.Distance = 10;
            areEqual = c1.Equals(copyCar); //true

            ModifyClass(c1);
            areEqual = c1.Distance == 100; // true

            ModifyAndInitializeClass(c1);
            areEqual = c1.Distance == 200; // true
            areEqual = c1.Distance == 300; // false
        }

        public static void ModifyClass(Car localCar)
        {
            localCar.Distance = 100;
        }

        public static void ModifyAndInitializeClass(Car localCar)
        {
            localCar.Distance = 200;
            localCar = new Car(300);
        }
    }
}

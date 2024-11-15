using System;
namespace AdvancedCSharp.Samples.Patterns
{    

    internal class FactoryMethodPattern
    {
        static void Main(string[] args)
        {
            ICarFactory carFactory = new FordFactory(DateTime.Now.Year);

            Console.WriteLine("Car created is: {0}", carFactory.CreateCar(Model.Fiesta));
            Console.WriteLine("Car created is: {0}", carFactory.CreateCar(Model.Focus));
            Console.ReadKey();
        }
    }

    public enum Model
    {
        Mondeo,
        Focus,
        Fiesta
    }

    public interface ICar
    {
        string GetCarName();
    }
    public interface ICarFactory
    {
        ICar CreateCar(Model model);
    }

    public class FordFactory : ICarFactory
    {
        private const string Manufacturer = "Ford";
        private int _productionYear;
        public FordFactory(int year)
        {
            _productionYear = year;
        }

        public ICar CreateCar(Model model)
        {
            switch (model)
            {
                case Model.Mondeo:
                    return new Mondeo(Manufacturer, _productionYear);
                case Model.Focus:
                    return new Focus(Manufacturer, _productionYear);
                case Model.Fiesta:
                    return new Fiesta(Manufacturer, _productionYear);
                default:
                    throw new ArgumentOutOfRangeException(nameof(model), model, null);
            } 
        }
    }

    public abstract class Car : ICar
    {
        public string Manufacturer { get; private set; }
        public int ProductionYear { get; private set; }

        protected Car(string manufacturer, int productionYear)
        {
            Manufacturer = manufacturer;
            ProductionYear = productionYear;
        }

        public abstract string GetCarName();
    }

    public class Focus : Car
    {
        public Focus(string manufacturer, int productionYear) : base(manufacturer, productionYear)
        { }


        public override string GetCarName()
        {
            return "Focus";
        }
    }

    public class Fiesta : Car
    {
        public Fiesta(string manufacturer, int productionYear) : base(manufacturer, productionYear)
        { }

        public override string GetCarName()
        {
            return "Fiesta";
        }
    }

    public class Mondeo : Car
    {
        public Mondeo(string manufacturer, int productionYear) : base(manufacturer, productionYear)
        { }

        public override string GetCarName()
        {
            return "Mondeo";
        }
    }
}

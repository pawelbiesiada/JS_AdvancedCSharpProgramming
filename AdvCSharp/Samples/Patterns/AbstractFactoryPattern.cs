using System;
namespace AdvancedCSharp.Samples.Patterns
{
    internal class AbstractFactoryPattern
    {
        static void Main(string[] args)
        {
            IShapeFactory shapeFactory = new RegularShapeFactory();
            //shapeFactory = new SomeShapeFactory();

            Console.WriteLine("Elipsys is: {0}", shapeFactory.GetElipsys());
            Console.WriteLine("Quadrangle is: {0}", shapeFactory.GetQuadrangle());
            Console.WriteLine("Triangle is: {0}", shapeFactory.GetTriangle());
            Console.ReadKey();
        }
    }

    public interface IShape
    {
        string GetShapeName();
    }
    public interface IShapeFactory
    {
        IShape GetTriangle(); //Nie musi być taki sam interfejs 
        IShape GetQuadrangle();
        IShape GetElipsys();
    }

    public class RegularShapeFactory : IShapeFactory
    {
        public IShape GetElipsys()
        {
            return new Circle();
        }

        public IShape GetQuadrangle()
        {
            return new Square();
        }

        public IShape GetTriangle()
        {
            return new EquilateralTriangle();
        }
    }


    public class SomeShapeFactory : IShapeFactory
    {
        public IShape GetElipsys()
        {
            return new SomeElypsis();
        }

        public IShape GetQuadrangle()
        {
            return new SomeQuadrangle();
        }

        public IShape GetTriangle()
        {
            return new SomeTriangle();
        }
    }


    public class Square : IShape
    {
        public string GetShapeName()
        {
            return "Square";
        }
    }
    public class Circle : IShape
    {
        public string GetShapeName()
        {
            return "Circle";
        }
    }
    public class EquilateralTriangle : IShape
    {
        public string GetShapeName()
        {
            return "Equilateral triangle";
        }
    }

    public class SomeElypsis : IShape
    {
        public string GetShapeName()
        {
            return "SomeElypsis";
        }
    }
    public class SomeQuadrangle : IShape
    {
        public string GetShapeName()
        {
            return "SomeQuadrangle";
        }
    }
    public class SomeTriangle : IShape
    {
        public string GetShapeName()
        {
            return "SomeTriangle";
        }
    }
}

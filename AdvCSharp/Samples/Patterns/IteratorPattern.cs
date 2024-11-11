using System;
using System.Collections.Generic;

namespace AdvancedCSharp.Samples.Patterns
{
    internal class IteratorPattern
    {
        private static void Main()
        {
            IAggregate<string> a = new IteratorAggregate();
            a.Append("object A");
            a.Append("object B");
            a.Append("object C");
            a.Append("object D");

            IIterator<string> i = a.CreateIterator();
            Console.WriteLine("Iterating:");
            var item = i.First();
            Console.WriteLine(i.Next());
            var currItem = i.CurrentItem();
            Console.WriteLine("Current: {0}", currItem);
            while (item != null)
            {
                Console.WriteLine(item);
                item = i.Next();
            }
            Console.ReadKey();
        }
    }

    public interface IAggregate<T>
    {
        int Count { get; }
        IIterator<T> CreateIterator();
        void Append(T element);
        void Remove(T element);
    }

    public class IteratorAggregate : IAggregate<string>
    {
        private readonly List<string> _items = new List<string>();

        public IIterator<string> CreateIterator()
        {
            return new IteratorImpl(this);
        }

        public int Count => _items.Count;

        public void Append(string element)
        {
            _items.Add(element);
        }

        public void Remove(string element)
        {
            _items.Remove(element);
        }

        public string this[int i]
        {
            get => _items[i];
            set => _items.Insert(i, value);
        }
    }

    public interface IIterator<T>
    {
        T First();
        T Next();
        T CurrentItem();
    }
    
    public class IteratorImpl : IIterator<string>
    {
        private readonly IteratorAggregate _aggregate;
        private int _current = 0;

        public IteratorImpl(IteratorAggregate aggregate)
        {
            this._aggregate = aggregate;
        }

        public string First()
        {
            return _aggregate[0];
        }

        public string Next()
        {
            var ret = string.Empty;
            if (_current < _aggregate.Count - 1)
            {
                ret = _aggregate[++_current];
            }

            return ret;
        }
               
        public string CurrentItem()
        {
            return _aggregate[_current];
        }
    }
}
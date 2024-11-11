using System;
using System.Collections.Generic;

namespace AdvancedCSharp.Samples.Patterns
{
    class ObserverPattern
    {
        static void Main(string[] args)
        {
            var server = new ServerObserver();
            var gamer1 = new Gamer("John");
            server.Attach(gamer1);
            server.Attach(new Gamer("Mark"));
            server.SendMessageToAll("You started new game");
            server.Attach(new GameWatcher("Dirk"));
            server.Detach(gamer1);
            server.SendMessageToAll("Game over. Bye!");

            Console.ReadKey();
        }
    }
    
    class ServerObserver
    {
        private List<IGamer> _gamers;

        public ServerObserver()
        {
            _gamers = new List<IGamer>();
        }

        public void Attach(IGamer gamer)
        {
            if (!_gamers.Contains(gamer))
            {
                _gamers.Add(gamer);
                SendMessageToAll(string.Format("Player '{0}' joined the game.", gamer.Name));
            }
        }
        public void Detach(IGamer gamer)
        {
            if (_gamers.Contains(gamer))
            {
                _gamers.Remove(gamer);
                SendMessageToAll(string.Format("Player '{0}' left the game.", gamer.Name));
            }
        }

        public void DetachAll()
        {
            while (_gamers.Count > 0)
            {
                Detach(_gamers[0]);
            }
        }

        public void SendMessageToAll(string msg)
        {
            foreach (var gamer in _gamers)
            {
                gamer.ReceiveMessage(msg);
            }
        }
    }

    interface IGamer
    {
        string Name { get; }
        void ReceiveMessage(string msg);
    }

    class Gamer : IGamer
    {
        public string Name { get; private set; }

        public Gamer(string name)
        {
            Name = name;
        }

        public void ReceiveMessage(string msg)
        {
            Console.WriteLine($"Gamer {Name} has new message: {msg}");
        }
    }
    class GameWatcher : IGamer
    {
        public string Name { get; private set; }

        public GameWatcher(string name)
        {
            Name = name;
        }
        public void ReceiveMessage(string msg)
        {
            Console.WriteLine($"GameWatcher {Name} has new message: {msg}");
        }
    }
}

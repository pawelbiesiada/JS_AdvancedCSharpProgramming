using System;
using System.Transactions;

namespace AdvancedCSharp.Samples.Delegates
{
    class MessageEventArgs : EventArgs
    {
        public string Message{get; set;}

        public MessageEventArgs(string msg)
        {
            Message = msg;
        }
    }

    class EventsPresentation : IDisposable
    {
        public delegate void MessageEventHandler(object obj, MessageEventArgs eventArgs);

        public event MessageEventHandler PreAction;
        public event MessageEventHandler PostAction;

        public EventsPresentation()
        {
            PreAction += Print;
            PreAction += Print;

            PreAction += (o, e) => Console.WriteLine(o);

            PostAction += Print;
        }

        public void Dispose()
        {
            PreAction -= Print;
            PreAction -= Print;

            PreAction -= (o, e) => Console.WriteLine(o);


            foreach (var e in PreAction.GetInvocationList())
            {
                PreAction -= (MessageEventHandler)e;
            }
        }

        static void Main()
        {
            var ep = new EventsPresentation();
            ep.RunAction();

            Console.ReadKey();
        }

        public void RunAction()
        {
            PreAction(this, new MessageEventArgs("Pre - RunAction"));
            //Do action
            PostAction(this, new MessageEventArgs("Post - RunAction"));
        }

        private void Print(object obj, MessageEventArgs eventArgs)
        {


            var message = eventArgs.Message;

            Console.WriteLine(message);
        }
    }
}

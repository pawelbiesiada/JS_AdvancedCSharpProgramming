using System;

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

    class EventsPresentation
    {
        public delegate void MessageEventHandler(object obj, MessageEventArgs eventArgs);

        public event MessageEventHandler PreAction;
        public event MessageEventHandler PostAction;

        public EventsPresentation()
        {
            PreAction += Print;
            PreAction += Print;
            PostAction += Print;
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

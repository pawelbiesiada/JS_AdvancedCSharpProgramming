using System;
namespace AdvancedCSharp.Samples.Patterns
{
    class CommandPattern
    {
        static void Main(string[] args)
        {
            Editor editor = new Editor(); //invoker
            var document = new Document(); //receiver
            
            ICommand command = new Save(document);
            editor.SetCommand(command);
            editor.ExecuteCommand();

            command = new PasteText(document); //command
            editor.SetCommand(command);
            editor.ExecuteCommand("Some piece of text to be pasted");

            Console.ReadKey();
        }
    }
    interface ICommand
    {
        void Execute(object obj);
        void Execute();
    }

    class PasteText : ICommand
    {
        private readonly Document _receiver;

        public PasteText(Document receiver)
        {
            _receiver = receiver;
        }

        public void Execute()
        {
            _receiver.Action();
        }
        public void Execute(object obj)
        {
            _receiver.Text += obj;
        }
    }

    class Save : ICommand
    {
        private readonly Document _receiver;

        public Save(Document receiver)
        {
            _receiver = receiver;
        }

        public void Execute()
        {
            _receiver.Action();
        }
        public void Execute(object obj)
        {
            _receiver.Action(obj);
        }
    }

    class Document
    {
        public string Text { get; set; }
 
        public void Action(object objectState)
        {
            Console.WriteLine("Do something in Document with passed object:\n{0}", objectState);
        }

        public void Action()
        {
            Console.WriteLine("Called Document Action()");
        }
    }

    class Editor
    {
        private ICommand _command;
        // this could implmement list of actions and add a revert functionality

        public void SetCommand(ICommand command)
        {
            _command = command;
        }

        public void ExecuteCommand()
        {
            _command.Execute();
        }

        public void ExecuteCommand(object state)
        {
            _command.Execute(state);
        }
    }
}

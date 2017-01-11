using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.BehavioralPatterns.Command
{
    class CommandStructural
    {
        public static void Main(string[] args)
        {
            Receiver receiver = new Receiver();
            Command command = new ConcreteCommand(receiver);
            Invoker invoker = new Invoker();//çağırma, başvurma

            // Set and execute command
            invoker.SetCommand(command);
            invoker.ExecuteCommand();


            Console.ReadKey();
        }
    }

    class Receiver
    {
        public void Action()
        {
            Console.WriteLine("Called Receiver.Action()");
        }

    }

    abstract class Command
    {
        protected Receiver receiver;

        public Command(Receiver receiver)
        {
            this.receiver = receiver;
        }

        public abstract void Execute();
    }

    class ConcreteCommand : Command
    {
        public ConcreteCommand(Receiver receiver) : base(receiver)
        {
        }

        public override void Execute()
        {
            receiver.Action();
        }
    }

    class Invoker
    {
        private Command _command;

        public void SetCommand(Command command)
        {
            this._command = command;
        }

        public void ExecuteCommand()
        {
            _command.Execute();
        }
    }









}

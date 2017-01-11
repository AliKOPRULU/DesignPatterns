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
            Command command = new ConcreteCommandS(receiver);
            InvokerS InvokerS = new InvokerS();//çağırma, başvurma

            // Set and execute command
            InvokerS.SetCommand(command);
            InvokerS.ExecuteCommand();


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

    class ConcreteCommandS : Command
    {
        public ConcreteCommandS(Receiver receiver) : base(receiver)
        {
        }

        public override void Execute()
        {
            receiver.Action();
        }
    }

    class InvokerS
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

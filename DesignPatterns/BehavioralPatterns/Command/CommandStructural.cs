using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.BehavioralPatterns.CommandS
{
    class CommandSStructural
    {
        public static void Main(string[] args)
        {
            Receiver receiver = new Receiver();
            CommandS CommandS = new ConcreteCommandSS(receiver);
            InvokerS InvokerS = new InvokerS();//çağırma, başvurma

            // Set and execute CommandS
            InvokerS.SetCommandS(CommandS);
            InvokerS.ExecuteCommandS();


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

    abstract class CommandS
    {
        protected Receiver receiver;

        public CommandS(Receiver receiver)
        {
            this.receiver = receiver;
        }

        public abstract void Execute();
    }

    class ConcreteCommandSS : CommandS
    {
        public ConcreteCommandSS(Receiver receiver) : base(receiver)
        {
        }

        public override void Execute()
        {
            receiver.Action();
        }
    }

    class InvokerS
    {
        private CommandS _CommandS;

        public void SetCommandS(CommandS CommandS)
        {
            this._CommandS = CommandS;
        }

        public void ExecuteCommandS()
        {
            _CommandS.Execute();
        }
    }









}

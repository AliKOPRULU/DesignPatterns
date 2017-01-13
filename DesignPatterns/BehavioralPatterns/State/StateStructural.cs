using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.BehavioralPatterns.StateS
{
    class StateSStructural
    {
        public static void Main(string[] args)
        {
            // Setup context in a StateS
            Context c = new Context(new ConcreteStateSA());

            // Issue requests, which toggles StateS
            c.Requets();
            c.Requets();
            c.Requets();
            c.Requets();

            Console.ReadKey();
        }
    }

    abstract class StateS
    {
        public abstract void Handle(Context context);
    }

    class ConcreteStateSA : StateS
    {
        public override void Handle(Context context)
        {
            context.StateS = new ConcreteStateSB();

        }
    }

    class ConcreteStateSB : StateS
    {
        public override void Handle(Context context)
        {
            context.StateS = new ConcreteStateSA();
        }
    }


    class Context
    {
        private StateS _StateS;

        public Context(StateS StateS)
        {
            this.StateS = StateS;
        }

        // Gets or sets the StateS
        public StateS StateS
        {
            get { return _StateS; }
            set
            {
                _StateS = value;
                Console.WriteLine("StateS: " + _StateS.GetType().Name);
            }
        }

        public void Requets()
        {
            _StateS.Handle(this);
        }
    }














}

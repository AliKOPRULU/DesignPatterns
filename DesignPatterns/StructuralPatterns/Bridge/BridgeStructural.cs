using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.StructuralPatterns.Bridge
{
    class BridgeStructural
    {
        public static void Main(string[] args)
        {
            AbstractionS ab = new RefinedAbstractionS();

            // Set implementation and call
            ab.ImplementorS = new ConcreteImplementorSA();
            ab.Operation();

            // Change implemention and call
            ab.ImplementorS = new ConcreteImplementorSB();
            ab.Operation();


            Console.ReadKey();
        }
    }


    class AbstractionS
    {
        protected ImplementorS ImplementorS;

        // Property
        public ImplementorS ImplementorS
        {
            set { ImplementorS = value; }
        }

        public virtual void Operation()
        {
            ImplementorS.Operation();
        }
    }

    abstract class ImplementorS
    {
        public abstract void Operation();
    }

    class RefinedAbstractionS : AbstractionS
    {
        public override void Operation()
        {
            ImplementorS.Operation();
        }
    }

    class ConcreteImplementorSA : ImplementorS
    {
        public override void Operation()
        {
            Console.WriteLine("ConcreteImplementorSA Operation");
        }
    }

    class ConcreteImplementorSB : ImplementorS
    {
        public override void Operation()
        {
            Console.WriteLine("ConcreteImplementorSB Operation");
        }
    }




}

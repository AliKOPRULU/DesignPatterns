using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.StructuralPatterns.Decorator
{
    class DecoratorStructural
    {
        public static void Main(string[] args)
        {
            // Create ConcreteComponent and two Decorators
            ConcreteComponentD c = new ConcreteComponentD();
            ConcreteDecoratorA dA = new ConcreteDecoratorA();
            ConcreteDecoratorB dB = new ConcreteDecoratorB();

            // Link decorators
            dA.SetComponentD(c);
            dB.SetComponentD(dA);

            dB.Operation();

            Console.ReadKey();
        }
    }

    abstract class ComponentD
    {
        public abstract void Operation();
    }

    class ConcreteComponentD : ComponentD
    {
        public override void Operation()
        {
            Console.WriteLine("ConcreteComponent.Operation()"); ;
        }
    }

    class DecoratorD : ComponentD
    {
        protected ComponentD component;

        public void SetComponentD(ComponentD component)
        {
            this.component = component;
        }

        public override void Operation()
        {
            if (component!=null)
            {
                component.Operation();
            }
        }
    }

    class ConcreteDecoratorA : DecoratorD
    {
        public override void Operation()
        {
            base.Operation();
            Console.WriteLine("ConcreteDecoratorA.Operation()");
        }
    }

    class ConcreteDecoratorB : DecoratorD
    {
        public override void Operation()
        {
            base.Operation();
            AddedBehavior();
            Console.WriteLine("ConcreteDecoratorB.Operation()");
        }

        private void AddedBehavior()
        {
            throw new NotImplementedException();
        }
    }














}

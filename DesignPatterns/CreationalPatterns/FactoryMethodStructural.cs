using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.CreationalPatterns
{
    class FactoryMethodStructural
    {
        public static void Main(string[] args)
        {
            Creator[] creators = new Creator[2];

            creators[0] = new ConcreteCreatorA();
            creators[1] = new ConcreteCreatorB();

            foreach (Creator creator in creators)
            {
                FProduct product = creator.FactoryMethod();
                Console.WriteLine("Created {0}", product.GetType().Name);
            }

            Console.ReadKey();
        }



    }

    abstract class FProduct
    {

    }

    class ConcreteFProductA : FProduct
    {

    }

    class ConcreteFProductB : FProduct
    {

    }

    abstract class Creator
    {
        public abstract FProduct FactoryMethod();
    }

    class ConcreteCreatorA : Creator
    {
        public override FProduct FactoryMethod()
        {
            return new ConcreteFProductA();
        }
    }

    class ConcreteCreatorB : Creator
    {
        public override FProduct FactoryMethod()
        {

            return new ConcreteFProductB();

        }
    }
}

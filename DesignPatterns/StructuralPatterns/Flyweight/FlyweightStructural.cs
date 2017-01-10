using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.StructuralPatterns.FlyWeight
{
    class FlyweightStructural
    {
        public static void Main(string[] args)
        {
            // Arbitrary extrinsic state//Arbitrary:rastgele seçilmiş
            int extrinsincstate = 22;

            FlyweigtFactory factory = new FlyweigtFactory();

            // Work with different flyweight instances
            Flyweight fa = factory.GetFlyweight("A");
            fa.Operation(--extrinsincstate);

            Flyweight fb = factory.GetFlyweight("B");
            fb.Operation(--extrinsincstate);

            Flyweight fc = factory.GetFlyweight("C");
            fc.Operation(--extrinsincstate);

            UnSharedConcreteweight fu = new UnSharedConcreteweight();

            fu.Operation(--extrinsincstate);

            Console.ReadKey();
        }
    }


    abstract class Flyweight
    {
        public abstract void Operation(int extrinscstate);
    }

    class ConcreteFlyweight : Flyweight
    {
        public override void Operation(int extrinscstate)
        {
            Console.WriteLine("ConcreteFlyweigt: " + extrinscstate);
        }
    }

    class UnSharedConcreteweight : Flyweight
    {
        public override void Operation(int extrinscstate)
        {
            Console.WriteLine("UnSharedConcreteFlyweight" + extrinscstate);
        }
    }

    class FlyweigtFactory
    {
        private Hashtable flyweights = new Hashtable();

        public FlyweigtFactory()
        {
            flyweights.Add("A", new ConcreteFlyweight());
            flyweights.Add("B", new ConcreteFlyweight());
            flyweights.Add("C", new ConcreteFlyweight());
        }

        public Flyweight GetFlyweight(string key)
        {
            return (Flyweight)flyweights[key];
        }
    }















}

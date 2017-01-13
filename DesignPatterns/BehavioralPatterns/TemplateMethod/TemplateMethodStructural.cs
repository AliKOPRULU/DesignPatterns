using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.BehavioralPatterns.TemplateMethod
{
    class TemplateMethodStructural
    {
        public static void Main(string[] args)
        {
            AbstractClassS aA = new ConcreteClassA();
            aA.TemplateMethod();

            AbstractClassS aB = new ConcreteClassB();
            aB.TemplateMethod();





            Console.ReadKey();
        }
    }


    abstract class AbstractClassS
    {
        public abstract void PrimitiveOperation1();
        public abstract void PrimitiveOperation2();

        // The "Template method"
        public void TemplateMethod()
        {
            PrimitiveOperation1();
            PrimitiveOperation2();
            Console.WriteLine("");
        }
    }

    // A 'ConcreteClass' class
    class ConcreteClassA : AbstractClassS
    {
        public override void PrimitiveOperation1()
        {
            Console.WriteLine("ConcreteClassA.PrimitiveOperation1()");
        }

        public override void PrimitiveOperation2()
        {
            Console.WriteLine("ConcreteClassA.PrimitiveOperation2()");
        }
    }


    class ConcreteClassB : AbstractClassS
    {
        public override void PrimitiveOperation1()
        {
            Console.WriteLine("ConcreteClassB.PrimitiveOperation1()");
        }

        public override void PrimitiveOperation2()
        {
            Console.WriteLine("ConcreteClassB.PrimitiveOperation2()");
        }
    }















}

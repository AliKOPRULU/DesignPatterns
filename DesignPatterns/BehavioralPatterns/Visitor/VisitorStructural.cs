using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.BehavioralPatterns.Visitor
{
    class VisitorStructural
    {
        public static void Main(string[] args)
        {
            ObjectStructural o = new ObjectStructural();
            o.Attach(new ConcreteElementA());
            o.Attach(new ConcreteelementB());

            ConcreteVisitor1 v1 = new ConcreteVisitor1();
            ConcreteVisitor2 v2 = new ConcreteVisitor2();

            o.Accept(v1);
            o.Accept(v2);



            Console.ReadKey();
        }
    }

    abstract class VisitorS
    {
        public abstract void VisitConcreteElementA(ConcreteElementA concreteElementA);
        public abstract void VisitConcreteElementB(ConcreteelementB concreteElementB);
    }

    class ConcreteVisitor1 : VisitorS
    {
        public override void VisitConcreteElementA(ConcreteElementA concreteElementA)
        {
            Console.WriteLine("{0} visited by {1} ", concreteElementA.GetType().Name, this.GetType().Name);
        }

        public override void VisitConcreteElementB(ConcreteelementB concreteElementB)
        {
            Console.WriteLine("{0} visited by {1}", concreteElementB.GetType().Name, this.GetType().Name);
        }
    }

    class ConcreteVisitor2 : VisitorS
    {
        public override void VisitConcreteElementA(ConcreteElementA concreteElementA)
        {
            Console.WriteLine("{0} visited by {1} ", concreteElementA.GetType().Name, this.GetType().Name);
        }

        public override void VisitConcreteElementB(ConcreteelementB concreteElementB)
        {
            Console.WriteLine("{0} visited by {1}", concreteElementB.GetType().Name, this.GetType().Name);
        }
    }

    abstract class ElementS
    {
        public abstract void Accept(VisitorS visitor);
    }

    class ConcreteElementA : ElementS
    {
        public override void Accept(VisitorS visitor)
        {
            visitor.VisitConcreteElementA(this);
        }

        public void OperationA()
        {

        }
    }


    class ConcreteelementB : ElementS
    {
        public override void Accept(VisitorS visitor)
        {
            visitor.VisitConcreteElementB(this);
        }

        public void OperationB()
        {

        }
    }

    class ObjectStructural
    {
        private List<ElementS> _elements = new List<ElementS>();

        public void Attach(ElementS element)
        {
            _elements.Add(element);
        }

        public void Detach(ElementS element)
        {
            _elements.Remove(element);
        }

        public void Accept(VisitorS visitor)
        {
            foreach (ElementS element in _elements)
            {
                element.Accept(visitor);
            }
        }
    }

}

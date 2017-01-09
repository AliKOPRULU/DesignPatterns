using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.StructuralPatterns.Composite
{
    class CompositeElements
    {
        public static void Main(string[] args)
        {
            CompositeElement root = new CompositeElement("Picture");
            root.Add(new PrimitiveElement("Red Line"));
            root.Add(new PrimitiveElement("Blue Cicrle"));
            root.Add(new PrimitiveElement("Green Box"));

            //Create a branch
            CompositeElement comp = new CompositeElement("Two Circle");
            comp.Add(new PrimitiveElement("Black Circle"));
            comp.Add(new PrimitiveElement("White Circle"));
            root.Add(comp);

            //Add and remove a PrimitiveElement
            PrimitiveElement pe = new PrimitiveElement("Yellow Line");
            root.Add(pe);
            root.Remove(pe);

            root.Display(1);


            Console.ReadKey();
        }
    }

    // The 'Component' Treenode
    abstract class DrawingElement
    {
        protected string _name;

        public DrawingElement(string name)
        {
            this._name = name;
        }

        public abstract void Add(DrawingElement de);
        public abstract void Remove(DrawingElement de);
        public abstract void Display(int indent);
    }

    // The 'Leaf' class
    class PrimitiveElement : DrawingElement
    {
        public PrimitiveElement(string name) : base(name)
        {
        }

        public override void Add(DrawingElement d)
        {
            Console.WriteLine("Cannot add to a PrimitiveElement");
        }

        public override void Display(int indent)
        {
            Console.WriteLine(new String('-', indent) + " " + _name);
        }

        public override void Remove(DrawingElement d)
        {
            Console.WriteLine("Cannot remove from a PrimitiveElement");
        }
    }

    // The 'Composite' class
    class CompositeElement : DrawingElement
    {
        private List<DrawingElement> elements = new List<DrawingElement>();

        public CompositeElement(string name) : base(name)
        {
        }

        public override void Add(DrawingElement de)
        {
            elements.Add(de);
        }

        public override void Display(int indent)
        {
            Console.WriteLine(new String('-', indent) + "+ " + _name);

            // Display each child element on this node
            foreach (DrawingElement de in elements)
            {
                de.Display(indent + 2);
            }
        }

        public override void Remove(DrawingElement de)
        {
            elements.Remove(de);
        }
    }



}

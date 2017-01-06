using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.CreationalPatterns
{
    class PrototypeStructural
    {
        public static void Main(string[] args)
        {
            ConcretePrototpye1 p1 = new ConcretePrototpye1("I");
            ConcretePrototpye1 c1 = (ConcretePrototpye1)p1.Clone();
            Console.WriteLine("Cloned: {0} ", c1.Id);

            ConcretePrototype2 p2 = new ConcretePrototype2("II");
            ConcretePrototype2 c2 = (ConcretePrototype2)p2.Clone();
            Console.WriteLine("Cloned: {0} ", c2.Id);
            
            Console.ReadKey();
        }
    }

    abstract class Prototype
    {
        private string _id;

        public Prototype(string id)// Constructor
        {
            this._id = id;
        }

        public string Id// Gets id
        {
            get { return _id; }
        }
        public abstract Prototype Clone();
    }


    class ConcretePrototpye1 : Prototype
    {
        public ConcretePrototpye1(string id) : base(id)
        {
        }

        // Returns a shallow copy //shallow:Yüzeysel, yolunu gösterme
        public override Prototype Clone()
        {
            return (Prototype)this.MemberwiseClone();
        }
    }

    class ConcretePrototype2 : Prototype
    {
        public ConcretePrototype2(string id) : base(id)
        {
        }

        public override Prototype Clone()
        {
            return (Prototype)this.MemberwiseClone();
        }
    }






}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.StructuralPatterns.Decorator
{
    class DecoratorTopcuBataryasi
    {//http://www.buraksenyurt.com/post/Tasarc4b1m-Desenleri-Decorator.aspx
        public static void Main(string[] args)
        {
            // Bileşen örneklenir
            Artillery topcu = new Artillery(125,40,"Fırtına A1");
            topcu.Fire();

            // Decorator nesnesi örneklenir
            ArtilleryDecorator topcuDecorator = new ArtilleryDecorator(topcu);

            // Decorator nesnesi üzerinden o anki asıl Component için(Artillery sınıfı) ek fonksiyonellikler çağırılır.
            topcuDecorator.Defense();
            topcuDecorator.Fire();
            topcuDecorator.Easy();
            topcuDecorator.Fire();

            Console.ReadKey();
        }
    }

    // Component
    abstract class Arms
    {
        public string Name;
        public abstract void Fire();
    }

    // ConcreteComponent
    class Artillery : Arms
    {
        protected double _barret;
        protected double _range;

        public Artillery(double barret, double range, string name)
        {
            this.Name = name;
            this._barret = barret;
            this._range = range;
        }

        public override void Fire()
        {
            Console.WriteLine("{0} sınıfından olan topçu, {1} mm namlusundan {2} mesafeye ateşleme yaptı", Name, _barret.ToString(), _range.ToString());
        }
    }

    // Decorator
    abstract class ArmsDecorator : Arms
    {
        protected Arms _arms;
        public ArmsDecorator(Arms arms)
        {
            this._arms = arms;
        }

        public override void Fire()
        {
            if (_arms != null)
            {
                _arms.Fire();
            }
        }
    }

    // ConcreteDecorator
    class ArtilleryDecorator : ArmsDecorator
    {
        public ArtilleryDecorator(Arms arms) : base(arms)
        {
        }

        public void Defense()
        {
            Console.WriteLine("\t{0} Savunma Modu!", base._arms.Name);
        }

        public void Easy()
        {
            Console.WriteLine("\t{0} Atış serbest modu!", _arms.Name);
        }

        public override void Fire()
        {
            base.Fire();
        }
    }

















}

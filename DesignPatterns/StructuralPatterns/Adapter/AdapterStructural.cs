using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.StructuralPatterns.AdapterS
{
    class AdapterSStructural
    {
        public static void Main(string[] args)
        {
            TargetS TargetS = new AdapterS();
            TargetS.Request();

            Console.ReadKey();
        }
    }

    class TargetS
    {
        public virtual void Request()
        {
            Console.WriteLine("Called TargetS Request()");
        }
    }

    class AdapterS : TargetS
    {
        private AdapteeS _AdapteeS = new AdapteeS();
        public override void Request()
        {
            // Possibly do some other work and then call SpecificRequest            
            _AdapteeS.SpecificRequest();
        }
    }

    class AdapteeS
    {
        public void SpecificRequest()
        {
            Console.WriteLine("Called SpecificRequest()");
        }
    }





}

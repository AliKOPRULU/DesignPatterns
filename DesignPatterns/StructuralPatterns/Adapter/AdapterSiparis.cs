using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.StructuralPatterns.Adapter
{
    class AdapterSiparis
    {
        public static void Main(string[] args)
        {
            Target target = new Target();
            target.Siparis();

            Console.ReadKey();
        }
    }

    //bir Müzik mağazamız var ve sadece enstruman olarak gitar satışı yapıyoruz.
    class Target
    {
        public virtual void Siparis()
        {
            Console.WriteLine("Gitar Siparişi başarı ile verilmiştir...");
        }
    }

    // Ancak sonradan mağazamızda yeni bir enstruman satmaya karar verdik.
    class Adaptee
    {
        public void KemenceSiparis()
        {
            Console.WriteLine("Kemençe Siparişi başarı ile verilmiştir");
        }
    }

    // İşte bu noktada sadece gitar siparişi verebildiğimiz classımıza Kemence siparişimizi
    // de adapte ediyoruz.Bu yüzden Target classını
    class Adapter : Target
    {
        private Adaptee _adaptee = new Adaptee();

        public override void Siparis()
        {
            _adaptee.KemenceSiparis();
        }
    }


}

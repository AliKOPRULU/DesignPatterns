using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.CreationalPatterns
{
    public class AbstractFactoryCar
    {
        abstract class SoyutArabaFabrikasi
        {
            abstract public SoyutArabaKasasi KasaUret();
            abstract public SoyutArabaLastigi LastikUret();
        }

        class ToyotaFabrikasi : SoyutArabaFabrikasi
        {
            public override SoyutArabaKasasi KasaUret()
            {
                return new ToyotaCorolla();
            }

            public override SoyutArabaLastigi LastikUret()
            {
                return new ToyotaLastik();
            }
        }

        class HondaFabrikası : SoyutArabaFabrikasi
        {
            public override SoyutArabaKasasi KasaUret()
            {
                return new HondaCivic();
            }

            public override SoyutArabaLastigi LastikUret()
            {
                return new HondaLastik();
            }
        }
        
        abstract class SoyutArabaKasasi
        {
            abstract public void LastikTak(SoyutArabaLastigi a);
        }

        abstract class SoyutArabaLastigi
        {

        }

        class ToyotaCorolla : SoyutArabaKasasi
        {
            public override void LastikTak(SoyutArabaLastigi lastik)
            {
                Console.WriteLine(lastik + "Lastikli Corolla");
            }
        }

        class HondaCivic : SoyutArabaKasasi
        {
            public override void LastikTak(SoyutArabaLastigi lastik)
            {
                Console.WriteLine(lastik + "Lastikli Civic");
            }
        }

        class ToyotaLastik : SoyutArabaLastigi
        {

        }

        class HondaLastik : SoyutArabaLastigi
        {

        }

        class FabrikaOtomasyon
        {
            private SoyutArabaKasasi ArabaKasasi;
            private SoyutArabaLastigi ArabaLastigi;

            public FabrikaOtomasyon(SoyutArabaFabrikasi fabrika)
            {
                ArabaKasasi = fabrika.KasaUret();
                ArabaLastigi = fabrika.LastikUret();
            }

            public void LastikTak()
            {
                ArabaKasasi.LastikTak(ArabaLastigi);
            }
        }

        class UretimBandi
        {
            static void Main(string[] args)
            {
                SoyutArabaFabrikasi fabrika1 = new ToyotaFabrikasi();
                FabrikaOtomasyon fo1 = new FabrikaOtomasyon(fabrika1);
                fo1.LastikTak();

                SoyutArabaFabrikasi fabrika2 = new HondaFabrikası();
                FabrikaOtomasyon fo2 = new FabrikaOtomasyon(fabrika2);
                fo2.LastikTak();

                Console.WriteLine("çalıştı");
            }
        }

    }
}

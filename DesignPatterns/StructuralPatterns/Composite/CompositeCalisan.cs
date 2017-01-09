using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.StructuralPatterns.Composite
{
    class CompositeDesingCalisan
    {//http://harunozer.com/makale/composite_tasarim_deseni__composite_design_pattern.htm
        public static void Main(string[] args)
        {
            //İlk olarak Root Composite
            CompositeCalisan GenelMudur = new CompositeCalisan("Ali", enPozisyon.GenelMudur);

            //Genel müdürün altında çalışan diğer çalışanları hiyerarşik olarak ekliyoruz
            //Altında eleman olmayan çalışanlar LeafCalisan sınıfı ile ifade edilir.
            CompositeCalisan Mudur = new CompositeCalisan("Ahmet", enPozisyon.Mudur);
            Mudur.Ekle(new LeafCalisan("Mehmet", enPozisyon.Isci));
            Mudur.Ekle(new LeafCalisan("Ayşe", enPozisyon.DepartmanSorumlusu));

            //Root komposite altındaki Composite yi ekliyoruz.
            GenelMudur.Ekle(Mudur);

            GenelMudur.Goster();

            Console.ReadKey();
        }
    }

    //yardımcı enum
    enum enPozisyon
    {
        GenelMudur = 1,
        Mudur = 2,
        DepartmanSorumlusu = 3,
        Isci = 4
    }

    //component(Bileşen) yapısı
    abstract class Calisan
    {
        protected string Ad;
        protected enPozisyon Pozisyon;

        public Calisan(string Ad, enPozisyon Pozisyon)
        {
            this.Ad = Ad;
            this.Pozisyon = Pozisyon;
        }

        public abstract void Goster();//Leaf ve Composite de uygulanacak metot
    }

    //Leaf yapısı
    class LeafCalisan : Calisan
    {
        public LeafCalisan(string Ad, enPozisyon Pozisyon) : base(Ad, Pozisyon)
        {
        }

        public override void Goster()
        {
            Console.WriteLine("{0} - {1}", base.Pozisyon.ToString(), base.Ad);
        }
    }

    //Composite  yapısı
    class CompositeCalisan : Calisan
    {
        List<Calisan> Calisanlari;
        public CompositeCalisan(string Ad, enPozisyon Pozisyon) : base(Ad, Pozisyon)
        {
            Calisanlari = new List<Calisan>();
        }

        public void Ekle(Calisan c)
        {
            Calisanlari.Add(c);
        }

        public void Sil(Calisan c)
        {
            Calisanlari.Remove(c);
        }

        public override void Goster()
        {
            Console.WriteLine("{0} - {1}", base.Pozisyon.ToString(), base.Ad);
            foreach (Calisan item in Calisanlari)
            {
                item.Goster();
            }
        }
    }
















}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.StructuralPatterns.Bridge
{
    class BridgeKargo
    {
        public static void Main(string[] args)
        {
            KargoGonder kargo = new KargoGonder();
            kargo.Kargo = new PesinOdemeliGonderim();
            kargo.Aciklama = "Peşin ödemeli";
            kargo.Alici = "Ali KÖPRÜLÜ";
            kargo.Gonderen = "Murat ÖDÜNÇ";
            kargo.Fiyat = 5;
            kargo.Gonder();

            KargoGonder kargo2 = new KargoGonder();
            kargo.Kargo = new KarsiOdemeliGonderim();
            kargo.Aciklama = "Karşı ödemeli";
            kargo.Alici = "Alper KÖPRÜLÜ";
            kargo.Gonderen = "www.alikoprulu.com.tr";
            kargo.Fiyat = 105;
            kargo.Gonder();

            //Refined
            AnlasmaliKargoGonderimi kargo3 = new AnlasmaliKargoGonderimi();
            kargo3.Kargo = new PesinOdemeliGonderim();
            kargo3.Aciklama = "Anlaşmalı ödemeli";
            kargo3.Alici = "Abil Alper KÖPRÜLÜ";
            kargo3.Gonderen = "www.alikoprulu.com.tr";
            kargo3.Gonder();

            Console.ReadKey();
        }
    }


    public interface IKargo
    {
        void KargoGonder(string Gonderen, string Alici, decimal Fiyat, string Aciklama);
    }

    //Concrete1
    class KarsiOdemeliGonderim : IKargo
    {
        public void KargoGonder(string Gonderen, string Alici, decimal Fiyat, string Aciklama)
        {
            Console.WriteLine(Aciklama + Environment.NewLine + "Gönderen : " + Gonderen + Environment.NewLine + "Alıcı : " + Alici + Environment.NewLine + "Ücret :" + Fiyat.ToString() + "\n");
        }
    }

    //Concrete2
    class PesinOdemeliGonderim : IKargo
    {
        public void KargoGonder(string Gonderen, string Alici, decimal Fiyat, string Aciklama)
        {
            Console.WriteLine(Aciklama + Environment.NewLine + "Gönderen : " + Gonderen + Environment.NewLine + "Alıcı : " + Alici + Environment.NewLine + "Ücret :" + Fiyat.ToString() + "\n");
        }
    }

    //Abstraction yani Köprü görevini üstlenen nesnemiz
    public class KargoGonder
    {
        public IKargo Kargo;
        public string Aciklama;
        public string Gonderen;
        public string Alici;
        public decimal Fiyat;
        public virtual void Gonder()
        {
            Kargo.KargoGonder(Gonderen, Alici, Fiyat, Aciklama);
        }
    }

    //Refined abstraction, abstraction arayüzünü uygulayan sınıf.
    //Sonradan ekledğim yeni özelliğim.

    public class AnlasmaliKargoGonderimi : KargoGonder
    {
        public decimal anlasmaliFiyat = 8 - (8 * 25 / 100);

        public override void Gonder()
        {
            Kargo.KargoGonder(Gonderen, Alici, anlasmaliFiyat, Aciklama);
        }
    }

    
}

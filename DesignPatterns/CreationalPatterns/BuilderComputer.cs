using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.CreationalPatterns
{
    class BuilderComputer
    {
        static void Main(string[] args)
        {
            TeknikServis teknikServis = new TeknikServis();
            IBilgisayarToplayicisi BT1 = new GoldPc();
            IBilgisayarToplayicisi BT2 = new SilverPc();
            teknikServis.BilgisayarTopla(BT1);
            teknikServis.BilgisayarTopla(BT2);

            BT1.Bilgisayar.BilgisayarGoster();
            Console.WriteLine("------------");
            BT2.Bilgisayar.BilgisayarGoster();
            Console.ReadKey();
        }
    }

    public interface IBilgisayarToplayicisi
    {
        Bilgisayar Bilgisayar { get; }

        void Kasa_Olustur();
        void SSD_Olustur();
        void Monitor_Olustur();
        void Ram_Olustur();
    }

    public class GoldPc : IBilgisayarToplayicisi
    {
        private Bilgisayar mBilgisayar;

        public Bilgisayar Bilgisayar
        {
            get
            {
                return mBilgisayar;
            }
        }

        public GoldPc()
        {
            mBilgisayar = new Bilgisayar("Gold-PC");
        }

        public void Kasa_Olustur()
        {
            mBilgisayar["kasa"] = "Corsair";
        }

        public void Monitor_Olustur()
        {
            mBilgisayar["ekran"] = "AOC";
        }

        public void Ram_Olustur()
        {
            mBilgisayar["ram"] = "Corsair";
        }

        public void SSD_Olustur()
        {
            mBilgisayar["ssd"] = "Samsung";
        }
    }

    public class SilverPc : IBilgisayarToplayicisi
    {
        private Bilgisayar mBilgisayar;

        public Bilgisayar Bilgisayar
        {
            get
            {
                return mBilgisayar;
            }
        }

        public SilverPc()
        {
            mBilgisayar = new Bilgisayar("Silver-PC");
        }

        public void Kasa_Olustur()
        {
            mBilgisayar["kasa"] = "Dark";
        }

        public void Monitor_Olustur()
        {
            mBilgisayar["ekran"] = "Philips";
        }

        public void Ram_Olustur()
        {
            mBilgisayar["ram"] = "Dark";
        }

        public void SSD_Olustur()
        {
            mBilgisayar["ssd"] = "Corsair";
        }
    }

    public class Bilgisayar
    {
        private string mBilgisayarTipi;
        private Hashtable mParcalar = new Hashtable();

        public Bilgisayar(string mBilgisayarTipi)
        {
            this.mBilgisayarTipi = mBilgisayarTipi;
        }

        public object this[string key]
        {
            get
            {
                return mParcalar[key];
            }
            set
            {
                mParcalar[key] = value;
            }
        }

        public void BilgisayarGoster()
        {
            Console.WriteLine("Bilgisayar Tipi : " + mBilgisayarTipi);
            Console.WriteLine("---> Kasa Model : " + mParcalar["kasa"]);
            Console.WriteLine("---> SSD Model : " + mParcalar["ssd"]);
            Console.WriteLine("---> Ekran Model : " + mParcalar["ekran"]);
            Console.WriteLine("---> RAM Model : " + mParcalar["ram"]);
        }
    }

    public class TeknikServis
    {
        public void BilgisayarTopla(IBilgisayarToplayicisi bilgisayarToplayicisi)
        {
            bilgisayarToplayicisi.Kasa_Olustur();
            bilgisayarToplayicisi.Monitor_Olustur();
            bilgisayarToplayicisi.SSD_Olustur();
            bilgisayarToplayicisi.Ram_Olustur();
        }
    }
}

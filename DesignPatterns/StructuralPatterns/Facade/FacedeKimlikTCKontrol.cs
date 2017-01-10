using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.StructuralPatterns.Facade
{
    class FacedeKimlikTCKontrol
    {//http://harunozer.com/makale/facade_tasarim_deseni__facade_design_pattern.htm
        public static void Main(string[] args)
        {
            Facede f = new Facede();
            f.Sistem2UyeEkle("1321654622");
            

            Console.ReadKey();
        }
    }


    public class sistem1Kontrol
    {
        public bool KaralisteKontrol(string TC)
        {
            Console.WriteLine("Kontrol edildi vaysayalım");
            return false;
        }
    }

    public class Sistem20Operations
    {
        public void UyeEkle(string TC)
        {
            Console.WriteLine("{0}Üye Eklendi", TC);
        }
    }

    public class TCKimlikSiste
    {
        public bool Kontrol(string TC)
        {
            //kontrol edildiğini varsayalım
            return true;
        }
    }

    public class Facede
    {
        //constructor da oluşturulabilir
        //singleton olarak tasarlanabilir
        TCKimlikSiste TCSistem = new TCKimlikSiste();
        sistem1Kontrol Sistem1 = new sistem1Kontrol();
        Sistem20Operations Sistem2 = new Sistem20Operations();

        public void Sistem2UyeEkle(string TC)
        {
            if (TCSistem.Kontrol(TC) && !Sistem1.KaralisteKontrol(TC))
            {
                Sistem2.UyeEkle(TC);
            }
        }
    }













}

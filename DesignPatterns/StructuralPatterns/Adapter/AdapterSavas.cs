using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.StructuralPatterns.Adapter
{
    class AdapterSavas
    {//http://www.rehabayar.net/?p=150
        public static void Main(string[] args)
        {
            Console.WriteLine("Düşman tankı");
            Console.WriteLine();

            DusmanTanki x11 = new DusmanTanki();
            x11.Silah();
            x11.SurucuIsmi("Ali");
            x11.AracSurusHizi();

            Console.WriteLine();
            Console.WriteLine("Robot");
            Console.WriteLine();

            DusmanRobotu robot215 = new DusmanRobotu();
            robot215.KontrolEden("Alper");
            robot215.Yumruk();
            robot215.Yurume();

            Console.WriteLine();
            Console.WriteLine("Düşman Robotu");
            Console.WriteLine();

            // Robotumuzu bu şekilde tanımlıyoruz ve yeni robotumuzun da türü IDusman.
            IDusman dusman = new DusmanRobotuAdapter(robot215);
            dusman.Silah();
            dusman.SurucuIsmi("Murat");
            dusman.AracSurusHizi();

            Console.ReadKey();
        }
    }

    //  1- Adaptee : Mevcut sisteme uydurulmak istenen nesne. 
    //  2- Adapter: Mevcut sisteme uydurma işlemini yapan nesne. 
    //  3- Target: İstemcinin ihtiyaç duyduğu interface.
    //  4- Client: İşlemleri gerçekleştirdiğimiz ortak sınıf. İstemci , uygulama. 

    //  Karşılıklı savaş yapılabilecek bir oyun tasarlayacağız.
    //  Oyunumuzda kullanacağımız düşmanlar genelde araçlardan oluşmaktadır ve düşmanların tahmini
    //  metodları interface'imizde tanımlanmıştır.
    public interface IDusman// Target
    {
        void Silah();// Aracın üstünde bulunan herhangi bir silah
        void AracSurusHizi();
        void SurucuIsmi(string isim);// Aracı kullanan kişinin ismi
    }

    // Tanımladığımız interface'i oyunumuzda kullanacağımız tank'a implement ediyoruz 

    public class DusmanTanki : IDusman
    {
        Random RandomSayi = new Random();

        public void AracSurusHizi()
        {
            int aracHizi = RandomSayi.Next(40) + 1;
            string hiz = Convert.ToString(aracHizi);
            Console.WriteLine("Tank  " + hiz + " km " + " hizla gitmektedir.");
        }

        public void Silah()
        {
            int silahHasari = RandomSayi.Next(20) + 1;
            string hasar = Convert.ToString(silahHasari);
            Console.WriteLine("Tank  " + hasar + " hasar vermiştir.");
        }

        public void SurucuIsmi(string isim)
        {
            Console.WriteLine("Tankı " + isim + " kullanmaktadır.");
        }
    }

    //  Tankımız tamamlandı.Tanımladığımız tank oyunumuzda istediğimiz şekilde çalışıyor.
    //  Ancak oyunumuza ilerleyen zamanlarda bir robot eklemek istedik ve robot tankın kullandığı
    //  metodlardan farklı işlevlere sahip.Ancak ekleyeceğimiz yeni robot da aynı zamanda
    //  bir düşman.Yani yine Dusman interface'ini kullanmak istiyoruz.İşte bu noktada
    //  Structural (Yapısal) bir tasarım deseni olan "Adapter" i kullanıyoruz.

    public class DusmanRobotu//Adaptee
    {
        Random randomSayi = new Random();

        public void Yumruk()
        {
            int yumrukHasari = randomSayi.Next(40) + 1;
            string hasar = Convert.ToString(yumrukHasari);
            Console.WriteLine("Robot yumruk atarak  " + hasar + " hasar vermiştir.");
        }

        public void Yurume()
        {
            int robotHizi = randomSayi.Next(20) + 1;
            string hiz = Convert.ToString(robotHizi);
            Console.WriteLine("Robotun hizi  " + hiz + " km'dir.");
        }

        public void KontrolEden(string kullanici)
        {
            Console.WriteLine("Robot  " + kullanici + " tarafından yönetilmektedir.");
        }
    }

    public class DusmanRobotuAdapter : IDusman
    {
        DusmanRobotu robot;

        // İlk olarak Constructor metod yazılır.Bunun nedeni ise yeni yaratacağımız robotun IDusmandan türünde olmasını istiyor olmamızdır.
        public DusmanRobotuAdapter(DusmanRobotu yeniRobot)
        {
            this.robot = yeniRobot;
        }

        public void AracSurusHizi()
        {
            robot.Yurume();
        }

        public void Silah()
        {
            robot.Yumruk();
        }

        public void SurucuIsmi(string isim)
        {
            robot.KontrolEden(isim);
        }
    }







}

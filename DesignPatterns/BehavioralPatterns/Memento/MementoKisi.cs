using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.BehavioralPatterns.Memento
{
    class MementoKisi
    {
        public static void Main(string[] args)
        {
            //bazı özelliklerinin yedeği tutulacak olan Originator sınıfı oluşturuyoruz.
            Kisi k = new Kisi
            {
                Ad = "Ali",
                Soyad = "KÖPRÜLÜ",
                Yas = 97
            };
            Console.WriteLine(k.Ad);
            //Originator sınıfının özelliklerini Memento olarak saklayacak Caretaker sınıfını oluşturuyoruz.
            //Oluşturduğumuz Originator sınıfının özelliklerini Memento cinsinden elde edip saklıyoruz.
            KisiMemory km = new KisiMemory();
            km.KisiKopya = k.CreateMomento();

            //kopyası alındıktan sonra Originator sınıfının özelliğini değiştiriyoruz
            k.Ad = "Mehmet";
            Console.WriteLine(k.Ad);
            //sakladığımız kopyayı Originator sınıfına yükleyip nesneyi eski haline getiriyoruz.
            k.BindMemento(km.KisiKopya);
            Console.WriteLine(k.Ad);

            Console.ReadKey();
        }
    }

    //Originator
    //Tamamının veya bazı özelliklerinin kopyasının alınacağı sınıf
    class Kisi
    {
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public int Yas { get; set; }

        public KisiMomento CreateMomento()
        {
            return new KisiMomento
            {
                Ad = this.Ad,
                Soyad = this.Soyad,
                Yas = this.Yas
            };
        }

        public void BindMemento(KisiMomento kisi)
        {
            this.Ad = kisi.Ad;
            this.Soyad = kisi.Soyad;
            this.Yas = kisi.Yas;
        }
    }

    //Memento:Hatıra
    //Originator nesnesinin kopyasının tutulacağı özelliklerin tanımlı olduğu sınıf
    class KisiMomento
    {
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public int Yas { get; set; }
    }

    //Caretaker
    //kopyası tutulacak Memento sınıfının tutulacağı sınıf
    class KisiMemory
    {
        public KisiMomento KisiKopya { get; set; }
    }











}

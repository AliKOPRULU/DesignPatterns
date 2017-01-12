using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.BehavioralPatterns.Observer
{
    class ObserverUrun
    {
        public static void Main(string[] args)
        {
            //İlk olarak Subject nesnemizi oluşturuyoruz.
            absUrun Kitap = new Urun("Kitap", 10.25M);
            //Subject nesnemiz ile ilgili olan Uye (observer) listesine nesne ekliyoruz.
            Kitap.Takiplist.Add(new Uye { E_Mail = "a@a.com" });
            Kitap.Takiplist.Add(new Uye { E_Mail = "b@b.com" });
            //Subject yani ürün fiyatını değiştirdiğimizde listedeki
            //observer nesnelerinin ilgili metodu çalıştırılacak
            Kitap.Fiyat = 8.99M;


            Console.ReadKey();
        }
    }

    //Subject
    abstract class absUrun
    {
        public string UrunAdi { get; set; }
        private decimal _Fiyat;

        /*Direkt erişim yerine private tanımlanıp, tanımlanacak metotlar ile yapılabilir.*/
        //Observer nesne listesi
        public List<IUye> Takiplist = new List<IUye>();

        public absUrun(string UrunAdi, decimal UrunFiyat)
        {
            this.UrunAdi = UrunAdi;
            this._Fiyat = UrunFiyat;
        }

        public decimal Fiyat
        {
            get { return _Fiyat; }
            set
            {
                //fiaytı düşmüş ise üyelere haber ver
                if (_Fiyat > value)
                {
                    NotifyUrun();
                    _Fiyat = value;
                }
            }
        }

        public void NotifyUrun()
        {
            foreach (IUye item in Takiplist)
            {
                item.Update(this);
            }
        }

    }

    //ConcreteSubject
    class Urun : absUrun
    {
        public Urun(string UrunAdi, decimal UrunFiyat) : base(UrunAdi, UrunFiyat)
        {
        }
    }

    //Observer
    interface IUye
    {
        void Update(absUrun u);
    }

    //ConcreteObserver
    class Uye : IUye
    {
        public string E_Mail { get; set; }
        public void Update(absUrun u)
        {
            Console.WriteLine("{0} ın fiyatı {1} oldu {2} adresine gönderildi.", u.UrunAdi, u.Fiyat.ToString("C2"), E_Mail);
        }
    }



}

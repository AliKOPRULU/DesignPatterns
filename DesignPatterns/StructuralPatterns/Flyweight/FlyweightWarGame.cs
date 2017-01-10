using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.StructuralPatterns.Flyweight
{
    class FlyweightWarGame
    {
        public static void Main(string[] args)
        {
            // İstemci için örnek bir FlyWeight nesne örneği dizisi oluşturulur
            SoldierType[] soldiers = { SoldierType.Private, SoldierType.Private, SoldierType.Sergeant, SoldierType.Private, SoldierType.Sergeant };

            SoldierFactory factory = new SoldierFactory();

            // Extrinsic değerler set edilir
            int localtionX = 10;
            int locationY = 10;

            foreach (SoldierType soldier in soldiers)
            {
                localtionX += 10;
                locationY += 5;
                // O anki Soldier tipi için MoveTo operasyonu çağırılmadan önce fabrika nesnesinden tedarik edilir
                Soldier sld = factory.GetSoldier(soldier);
                // FlyWeight nesnesi üzerinden talep edilen operasyon çağrısı gerçekleştirilir
                sld.MoveTo(localtionX, locationY);
            }

            Console.ReadKey();
        }
    }

    enum SoldierType
    {
        Private,
        Sergeant
    }

    abstract class Soldier
    {
        // Bütün FlyWeight nesne örnekleri tarafından ortak olan ve paylaşılan veriler
        protected string UnitName;
        protected string Guns;
        protected string Health;

        // İstemci tarafından değerlendirilip hesaplanan ve MoveTo operasyonua gönderilerek FlyWeight nesne örnekleri tarafından değerlendirilen veriler
        protected int X;
        protected int Y;

        public abstract void MoveTo(int x, int y);
    }

    // Concrete FlyWeight
    class Private : Soldier
    {
        public Private()
        {
            // Intrinsict değerler set edilir
            UnitName = "Swat";
            Guns = "Machine Gun";
            Health = "Good";
        }

        public override void MoveTo(int x, int y)
        {
            // Extrinsic değerler set edilir ve bir işlem gerçekleştirilir
            X = x;
            Y = y;
            Console.WriteLine("Er ({0}:{1}) noktasına hareket etti", X, Y);
        }
    }

    // Concrete FlyWeight
    class Sergeant : Soldier
    {
        public Sergeant()
        {
            UnitName = "SWAT";
            Guns = "Sword";
            Health = "Good";
        }

        public override void MoveTo(int x, int y)
        {
            X = x;
            Y = y;
            Console.WriteLine("Çavuş ({0}:{1}) noktasına hareket etti", X, Y);
        }
    }

    // FlyWeight Factory
    class SoldierFactory
    {
        // Depolama alanı(Havuz).
        // Uygulama ortamında tekrar edecek olan FlyWeight nesne örnekleri depolama alanında basit birer Key ile ifade edilir
        private Dictionary<SoldierType, Soldier> _soldiers;

        public SoldierFactory()
        {
            _soldiers = new Dictionary<SoldierType, Soldier>();
        }

        public Soldier GetSoldier(SoldierType sType)
        {
            Soldier soldier = null;

            // Eğer depolama alanında, parametre olarak gelen Key ile eşleşen bir FlyWeight nesnesi var ise onu çek
            if (_soldiers.ContainsKey(sType))
            {
                soldier = _soldiers[sType];
            }
            else// Yoksa Key tipine bakarak uygun FlyWeight nesne örneğini oluştur ve depolama alanına(havuz) ekle
            {
                if (sType == SoldierType.Private)
                {
                    soldier = new Private();
                }
                else if (sType == SoldierType.Sergeant)
                {
                    soldier = new Sergeant();
                }
                _soldiers.Add(sType, soldier);
            }
            return soldier;
        }
    }











}

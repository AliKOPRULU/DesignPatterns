using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.BehavioralPatterns.Command
{
    class CommandPerson
    {
        public static void Main(string[] args)
        {
            Kisi kisi = new Kisi { Id = 1, Ad = "Ali" };

            ReceiverKisi rk1 = new ReceiverKisi(kisi);

            CommandKisi ckAdd = new ConcreteCommandKisiEkle(rk1);
            CommandKisi ckSil = new ConcreteCommandKisiSil(rk1);

            InvokerKisi ik = new InvokerKisi();

            ik.commandKisiList.Add(ckAdd);
            ik.commandKisiList.Add(ckSil);

            ik.ExecuteAll();

            Console.ReadKey();
        }
    }

    // Command deseni için zorunlu değil
    public class Kisi
    {
        public int Id { get; set; }
        public string Ad { get; set; }
    }

    //Kisi nesnemiz için ekle ve sil işlemlerinin yani metotlarının olduğu, tasarım desenimizde ki Invoker yapısına karşılık gelen ReceiverKisi nesnemizi oluşturalım.
    // Kisi üzerinde işlemler yapan nesne.
    public class ReceiverKisi
    {
        private Kisi _EntityKisi;

        public ReceiverKisi(Kisi entityKisi)
        {
            this._EntityKisi = entityKisi;
        }

        public void Ekle()
        {
            Console.WriteLine("{0} Eklendi.", _EntityKisi.Ad);
        }

        public void Sil()
        {
            Console.WriteLine("ID:{0} Silindi.", _EntityKisi.Id);
        }
    }

    //ReceiverKisi nesnemizde tanımlı olan Ekle() veya Sil() metotlarını çalıştıracak, desenimizdeki Command yapısına karşılık gelen, CommandKisi soyut sınıfımızı oluşturalım.
    // ReceiverKisi deki ekle veya sil metotlarını çalıştıracak olan sınıfların uygulaması gereken abstract sınıf.
    public abstract class CommandKisi
    {
        protected ReceiverKisi _receiverKisi;

        public CommandKisi(ReceiverKisi receiverKisi)
        {
            this._receiverKisi = receiverKisi;
        }

        public abstract void Execute();
    }

    //CommandKisi abstract nesnesinden türeyen yani ReceiverKisi nesnesindeki metotları kullanan, tasarım desenimizdeki Concrete Command yapısına karşılık gelen nesnelerimizi oluşturalım.
    //// ReceiverKisi de Ekle metodunu çalıştıracak olan ConcreteCommand nesnesi.
    public class ConcreteCommandKisiEkle : CommandKisi
    {
        public ConcreteCommandKisiEkle(ReceiverKisi receiverKisi) : base(receiverKisi)
        {
        }

        public override void Execute()
        {
            _receiverKisi.Ekle();
        }
    }

    // ReceiverKisi de Sil metodunu çalıştıracak olan ConcreteCommand nesnesi.
    public class ConcreteCommandKisiSil : CommandKisi
    {
        public ConcreteCommandKisiSil(ReceiverKisi receiverKisi) : base(receiverKisi)
        {
        }

        public override void Execute()
        {
            _receiverKisi.Sil();
        }
    }

    //Şimdi de tasarım desenimizde ki Invoker yapısına karşılık gelen, yani CommandKisi soyut sınıfını kullanan nesnelerin Execute() metodunu çalıştıracak olan InvokerKisi nesnemizi oluşturalım.
    // İşlemlerin çalıştırılacağı nesne.
    public class InvokerKisi
    {
        public List<CommandKisi> commandKisiList { get; set; }

        public InvokerKisi()
        {
            commandKisiList = new List<CommandKisi>();
        }

        public void ExecuteAll()
        {
            if (commandKisiList.Count == 0)
            {
                return;
            }

            foreach (CommandKisi kisi in commandKisiList)
            {
                kisi.Execute();
            }
        }

    }




}

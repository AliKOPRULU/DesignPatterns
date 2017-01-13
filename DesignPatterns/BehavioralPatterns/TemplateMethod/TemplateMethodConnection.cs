using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.BehavioralPatterns.TemplateMethod
{
    class TemplateMethodConnection
    {
        public static void Main(string[] args)
        {
            OperationContack o = new OperationContack();
            o.TemplateInsert();
            OperationProduct op = new OperationProduct();
            o.TemplateCheckData();



            Console.ReadKey();
        }
    }

    //Template yapısı
    abstract class Operation
    {
        private void OpenCon()
        {
            Console.WriteLine("Connection Open");
        }

        //bu abstract sınıfı uygulayan sınıfların sadece Insert ve CheckData da yapılacak
        //işlemleri overwrite etmesi gereklidir.
        public abstract void Insert();
        public abstract bool CheckData();

        public void CloseCon()
        {
            Console.WriteLine("Connection Close");
        }

        //Bu sınıfı uygulayan sınıfların her işlemde connection u açmaya ve kapatmaya ihtiyacı kalmamıştır.
        //connection açma ve kapama işlemleri TemplateMethod larda yapılıyor.

        public void TemplateInsert()
        {
            OpenCon();
            Insert();
            CloseCon();
        }

        public bool TemplateCheckData()
        {
            OpenCon();
            bool Check = CheckData();
            CloseCon();
            return Check;
        }
    }

    //ConcreteTemplateMethod
    class OperationContack : Operation
    {
        public override bool CheckData()
        {
            //Kontroller yapıldığını varsayalım...
            Console.WriteLine("Contact Kayıt Bulundu.");
            return true;
        }

        public override void Insert()
        {
            Console.WriteLine("Contact Kayıt Eklendi.");
        }
    }

    class OperationProduct : Operation
    {
        public override void Insert()
        {
            Console.WriteLine("Product Kayıt Eklendi.");
        }
        public override bool CheckData()
        {
            //Kontroller yapıldığını varsayalım...
            Console.WriteLine("Product Kayıt Bulundu.");
            return true;
        }
    }


















}

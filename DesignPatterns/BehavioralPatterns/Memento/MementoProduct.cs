using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.BehavioralPatterns.Memento
{
    class MementoProduct
    {
        public static void Main(string[] args)
        {
            // Örnek bir Product nesnesi oluşturulur
            Product prd = new Product
            {
                ProductId = 1000,
                Name = "Kahve Dünyası Kahve Fincanı 330 mililitre",
                ListPrice = 12
            };

            Console.WriteLine(prd.ToString());

            // Caretaker nesnesi oluşturulur.   
            Memory memory = new Memory();
            // Memento nesnesi içeriği o anki Product örneğinden elde edilir.
            memory.ProductMemento = prd.Save();
            Console.WriteLine("Product nesnesi kaydedildi.Değişiklik yapılacak.");

            prd.ProductId = 9999;
            prd.Name = "Kahve Dünyası KAHVE KABI";
            prd.ListPrice = 24;
            Console.WriteLine("Yeni hali : \n\t{0}", prd.ToString());

            // Restore işlemi gerçekleştirilir
            prd.Restore(memory.ProductMemento);
            Console.WriteLine("Undo : \n\t{0}", prd.ToString());


            Console.ReadKey();
        }

        // Originator Class
        // Yaratıcı sınıf
        class Product
        {
            public int ProductId { get; set; }
            public string Name { get; set; }
            public decimal ListPrice { get; set; }

            // O anki Product nesne örneğinin içeriğini yeni bir Memento nesne örneğinde toplar ve bunu dış ortama verir.
            public Memento Save()
            {
                return new Memento
                {
                    ProductId = this.ProductId,
                    Name = this.Name,
                    ListPrice = this.ListPrice
                };
            }
            // Saklanan Memento nesne örneğini alarak o anki Product nesne örneğinin dahili içeriğinin doldurulmasında kullanılır.
            public void Restore(Memento memento)
            {
                this.ListPrice = memento.ListPrice;
                this.Name = memento.Name;
                this.ProductId = memento.ProductId;
            }

            public override string ToString()
            {
                return String.Format("{0} : {1} ( {2} )", ProductId, Name, ListPrice.ToString("C2"));
            }

        }

        // Memento Class
        // Akıl defteri sınıfı
        // Product tipi içerisinden saklanmak amacıyla kullanılacak tüm özellikleri tanımlar
        class Memento
        {
            public int ProductId { get; set; }
            public string Name { get; set; }
            public decimal ListPrice { get; set; }
        }

        // Caretaker class
        // Bakıcı sınıf
        class Memory
        {
            public Memento ProductMemento { get; set; }
        }










    }




















}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.BehavioralPatterns.Iterator
{//http://harunozer.com/makale/iterator_tasarim_deseni__iterator_design_pattern.htm
    class IteratorTakim
    {
        public static void Main(string[] args)
        {
            TakimconCreteAggregate TakimCollection = new TakimconCreteAggregate();
            TakimCollection.Add(new Takim { TakimAdi = "Şalvar spor", Puan = 55 });
            TakimCollection.Add(new Takim { TakimAdi = "Real Madrid", Puan = 9 });
            TakimCollection.Add(new Takim { TakimAdi = "Barcelona", Puan = 10 });

            ITakimIterator itr = TakimCollection.GetIterator();

            while (itr.IsDone())
            {
                Console.WriteLine("{0}:{1}", itr.CurrentItem().TakimAdi, itr.CurrentItem().Puan);
                itr.Next();
            }

            Console.ReadKey();
        }
    }

    class Takim
    {
        public string TakimAdi { get; set; }
        public int Puan { get; set; }
    }

    //Iterator arayüzü
    interface ITakimIterator
    {
        Takim Next();
        bool IsDone();
        Takim CurrentItem();
    }

    //Aggregate arayüzü-kümüleme toplama
    interface ITakimAggregate
    {
        ITakimIterator GetIterator();
    }

    //ConcreteAggregate
    class TakimconCreteAggregate : ITakimAggregate
    {
        private List<Takim> _TakimList = new List<Takim>();
        public int TakimCount { get { return _TakimList.Count; } }

        public void Add(Takim t)
        {
            _TakimList.Add(t);
        }

        public Takim GetItem(int index)
        {
            return _TakimList[index];
        }

        public ITakimIterator GetIterator()
        {
            return new TakimConcreteIterator(this);
        }
    }

    //ConcreteIterator
    class TakimConcreteIterator : ITakimIterator
    {
        private TakimconCreteAggregate CollectionTakim;
        private int _index = 0;

        public TakimConcreteIterator(TakimconCreteAggregate ColTakim)
        {
            this.CollectionTakim = ColTakim;
        }

        public Takim CurrentItem()
        {
            return CollectionTakim.GetItem(_index);
        }

        public bool IsDone()
        {
            return _index < CollectionTakim.TakimCount;
        }

        public Takim Next()
        {
            _index++;
            if (IsDone())
            {
                return CollectionTakim.GetItem(_index);
            }
            else
            {
                return null;
            }
        }
    }
}

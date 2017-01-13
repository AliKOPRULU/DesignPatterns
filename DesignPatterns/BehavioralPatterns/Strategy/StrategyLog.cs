using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.BehavioralPatterns.Strategy
{//http://harunozer.com/makale/strategy_tasarim_deseni__strategy_design_pattern.htm
    class StrategyLog
    {
        public static void Main(string[] args)
        {
            //direkt LogDb veya LogFile nesnelerini kullanmayıp
            //LogWriter üzerinden erişimi sağlıyoruz.
            LogWriter lw = new LogWriter(new LogiFile());
            lw.LogInsert("ins1");
            lw = new LogWriter(new LogDb());
            lw.LogInsert("inse2");

            //diyelim ki sonradan uygulamamızın registry bazlı log tutmasını istedik.
            //tek yapmamız gereken yeni bir ConcreteStrategy yapısı oluşturmak.
            //tabiki bütün loglar aynı şekilde tutulacak ise Constructor a parametre
            //vermek yerine LogWriter Constructor da direkt istediğimiz Concrete türünü oluşturabiliriz.


            Console.ReadKey();
        }
    }

    interface ILogStrategy
    {
        void InsertLog(string LogValue);
    }

    //Concrete strategy 1
    class LogiFile : ILogStrategy
    {
        public void InsertLog(string LogValue)
        {
            Console.WriteLine("File bazlı log yazıldı.");
        }
    }

    //ConcreteStrategy2
    class LogDb : ILogStrategy
    {
        public void InsertLog(string LogValue)
        {
            Console.WriteLine("Veri tabanı bazlı log yazıldı.");
        }
    }

    //Context yapısı
    class LogWriter
    {
        ILogStrategy _logStrategy;

        public LogWriter(ILogStrategy logStrategy)
        {
            this._logStrategy = logStrategy;
        }

        public void LogInsert(string LogValue)
        {
            _logStrategy.InsertLog(LogValue);
        }
    }

    
         















}

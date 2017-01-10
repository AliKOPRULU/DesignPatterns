using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.BehavioralPatterns.ChainofResponsibility
{
    class ChainofResponsibilityLog
    {
        public static void Main(string[] args)
        {
            SqlLogger sqlLogger = new SqlLogger();
            EventLogger eventLogger = new EventLogger();
            TextLogger textLogger = new TextLogger();
            
            sqlLogger.SetNextLogger(eventLogger);// Zincirin adımlarını oluşturuyoruz.
            eventLogger.SetNextLogger(textLogger);

            try
            {
                //Programın normal akışı
            }
            catch (Exception exc)
            {
                sqlLogger.LogYaz(exc); // bir hata oluştuğunda logluyoruz. Zincir kendi içinde işlemey başlıyor.
            }

            Console.ReadKey();
        }
    }

    public abstract class LogBase
    {
        protected LogBase NextLogger;

        public void SetNextLogger(LogBase logger)
        {
            this.NextLogger = logger;
        }

        abstract public void LogYaz(Exception exc);
    }

    public class SqlLogger : LogBase
    {
        public override void LogYaz(Exception exc)
        {
            try
            {
                //Veritabanına exc nesnesine ait verinin yazılması işlemi
                //Bu bölümün yazılması size bırakılmıştır.
            }
            catch
            {
                if (NextLogger != null)
                {
                    NextLogger.LogYaz(exc);
                }

            }
        }
    }

    public class EventLogger : LogBase
    {
        public override void LogYaz(Exception exc)
        {
            try
            {
                //Event Loga exc nesnesine ait verinin yazılması işlemi
                //Bu bölümün yazılması size bırakılmıştır.
            }
            catch
            {
                if (NextLogger != null)
                {
                    NextLogger.LogYaz(exc);
                }
            }
        }
    }

    public class TextLogger : LogBase
    {
        public override void LogYaz(Exception exc)
        {
            try
            {
                //Metin dosyasına exc nesnesine ait verinin yazılması işlemi
                //Bu bölümün yazılması size bırakılmıştır.
            }
            catch
            {
                //Zincirin son halkası. Eğer burada da başarılı olunamıyorsa ona göre aksiyon alınmalıdır.
            }
        }
    }




}

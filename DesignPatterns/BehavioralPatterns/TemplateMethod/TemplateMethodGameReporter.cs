using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.BehavioralPatterns.TemplateMethod
{
    class TemplateMethodGameReporter
    {
        public static void Main(string[] args)
        {
            GameReporter reporter = null;

            reporter = new XmlReporter();
            reporter.WriteSummary();
            Console.WriteLine();

            reporter = new TextReporter();
            reporter.WriteSummary();
            Console.WriteLine();


            reporter = new ConsolerReporter();
            reporter.WriteSummary();


            Console.ReadKey();
        }
    }

    abstract class GameReporter
    {
        public void GetResults()
        {
            Console.WriteLine("Oyuncuların istatistikleri toplanıyor");
        }

        public void ParseResults()
        {
            Console.WriteLine("İstatistikler ayrıştırılıyor");
        }

        public abstract void WriteResults();

        public void WriteSummary()
        {
            GetResults();
            ParseResults();
            WriteResults();
        }
    }

    class XmlReporter : GameReporter
    {
        public override void WriteResults()
        {
            Console.WriteLine("İstatistikler XML dosyasına yazılıyor.");
        }
    }

    class TextReporter : GameReporter
    {
        public override void WriteResults()
        {
            Console.WriteLine("İstatistikler TEXT dosyasına yazdırılıyor.");
        }
    }

    class ConsolerReporter : GameReporter
    {
        public override void WriteResults()
        {
            Console.WriteLine("İstatistikler CONSOLE ekranına basılıyor.");
        }
    }












}

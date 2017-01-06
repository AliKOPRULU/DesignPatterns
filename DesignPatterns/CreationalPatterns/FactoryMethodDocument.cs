using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.CreationalPatterns
{
    class FactoryMethodDocument
    {
        public static void Main(string[] args)
        {
            // Note: constructors call Factory Method
            Document[] documents = new Document[2];

            documents[0] = new Report();
            documents[1] = new Resume();

            foreach (Document document in documents)
            {
                Console.WriteLine("\n"+document.GetType().Name + "---");
                foreach (Page page in document.Pages)
                {
                    Console.WriteLine(page.GetType().Name);
                }
            }

            Console.ReadKey();
        }
    }

    abstract class Page
    {

    }

    class SkillsPage : Page
    {

    }

    class EducationPage : Page
    {

    }

    class ExperiencePage : Page
    {

    }

    class IntroductionPage : Page
    {

    }

    class ResultsPage : Page
    {

    }

    class ConclusionPage : Page//sonuç
    {

    }

    class SummaryPage : Page//özet
    {

    }

    class BibliographyPage : Page//kaynakça
    {

    }

    abstract class Document
    {
        private List<Page> _pages = new List<Page>();

        // Constructor calls abstract Factory method
        public Document()
        {
            this.CreatePages();
        }

        public List<Page> Pages
        {
            get { return _pages; }
        }

        // Factory Method
        public abstract void CreatePages();
    }

    class Resume : Document//özet
    {
        public override void CreatePages()
        {
            Pages.Add(new SkillsPage());
            Pages.Add(new EducationPage());
            Pages.Add(new ExperiencePage());
        }
    }

    // A 'ConcreteCreator' class
    class Report : Document
    {
        // Factory Method implementation
        public override void CreatePages()
        {
            Pages.Add(new IntroductionPage());
            Pages.Add(new ResultsPage());
            Pages.Add(new ConclusionPage());
            Pages.Add(new SummaryPage());
            Pages.Add(new BibliographyPage());
        }
    }



}

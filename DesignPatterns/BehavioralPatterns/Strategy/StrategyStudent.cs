using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.BehavioralPatterns.Strategy
{
    class StrategyStudent
    {
        public static void Main(string[] args)
        {
            // Two contexts following different strategies
            SortedList studentRecords = new SortedList();

            studentRecords.Add("Ali");
            studentRecords.Add("Alper");
            studentRecords.Add("Murat");
            studentRecords.Add("Köksal");
            studentRecords.Add("Ömür");

            studentRecords.SetSortStrategy(new QuickSort());
            studentRecords.Sort();

            studentRecords.SetSortStrategy(new ShellSort());
            studentRecords.Sort();

            studentRecords.SetSortStrategy(new MergeSort());
            studentRecords.Sort();



            Console.ReadKey();
        }
    }

    abstract class SortStrategy
    {
        public abstract void Sort(List<string> list);
    }

    class QuickSort : SortStrategy
    {
        public override void Sort(List<string> list)
        {
            list.Sort();// Default is Quicksort
            Console.WriteLine("QuickSorted list");
        }
    }

    class ShellSort : SortStrategy
    {
        public override void Sort(List<string> list)
        {//list.ShellSort(); not-implemented
            Console.WriteLine("ShellSorted Strategy");
        }
    }

    class MergeSort : SortStrategy
    {
        public override void Sort(List<string> list)
        {//list.MergeSort(); not-implemented
            Console.WriteLine("MErgeSorted list");
        }
    }

    class SortedList
    {
        private List<string> _list = new List<string>();
        private SortStrategy _sortStrategy;

        public void SetSortStrategy(SortStrategy sortStrategy)
        {
            this._sortStrategy = sortStrategy;
        }

        public void Add(string name)
        {
            _list.Add(name);
        }

        public void Sort()
        {
            _sortStrategy.Sort(_list);

            // Iterate over list and display results
            foreach (string name in _list)
            {
                Console.WriteLine(" " + name);
            }

            Console.WriteLine();
        }

    }








}

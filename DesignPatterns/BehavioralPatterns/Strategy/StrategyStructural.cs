using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.BehavioralPatterns.Strategy
{
    class StrategyStructural
    {
        public static void Main(string[] args)
        {
            Context context;
            // Three contexts following different strategies

            context = new Context(new ConcreteStrategyA());
            context.ContextInterface();

            context = new Context(new ConcreteStrategyB());
            context.ContextInterface();

            context = new Context(new ConcreteStrategyC());
            context.ContextInterface();



            Console.ReadKey();
        }
    }

    abstract class StrategyS
    {
        public abstract void AlgorithmInterface();
    }

    class ConcreteStrategyA : StrategyS
    {
        public override void AlgorithmInterface()
        {
            Console.WriteLine("Called ConcreteStrategyA.AlgorithmInterface()");
        }
    }

    class ConcreteStrategyB : StrategyS
    {
        public override void AlgorithmInterface()
        {
            Console.WriteLine("Called ConcreteStrategyB.AlgorithmInterface()");
        }
    }

    class ConcreteStrategyC : StrategyS
    {
        public override void AlgorithmInterface()
        {
            Console.WriteLine("Called ConcreteStrategyC.AlgorithmInterface()");
        }
    }

    class Context
    {
        private StrategyS _strategyS;

        public Context(StrategyS strategyS)
        {
            this._strategyS = strategyS;
        }

        public void ContextInterface()
        {
            _strategyS.AlgorithmInterface();
        }        
    }











}

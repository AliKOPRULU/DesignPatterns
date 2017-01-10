using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.BehavioralPatterns.ChainofResponsibility
{
    class ChainofResponsibilityStructural
    {
        public static void Main(string[] args)
        {
            // Setup Chain of Responsibility
            Handler h1 = new ConcreteHandler1();
            Handler h2 = new ConcreteHandler2();
            Handler h3 = new ConcreteHandler3();

            h1.SetSuccessor(h2);
            h2.SetSuccessor(h3);

            // Generate and process request
            int[] requests = { 2, 5, 14, 22, 18, 3, 27, 20 };

            foreach (int request in requests)
            {
                h1.HandlerRequest(request);
            }

            Console.ReadKey();
        }
    }

    abstract class Handler
    {
        protected Handler successor;//successor: mirasçı

        public void SetSuccessor(Handler successor)
        {
            this.successor = successor;
        }

        public abstract void HandlerRequest(int request);
    }

    // The 'ConcreteHandler1' class
    class ConcreteHandler1 : Handler
    {
        public override void HandlerRequest(int request)
        {
            if (request >= 0 && request < 10)
            {
                Console.WriteLine("{0} handled request {1}" + this.GetType().Name, request);
            }
            else if (successor != null)
            {
                successor.HandlerRequest(request);
            }
        }
    }

    // The 'ConcreteHandler2' class
    class ConcreteHandler2 : Handler
    {
        public override void HandlerRequest(int request)
        {
            if (request >= 10 && request < 20)
            {
                Console.WriteLine("{0} handled request {1}" + this.GetType().Name, request);
            }
            else if (successor != null)
            {
                successor.HandlerRequest(request);
            }
        }
    }

    class ConcreteHandler3 : Handler
    {
        public override void HandlerRequest(int request)
        {
            if (request >= 20 && request < 30)
            {
                Console.WriteLine("{0} handled request {1}" + this.GetType().Name, request);
            }
            else if (successor != null)
            {
                successor.HandlerRequest(request);
            }
        }
    }












}

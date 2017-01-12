using System;

namespace DesignPatterns.BehavioralPatterns.ChainofResponsibility
{
    class ChainofResponsibilityApprover
    {
        public static void Main(string[] args)
        {
            // Setup Chain of Responsibility
            Approver Murat = new Director();
            Approver Ali = new VicePresident();
            Approver Alper = new President();

            Murat.SetSuccessor(Ali);
            Ali.SetSuccessor(Alper);

            // Generate and process purchase requests
            Purchase p = new Purchase(2034, 350.00, "Assets");
            Murat.ProcessRequest(p);

            p = new Purchase(2035, 32590.10, "Project X");
            Murat.ProcessRequest(p);

            p = new Purchase(2036, 122100.00, "Project Y");
            Murat.ProcessRequest(p);


            Console.ReadKey();
        }
    }

    abstract class Approver//onaycı
    {
        protected Approver successor;//successor:varis

        public void SetSuccessor(Approver successor)
        {
            this.successor = successor;
        }

        public abstract void ProcessRequest(Purchase purchase);
    }

    public class Purchase
    {
        private int _number;
        private double _amount;
        private string _purpose;//amaç

        public Purchase(int number, double amount, string purpose)
        {
            this._number = number;
            this._amount = amount;
            this._purpose = purpose;
        }

        public int Number
        {
            get { return _number; }
            set { _number = value; }
        }

        public double Amount
        {
            get { return _amount; }
            set { _amount = value; }
        }

        public string Purpose
        {
            get { return _purpose; }
            set { _purpose = value; }
        }

    }

    // The 'ConcreteHandler' class
    class Director : Approver
    {
        public override void ProcessRequest(Purchase purchase)
        {
            if (purchase.Amount < 10000.0)
            {
                Console.WriteLine("{0} approved request# {1}", this.GetType().Name, purchase.Number);
            }
            else if (successor != null)
            {
                successor.ProcessRequest(purchase);
            }
        }
    }

    // The 'ConcreteHandler' class
    class VicePresident : Approver
    {
        public override void ProcessRequest(Purchase purchase)
        {
            if (purchase.Amount < 25000.0)
            {
                Console.WriteLine("{0} approved request# {1}", this.GetType().Name, purchase.Number);
            }
            else if (successor != null)
            {
                successor.ProcessRequest(purchase);
            }
        }
    }

    // The 'ConcreteHandler' class
    class President : Approver
    {
        public override void ProcessRequest(Purchase purchase)
        {
            if (purchase.Amount < 100000.0)
            {
                Console.WriteLine("{0} approved request# {1}", this.GetType().Name, purchase.Number);
            }
            else
            {
                Console.WriteLine("Request# {0} requires an executive meeting!", purchase.Number);
            }
        }
    }




}

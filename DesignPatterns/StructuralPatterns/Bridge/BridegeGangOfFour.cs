using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.StructuralPatterns.Bridge
{
    class BridegeGangOfFour
    {
        public static void Main(string[] args)
        {
            // Create RefinedAbstraction
            Customer customers = new Customer("Chicago");

            // Set ConcreteImplementor
            customers.Data = new CustomerData();

            // Exercise the bridge
            customers.Show();
            customers.Next();
            customers.Show();
            customers.Next();
            customers.Show();
            customers.Add("Adem KÖPRÜLÜ");
            customers.ShowAll();

            Console.ReadKey();
        }
    }

    abstract class DataObject
    {
        public abstract void NextRecord();
        public abstract void PriorRecord();
        public abstract void AddRecord(string name);
        public abstract void DeleteRecord(string name);
        public abstract void ShowRecord();
        public abstract void ShowAllRecord();
    }


    class CustomerBase
    {
        private DataObject _dataObject;
        protected string group;

        public CustomerBase(string group)
        {
            this.group = group;
        }

        //Property
        public DataObject Data
        {
            set { _dataObject = value; }
            get { return _dataObject; }
        }

        public virtual void Next()
        {
            _dataObject.NextRecord();
        }

        public virtual void Prior()
        {
            _dataObject.PriorRecord();
        }

        public virtual void Add(string customer)
        {
            _dataObject.AddRecord(customer);
        }

        public virtual void Delete(string customer)
        {
            _dataObject.DeleteRecord(customer);
        }

        public virtual void Show()
        {
            _dataObject.ShowRecord();
        }

        public virtual void ShowAll()
        {
            Console.WriteLine("Customer Group: " + group);
            _dataObject.ShowAllRecord();
        }
    }

    class Customer : CustomerBase
    {
        //constructor
        public Customer(string group) : base(group)
        {
        }

        public override void ShowAll()
        {
            // Add separator lines
            Console.WriteLine();
            Console.WriteLine("------------------------");
            base.ShowAll();
            Console.WriteLine("------------------------");
        }
    }

    // The 'ConcreteImplementor' class
    class CustomerData : DataObject
    {
        private List<string> _customer = new List<string>();
        private int _current = 0;

        public CustomerData()
        {
            // Loaded from a database 
            _customer.Add("Ali KÖPRÜLÜ");
            _customer.Add("Alper KÖPRÜLÜ");
            _customer.Add("Murat ÖDÜNÇ");
            _customer.Add("Köksal SARI");
            _customer.Add("Ömür GÖK");
        }

        public override void AddRecord(string customer)
        {
            _customer.Add(customer);
        }

        public override void DeleteRecord(string customer)
        {
            _customer.Remove(customer);
        }

        public override void NextRecord()
        {
            if (_current <= _customer.Count - 1)
            {
                _current++;
            }
        }

        public override void PriorRecord()
        {
            if (_current > 0)
            {
                _current--;
            }
        }

        public override void ShowAllRecord()
        {
            foreach (string customer in _customer)
            {
                Console.WriteLine(" " + customer);
            }
        }

        public override void ShowRecord()
        {
            Console.WriteLine(_customer[_current]);
        }
    }







}

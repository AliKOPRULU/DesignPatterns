using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.BehavioralPatterns.Visitor
{
    class VisitorEmployee
    {
        public static void Main(string[] args)
        {
            // Setup employee collection
            Employees e = new Employees();
            e.Attach(new Clerk());
            e.Attach(new Director());
            e.Attach(new President());

            // Employees are 'visited'
            e.Accept(new IncomeVisitor());
            e.Accept(new VacationVisitor());



            Console.ReadKey();
        }
    }

    interface IVisitor
    {
        void Visit(Element element);
    }

    abstract class Element
    {
        public abstract void Accept(IVisitor visitor);
    }

    class IncomeVisitor : IVisitor
    {
        public void Visit(Element element)
        {
            Employee employee = element as Employee;

            // Provide 10% pay raise
            employee.Income *= 1.10;
            Console.WriteLine("{0} {1}'s new income: {2:C}", employee.GetType().Name, employee.Name, employee.Income);
        }
    }

    class VacationVisitor : IVisitor
    {
        public void Visit(Element element)
        {
            Employee employee = element as Employee;

            // Provide 3 extra vacation days
            employee.VocationDays += 3;
            Console.WriteLine("{0} {1}'s new vocation days: {2}", employee.GetType().Name, employee.Name, employee.VocationDays);
        }
    }

    class Employee : Element
    {
        private string _name;
        private double _income;
        private int _vocationDays;

        public Employee(string name, double income, int vocationDays)
        {
            this._name = name;
            this._income = income;
            this._vocationDays = vocationDays;
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public double Income
        {
            get { return _income; }
            set { _income = value; }
        }

        public int VocationDays
        {
            get { return _vocationDays; }
            set { _vocationDays = value; }
        }

        public override void Accept(IVisitor Visitor)
        {
            Visitor.Visit(this);
        }
    }

    // The 'ObjectStructure' class
    class Employees
    {
        private List<Employee> _employees = new List<Employee>();

        public void Attach(Employee employee)
        {
            _employees.Add(employee);
        }

        public void Detach(Employee employee)
        {
            _employees.Remove(employee);
        }

        public void Accept(IVisitor visitor)
        {
            foreach (Employee employee in _employees)
            {
                employee.Accept(visitor);
            }
            Console.WriteLine();
        }
    }

    // Three employee types
    class Clerk : Employee//Clerk:kâtip yazman
    {
        public Clerk() : base("Ali",25000.0,14)
        {
        }
    }

    class Director : Employee//Müdür
    {
        public Director() : base("Murat", 35000.0, 16)
        {
        }
    }

    class President : Employee
    {
        public President() : base("Alper", 45000.0, 21)
        {
        }
    }




}

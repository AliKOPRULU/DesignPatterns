using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.StructuralPatterns.Facade
{//http://www.dofactory.com/net/facade-design-pattern
    class FacedeMortgage
    {
        public static void Main(string[] args)
        {
            //facede
            Mortgage mortgage = new Mortgage();
            //Evaluate mortgage eligibility for customer //eligibility:uygunluk
            Customer customer = new Customer("Ali KÖPRÜLÜ");
            bool eligible = mortgage.isEligible(customer, 125000);

            Console.WriteLine("\n" + customer.Name + " has been " + (eligible ? "Approved" : "Rejected"));

            Console.ReadKey();
        }
    }


    class Bank
    {
        public bool HasSyfficientSavings(Customer c, int amount)//yeterli birikmişi
        {
            Console.WriteLine("Check bank for " + c.Name);
            return true;
        }
    }

    class Credit
    {
        public bool HasGodCredit(Customer c)
        {
            Console.WriteLine("Check credit for " + c.Name);
            return true;
        }
    }

    class Loan//Loan kredi
    {
        public bool HasNoBadLoans(Customer c)
        {
            Console.WriteLine("Check loans for " + c.Name);
            return true;
        }
    }

    public class Customer
    {
        private string _name;

        public Customer(string name)
        {
            this._name = name;
        }

        public string Name { get { return _name; } }
    }

    // The 'Facade' class
    class Mortgage
    {
        private Bank _bank = new Bank();
        private Credit _credit = new Credit();
        private Loan _loan = new Loan();

        public bool isEligible(Customer cust, int amount)//Eligible hak sahibi
        {
            Console.WriteLine("{0} applies for {1:C} load\n", cust.Name, amount);
            bool eligible = true;

            // Check creditworthyness of applicant
            if (!_bank.HasSyfficientSavings(cust, amount))//Başvuru adayının Kredi puanı/değeri
            {
                eligible = false;
            }
            else if (!_loan.HasNoBadLoans(cust))
            {
                eligible = false;
            }
            else if (!_credit.HasGodCredit(cust))
            {
                eligible = false;
            }
            return eligible;
        }
    }

    


}

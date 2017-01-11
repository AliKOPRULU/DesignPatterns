using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.BehavioralPatterns.Interpreter
{
    class InterpreterRomeNumber
    {
        public static void Main(string[] args)
        {
            string roman = "MCMXXVIII";
            Context context = new Context(roman);

            // Build the 'parse tree'
            List<Expression> tree = new List<Expression>();
            tree.Add(new ThousandExpression());
            tree.Add(new HundredExpression());
            tree.Add(new TenExpression());
            tree.Add(new OneExpression());

            //Interpret
            foreach (Expression exp in tree)
            {
                exp.Interpret(context);
            }

            Console.WriteLine("{0} = {1}", roman, context.Output);

            Console.ReadKey();
        }
    }

    // The 'Context' class
    class Context
    {
        private string _input;
        private int _output;

        public Context(string input)
        {
            this.Input = input;
        }

        // Gets or sets input
        public string Input
        {
            get { return _input; }
            set { _input = value; }
        }

        // Gets or sets output
        public int Output
        {
            get { return _output; }
            set { _output = value; }
        }
    }

    // The 'AbstractExpression' class
    abstract class Expression
    {
        public void Interpret(Context context)
        {
            if (context.Input.Length == 0)
            {
                return;
            }

            if (context.Input.StartsWith(Nine()))
            {
                context.Output += (9 * Multiplier());
                context.Input = context.Input.Substring(2);
            }
            else if (context.Input.StartsWith(Four()))
            {
                context.Output += (4 * Multiplier());
                context.Input = context.Input.Substring(2);
            }
            else if (context.Input.StartsWith(Five()))
            {
                context.Output += (5 * Multiplier());
                context.Input = context.Input.Substring(1);
            }

            while (context.Input.StartsWith(One()))
            {
                context.Output += (1 * Multiplier());
                context.Input = context.Input.Substring(1);
            }
        }

        public abstract string One();
        public abstract string Four();
        public abstract string Five();
        public abstract string Nine();
        public abstract int Multiplier();
    }

    // A 'TerminalExpression' class
    // Thousand checks for the Roman Numeral M 
    class ThousandExpression : Expression
    {
        public override string Five() { return " "; }
        public override string Four() { return " "; }
        public override int Multiplier() { return 1000; }
        public override string Nine() { return " "; }
        public override string One() { return "M"; }
    }

    // A 'TerminalExpression' class
    // Hundred checks C, CD, D or CM
    class HundredExpression : Expression
    {
        public override string Five() { return "D"; }
        public override string Four() { return "CD"; }
        public override int Multiplier() { return 100; }
        public override string Nine() { return "CM"; }
        public override string One() { return "C"; }
    }

    /// A 'TerminalExpression' class
    /// Ten checks for X, XL, L and XC
    class TenExpression : Expression
    {
        public override string One() { return "X"; }
        public override string Four() { return "XL"; }
        public override string Five() { return "L"; }
        public override string Nine() { return "XC"; }
        public override int Multiplier() { return 10; }
    }

    // A 'TerminalExpression' class
    // One checks for I, II, III, IV, V, VI, VI, VII, VIII, IX
    class OneExpression : Expression
    {
        public override string One() { return "I"; }
        public override string Four() { return "IV"; }
        public override string Five() { return "V"; }
        public override string Nine() { return "IX"; }
        public override int Multiplier() { return 1; }
    }


}

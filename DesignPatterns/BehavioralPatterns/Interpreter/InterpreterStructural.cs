using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.BehavioralPatterns.Interpreter
{
    class InterpreterStructural
    {
        public static void Main(string[] args)
        {
            Context context = new Context();

            // Usually a tree 
            ArrayList list = new ArrayList();

            // Populate 'abstract syntax tree' 
            list.Add(new TerminalExpression());
            list.Add(new NonTerminalExpression());
            list.Add(new TerminalExpression());
            list.Add(new TerminalExpression());

            // Interpret
            foreach (AbstractExpression exp in list)
            {
                exp.Interpret(context);
            }


            Console.ReadKey();
        }
    }

    class Context
    {

    }

    // The 'AbstractExpression' abstract class
    abstract class AbstractExpression
    {
        public abstract void Interpret(Context context);
    }

    // The 'TerminalExpression' class
    class TerminalExpression : AbstractExpression
    {
        public override void Interpret(Context context)
        {
            Console.WriteLine("Called Termial.Interpret()");
        }
    }

    // The 'NonterminalExpression' class
    class NonTerminalExpression : AbstractExpression
    {
        public override void Interpret(Context context)
        {
            Console.WriteLine("Called NonTerminalExpression.Interpret()");
        }
    }



}

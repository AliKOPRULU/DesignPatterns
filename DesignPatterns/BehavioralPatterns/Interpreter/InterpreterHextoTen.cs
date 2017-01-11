using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.BehavioralPatterns.Interpreter
{//http://harunozer.com/makale/interpreter_tasarim_deseni__interpreter_design_pattern.htm
    class InterpreterHextoTen
    {//Nonterminal değerlendirmeye alınmadı
        public static void Main(string[] args)
        {
            Context c = new Context { HexValue = "ABCABB" };
            List<ITerminalExpression> ExpList = new List<ITerminalExpression>();

            foreach (char item in c.HexValue.ToCharArray())
            {
                switch (item)
                {
                    case 'A':
                        ExpList.Add(new TerminalIExpA());
                        break;
                    case 'B':
                        ExpList.Add(new TerminalIExpB());
                        break;
                    case 'C':
                        ExpList.Add(new TerminalIExpC());
                        break;
                    default:
                        throw new Exception("Geçersiz karakter" + item);
                }
            }

            foreach (ITerminalExpression item in ExpList)
            {
                item.Interpret(c);
            }
            Console.WriteLine(c.OndalikValue);

            Console.ReadKey();
        }
    }

    class Context
    {
        public string HexValue { get; set; }
        public int OndalikValue { get; set; }
    }

    interface ITerminalExpression
    {
        void Interpret(Context context);
    }

    class TerminalIExpA : ITerminalExpression
    {
        public void Interpret(Context context)
        {
            if (context.HexValue.Contains("A"))
            {
                context.OndalikValue += 10;
            }
        }
    }

    class TerminalIExpB : ITerminalExpression
    {
        public void Interpret(Context context)
        {
            if (context.HexValue.Contains("B"))
            {
                context.OndalikValue += 11;
            }
        }
    }

    class TerminalIExpC : ITerminalExpression
    {
        public void Interpret(Context context)
        {
            if (context.HexValue.Contains("C"))
            {
                context.OndalikValue += 12;
            }
        }
    }







}

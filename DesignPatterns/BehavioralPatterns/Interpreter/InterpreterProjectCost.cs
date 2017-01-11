using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.BehavioralPatterns.Interpreter
{//http://www.buraksenyurt.com/post/Tasarc4b1m-Desenleri-Interpreter.aspx
    class InterpreterProjectCost
    {
        static List<RoleExpression> CreateExpressionTree(string formula)
        {
            // Expression ağacı oluşturulur
            List<RoleExpression> tree = new List<RoleExpression>();

            foreach (char role in formula)
            {
                if (role == 'A')
                {
                    tree.Add(new ArchitectureExpression());
                }
                else if (role == 'C')
                {
                    tree.Add(new ConsultantExpression());
                }
                else if (role == 'S')
                {
                    tree.Add(new SeniorExpression());
                }
                else if (role == 'D')
                {
                    tree.Add(new DeveloperExpression());
                }
            }
            return tree;
        }

        static void RunExpression(Context context)
        {
            foreach (RoleExpression expression in CreateExpressionTree(context.Formula))
            {
                expression.Interpret(context);// TerminalExpression tiplerine ait harf sembolleri buradaki metod çağrısındada gönderilebilir.
            }
            Console.WriteLine("{0} için maliyet puanı {1}", context.Formula, context.TotalPoint);
        }

        public static void Main(string[] args)
        {
            Console.WriteLine("Architecture = 5, Consultant=10, Senior=15,Developer=20\n");
            // 1 Architect, 1 Consultan, 2 Senior Developer , 4 Junior Developer
            Context context = new Context { Formula = "ACSSDDDD" };

            RunExpression(context);

            // 1 Consultant, 1 Senior Developer, 2 Developer
            context = new Context { Formula = "CSDD" };
            RunExpression(context);

            // 1 Consultant, 1 Senior Developer, 2 Developer
            context = new Context { Formula = "SD" };
            RunExpression(context);

            Console.ReadKey();
        }
    }

    class Context
    {
        public string Formula { get; set; }
        public int TotalPoint { get; set; }
    }

    // Expression
    abstract class RoleExpression
    {
        public abstract void Interpret(Context context);
    }

    #region Terminal Expression Sınıfları

    // TerminalExpression
    class ArchitectureExpression : RoleExpression
    {
        public override void Interpret(Context context)
        {
            if (context.Formula.Contains("A"))
            {
                context.TotalPoint += 5;
            }
        }
    }

    // TerminalExpression
    class ConsultantExpression : RoleExpression//danışman
    {
        public override void Interpret(Context context)
        {
            if (context.Formula.Contains("C"))
            {
                context.TotalPoint += 10;
            }
        }
    }

    // TerminalExpression
    class SeniorExpression : RoleExpression
    {
        public override void Interpret(Context context)
        {
            if (context.Formula.Contains("S"))
            {
                context.TotalPoint += 15;
            }
        }
    }

    // TerminalExpression
    class DeveloperExpression : RoleExpression
    {
        public override void Interpret(Context context)
        {
            if (context.Formula.Contains("D"))
            {
                context.TotalPoint += 20;
            }
        }
    }

    #endregion








}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.StructuralPatterns.Proxy
{
    class ProxyMath
    {
        public static void Main(string[] args)
        {
            MathProxy proxy = new MathProxy();

            int a = 4;
            int b = 2;

            // Do the math
            Console.WriteLine(a + " + " + b + " = " + proxy.Add(a, b));
            Console.WriteLine(a + " - " + b + " = " + proxy.Sub(a, b));
            Console.WriteLine(a + " * " + b + " = " + proxy.Mul(a, b));
            Console.WriteLine(a + " / " + b + " = " + proxy.Div(a, b));

            Console.ReadKey();
        }
    }

    // The 'Subject interface
    public interface IMath
    {
        double Add(double a, double b);
        double Sub(double a, double b);
        double Mul(double a, double b);
        double Div(double a, double b);
    }

    // The 'RealSubject' class
    class Math : IMath
    {
        public double Add(double a, double b)
        {
            return a + b;
        }

        public double Div(double a, double b)
        {
            return a / b;
        }

        public double Mul(double a, double b)
        {
            return a * b;
        }

        public double Sub(double a, double b)
        {
            return a - b;
        }
    }

    // The 'Proxy Object' class
    class MathProxy : IMath
    {
        private Math _math = new Math();

        public double Add(double a, double b)
        {
            return _math.Add(a, b);
        }

        public double Div(double a, double b)
        {
            return _math.Div(a, b);
        }

        public double Mul(double a, double b)
        {
            return _math.Mul(a, b);
        }

        public double Sub(double a, double b)
        {
            return _math.Sub(a, b);
        }
    }








}

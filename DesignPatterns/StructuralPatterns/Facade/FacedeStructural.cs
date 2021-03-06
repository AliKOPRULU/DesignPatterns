﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.StructuralPatterns.Facade
{
    class FacedeSStructural
    {
        public static void Main(string[] args)
        {
            FacedeS FacedeS = new FacedeS();

            FacedeS.MethodA();
            FacedeS.MethodB();

            Console.ReadKey();
        }
    }

    class SubSystemOne
    {
        public void methodOne() {
            Console.WriteLine("SubSystemOne Method");
        }
    }

    class SubSystemTwo
    {
        public void methodTwo()
        {
            Console.WriteLine("SubSystemTwo Method");
        }
    }

    class SubSystemThree
    {
        public void methodThree()
        {
            Console.WriteLine("SubSystemThree Method");
        }
    }

    class SubSystemFour
    {
        public void methodFour()
        {
            Console.WriteLine("SubSystemFour Method");
        }
    }

    // The 'Facade' class
    class FacedeS
    {
        private SubSystemOne _one;
        private SubSystemTwo _two;
        private SubSystemThree _three;
        private SubSystemFour _four;

        public FacedeS()
        {
            _one = new SubSystemOne();
            _two = new SubSystemTwo();
            _three = new SubSystemThree();
            _four = new SubSystemFour();
        }

        public void MethodA()
        {
            Console.WriteLine("\nMethodA() ---- ");
            _one.methodOne();
            _two.methodTwo();
            _four.methodFour();
        }

        public void MethodB()
        {
            Console.WriteLine("\nMethodB() ---- ");
            _two.methodTwo();
            _three.methodThree();
        }
    }




}

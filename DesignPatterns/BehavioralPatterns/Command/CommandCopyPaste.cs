using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.BehavioralPatterns.Command
{//http://safakunel.blogspot.com/2013/11/c-command-pattern-kullanimi-oop-design.html
    class CommandCopyPaste
    {
        public static void Main(string[] args)
        {
            Invoker invoker = new Invoker();
            invoker.AddCommand(new UndoCommand());
            invoker.AddCommand(new UndoCommand());
            invoker.AddCommand(new RedoCommand());

            invoker.ExecuteAll();

            Console.ReadKey();
        }
    }

    public interface ICommand
    {
        void Execute();
    }

    // Concrete Command Class
    public class UndoCommand : ICommand
    {
        public void Execute()
        {
            Console.WriteLine("Undo command worked.");
        }
    }

    // Concrete Command Class
    public class RedoCommand : ICommand
    {
        public void Execute()
        {
            Console.WriteLine("Redo command worked.");
        }
    }

    public class Invoker
    {
        private Stack<ICommand> commandList = new Stack<ICommand>();

        public void ExecuteAll()
        {
            while (commandList.Count > 0)
            {
                commandList.Pop().Execute();
            }
        }

        public void AddCommand(ICommand c)
        {
            commandList.Push(c);
        }
    }












}

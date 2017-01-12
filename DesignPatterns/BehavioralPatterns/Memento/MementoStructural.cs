using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.BehavioralPatterns.Memento
{
    class MementoStructural
    {
        public static void Main(string[] args)
        {
            Originator o = new Originator();
            o.State = "On";

            // Store internal state
            Caretaker c = new Caretaker();
            c.Memento = o.CreateMemento();

            // Continue changing originator
            o.State = "Off";

            // Restore saved state
            o.SetMemento(c.Memento);

            Console.ReadKey();
        }
    }

    class Originator//:yaratıcı, fikir babası
    {
        private string _state;

        // Property
        public string State
        {
            get { return _state; }
            set
            {
                _state = value;
                Console.WriteLine("State: ", _state);
            }
        }

        // Creates memento 
        public Memento CreateMemento()
        {
            return (new Memento(_state));
        }

        // Restores original state
        public void SetMemento(Memento memnto)
        {
            Console.WriteLine("Restoring state...");
            State = memnto.State;
        }
    }

    // The 'Memento' class 
    class Memento
    {
        private string _state;

        public Memento(string state)
        {
            this._state = state;
        }

        // Gets or sets state
        public string State
        {
            get { return _state; }
        }
    }

    // The 'Caretaker' class Caretaker:bakıcı, yönetici
    class Caretaker
    {
        private Memento _memento;

        public Memento Memento
        {
            set { _memento = value; }
            get { return _memento; }
        }
    }



}

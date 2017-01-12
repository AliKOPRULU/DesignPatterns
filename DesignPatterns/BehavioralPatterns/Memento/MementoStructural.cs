using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.BehavioralPatterns.MementoS
{
    class MementoSStructural
    {
        public static void Main(string[] args)
        {
            Originator o = new Originator();
            o.State = "On";

            // Store internal state
            Caretaker c = new Caretaker();
            c.MementoS = o.CreateMementoS();

            // Continue changing originator
            o.State = "Off";

            // Restore saved state
            o.SetMementoS(c.MementoS);

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

        // Creates MementoS 
        public MementoS CreateMementoS()
        {
            return (new MementoS(_state));
        }

        // Restores original state
        public void SetMementoS(MementoS memnto)
        {
            Console.WriteLine("Restoring state...");
            State = memnto.State;
        }
    }

    // The 'MementoS' class 
    class MementoS
    {
        private string _state;

        public MementoS(string state)
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
        private MementoS _MementoS;

        public MementoS MementoS
        {
            set { _MementoS = value; }
            get { return _MementoS; }
        }
    }



}

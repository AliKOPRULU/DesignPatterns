using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.BehavioralPatterns.Mediator
{
    class MediatorChat
    {
        public static void Main(string[] args)
        {
            // Create chatroom
            Chatroom chatroom = new Chatroom();

            // Create participants and register them
            Participant George = new Beatle("George");
            Participant Paul = new Beatle("Paul");
            Participant Ringo = new Beatle("Ringo");
            Participant John = new Beatle("John");
            Participant Yoko = new NonBeatle("Yoko");

            chatroom.Register(George);
            chatroom.Register(Paul);
            chatroom.Register(Ringo);
            chatroom.Register(John);
            chatroom.Register(Yoko);

            // Chatting participants
            Yoko.Send("John", "Hi John!");
            Paul.Send("Ringo", "All you need is love");
            Ringo.Send("George", "My sweet Lord");
            Paul.Send("John", "Can't buy me love");
            John.Send("Yoko", "My sweet love");


            Console.ReadKey();
        }
    }

    abstract class AbstractChatroom
    {
        public abstract void Register(Participant participant);
        public abstract void Send(string from, string to, string message);
    }

    // The 'ConcreteMediator' class
    class Chatroom : AbstractChatroom
    {//Participant:katılımcı
        private Dictionary<string, Participant> _participants = new Dictionary<string, Participant>();

        public override void Register(Participant participant)
        {
            if (!_participants.ContainsValue(participant))
            {
                _participants[participant.Name] = participant;
            }
            participant.Chatroom = this;
        }

        public override void Send(string from, string to, string message)
        {
            Participant participant = _participants[to];
            if (participant != null)
            {
                participant.Receive(from, message);
            }
        }
    }

    // The 'AbstractColleague' class
    class Participant
    {
        private Chatroom _chatroom;
        private string _name;

        public Participant(string name)
        {
            this._name = name;
        }

        public string Name
        {
            get { return _name; }
        }

        public Chatroom Chatroom
        {
            set { _chatroom = value; }
            get { return _chatroom; }
        }

        // Sends message to given participant
        public void Send(string to, string message)
        {
            _chatroom.Send(_name, to, message);
        }

        // Receives message from given participant
        public virtual void Receive(string from, string message)
        {
            Console.WriteLine("{0} to {1}: '{2}' ", from, Name, message);
        }
    }

    // A 'ConcreteColleague' class
    class Beatle : Participant//Beatle:  	efsane ingiliz rock grubu beatles üyelerine verilen ad
    {
        public Beatle(string name) : base(name)
        {
        }

        public override void Receive(string from, string message)
        {
            Console.WriteLine("To a Beatle: ");
            base.Receive(from, message);
        }
    }


    class NonBeatle : Participant
    {
        public NonBeatle(string name) : base(name)
        {
        }

        public override void Receive(string from, string message)
        {
            Console.WriteLine("To a non-Beatle: ");
            base.Receive(from, message);
        }
    }

}

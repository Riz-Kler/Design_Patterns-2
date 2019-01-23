using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Mediator
{
    public class Person
    {
        public string Name;
        public Chatroom Room;
        private List<string> chatLog = new List<string>();

        public Person(string name)
        {
            Name = name;
        }

        public void Say(string message)
        {
            Room.Broadcast(Name, message);
        }

        public void PrivateMessage(string who, string message)
        {
            Room.Message(Name, who, message);
        }

        public void Receive(string sender, string message)
        {
            string s = $"{sender}: '{message}'";
            chatLog.Add(s);
            WriteLine($"[{Name}'s chat session] {s}");
        }
    }

    public class Chatroom      // central component that acts aa a mediator and allows people
                               // to communicate with each other withouyt knowinghtat they're present,
                               // e.g when you say something you say it to the whole room or send private message.
                               // If any participants drop out your messages are still valid they just don't go anywhere
    {
        private List<Person> people = new List<Person>();

        public void Join(Person p)
        {
            string joinMsg = $"{p.Name} joins the chat";
            Broadcast("room", joinMsg);

            p.Room = this;
            people.Add(p);
        }

        public void Broadcast(string source, string message)
        {
            foreach (var p in people)
                if (p.Name != source)
                    p.Receive(source, message);
        
        }

        public void Message(string source, string destination, string message)
        {                           // where
            people.FirstOrDefault(p => p.Name == destination) //Lambda
                ?.Receive(source, message);                   // connected
        }
    }

    class Mediator
    {
        static void Main(string[] args)
        {
            var room = new Chatroom();
            var riz = new Person("Riz");
            var cindy = new Person("Cindy");

            room.Join(riz);
            WriteLine($"{riz.Name} just joined the chat room");

            room.Join(cindy);
            WriteLine($"{cindy.Name} just joined the chat room");

            riz.Say("Hi Cindy!");
            cindy.Say("oh, hey Riz");

            cindy.PrivateMessage("Riz", "really nice to finally talk to you Riz");
            riz.PrivateMessage("Cindy", "Likewise Cindy");

            var john = new Person("John");
            room.Join(john);
            john.Say("hi everyone!");

            riz.PrivateMessage("John", "2's company 3's a crowd dude!");
        }
    }
}

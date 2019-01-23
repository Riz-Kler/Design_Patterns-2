using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using RxDemos.ImplementingObservable.Broker;
using Timer = System.Timers.Timer;
using static System.Console;

namespace EvenBroker //using reactive extensions
{

    public class Actor
    {
        protected EventBroker broker;

        public Actor(EventBroker broker)
        {
            this.broker = broker ?? throw new ArgumentNullException(nameof(broker));
        }
    }

    public class FootballPlayer : Actor
    {
        public FootballPlayer(EventBroker broker, string name) : base(broker)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            broker.OfType<PlayerScoredEvent>()
                .Where(ps => !ps.Name.Equals(name))
                .Subscribe(
                    ps => WriteLine($"{name}: Nicely done, {ps.Name}! It's your {ps.GoalsScored} goal")
                );

            broker.OfType<PlayerSentOffEvent>()
                .Where(pe => !pe.Name.Equals(name))
                .Subscribe(
                    pe => WriteLine($"{name}: Oh no, {pe.Name}! We're a man down because of your {pe.Reason} that's bad")
                );
        }

        public string Name { get; set; }
        public int GoalsScored { get; set; }

        public void Score()
        {
            GoalsScored++;
            broker.Publish(new PlayerScoredEvent {Name = Name, GoalsScored = GoalsScored});
        }

        public void AssaultReferee()
        {
            broker.Publish(new PlayerSentOffEvent {Name = Name, Reason = "violence"});
        }
    }

    public class FootballCoach : Actor
    {
        public FootballCoach(EventBroker broker) : base(broker)
        {
            broker.OfType<PlayerScoredEvent>()
                .Subscribe(pe =>
                {
                    if (pe.GoalsScored < 3)
                        WriteLine($"Coach: well done, {pe.Name}!");
                });
            broker.OfType<PlayerSentOffEvent>()
                .Subscribe(pe =>
            {
                if (pe.Reason == "violence")
                    WriteLine($"Coach: how could you, {pe.Name}.");
            });
        }
    }

    public class PlayerEvent
    {
        public String Name { get; set; }
    }

    public class PlayerScoredEvent : PlayerEvent
    {
        public int GoalsScored { get; set; }
    }
    public class PlayerSentOffEvent : PlayerEvent
    {
        public string Reason { get; set; }          
    }
    
    public class EventBroker : IObservable<PlayerEvent>
    {
        private Subject<PlayerEvent> subscriptions = new Subject<PlayerEvent>();
        public IDisposable Subscribe(IObserver<PlayerEvent> observer)
        {
           return subscriptions.Subscribe(observer);
        }

        public void Publish(PlayerEvent pe)
        {
            subscriptions.OnNext(pe);
        }
    }


    class RxSamples
    {
        static void Main(string[] args)
        {// DI using a container builder
            var cb = new ContainerBuilder();
            cb.RegisterType<EventBroker>().SingleInstance();
            cb.RegisterType<FootballCoach>();
            cb.Register((c,p) =>
                new FootballPlayer(
                    c.Resolve<EventBroker>(),
                    p.Named<string>("name")
                    ));
            //        cb.RegisterType<FootballPlayer>(); doesn't work

            using (var c = cb.Build())
            {
                var coach = c.Resolve<FootballCoach>();
                var player1 = c.Resolve<FootballPlayer>(new NamedParameter("name", "Riz"));
                var player2 = c.Resolve<FootballPlayer>(new NamedParameter("name", "John"));

                player1.Score();
                player1.Score();
     

                player2.Score();
                player2.Score();
                player2.AssaultReferee();
                player1.Score();

            }

        }
    }
}

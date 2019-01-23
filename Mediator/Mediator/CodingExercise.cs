using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding.Exercise
{
    public class Participant
    {
        private readonly Mediator mediator;
        public int Value { get; set; }

        public Participant(Mediator mediator)
        {
            this.mediator = mediator;
            mediator.Alarm += Mediator_Alarm;

        }

        private void Mediator_Alarm(Object sender, int e)
        {
            if (sender != this)
                Value += e;

        }
        public void Say(int n)
        {
            mediator.Broadcast(this, n);     // this is the relative global variable
        }
    }

    public class Mediator
    {
        public void Broadcast(Participant participant, int n)
        {
            Alarm?.Invoke(participant, n);     // the event handler sneds the Say(Value to all participants except the sender)
        }

        public event EventHandler<int> Alarm;
    }
}


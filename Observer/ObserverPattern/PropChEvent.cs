using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using ObserverPattern.Annotations;

//using RxSamples.Annotations;

namespace Observerpattern  // Using Procedures and Sequences through Reactive Extensions
{
    public class Market : INotifyPropertyChanged
    {
        private float volatility;

        public float Volatility
        {
            get => volatility;
            set
            {
                if (value.Equals(volatility)) return;
                volatility = value;
                OnPropertyChanged();
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    class PrChEvent
    {
        //static void Main(string[] args)
        //{
        //    var marhet = new Market();
        //    marhet.PropertyChanged += (sender, eventArgs) =>
        //    {
        //        if (eventArgs.PropertyName == "Volatility")
        //        {

        //        }
        //    };

       // }
    }
}

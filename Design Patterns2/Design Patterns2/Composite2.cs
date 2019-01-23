using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using Autofac;
//using MoreLinq;
using NUnit.Framework;
using static System.Console;



namespace Design_Patterns2
{
    public static class ExtensionMethods
    {
        public static void ConnectTo(this IEnumerable<Neuron> self,
            IEnumerable<Neuron> other)
        {
            if (ReferenceEquals(self, other)) return;

            foreach (var from in self)
            foreach (var to in other)
            {
                from.Out.Add(to);
                to.In.Add(from);
            }
        }
    }


    public class Neuron : IEnumerable<Neuron>
    {
        private float Value;
        public List<Neuron> In, Out;

  //      public void ConnectionTo(Neuron other)
  //      {
  //          Out.Add(other);
  //          other.In.Add(this);
  //      }

        public IEnumerator<Neuron> GetEnumerator()
        {
            yield return this;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public class NeuronLayer : Collection<Neuron>
    {
    }
    static class Composite2
    {
        static void Main(string[] args)
        {
            var neuron1 = new Neuron();
            var neuron2 = new Neuron();

            neuron1.ConnectTo(neuron2);

            var layer1 = new NeuronLayer();
            var layer2 = new NeuronLayer();

            neuron1.ConnectTo(layer1);
            layer1.ConnectTo(layer2);
        }



    }
}

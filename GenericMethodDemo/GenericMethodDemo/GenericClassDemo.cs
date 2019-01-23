using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericClassDemo
{
    class Node
    {
        String key;
        String data;

        public Node(String keyValue, String dataValue)
        {
            key = keyValue;
            data = dataValue;
        }

        public String GetKey()
        {
            return key;
        }

        public String GetData()
        {
            return data;
        }
    }

    class MyGenericClass<T>
    {
        private T info;

        public void SetInfo(T value)
        {
            info = value;
        }

        public T GetInfo()
        {
            return info;
        }
    }

        class GenericClassDemo
        {
            static void Main(string[] args)
            {
                MyGenericClass<int> obj1 = new MyGenericClass<int>();

                obj1.SetInfo(10);
                Console.WriteLine("Info = " + obj1.GetInfo());

                MyGenericClass<Boolean> obj2 = new MyGenericClass<bool>();

                obj2.SetInfo(true);
                Console.WriteLine("Info = " + obj2.GetInfo());

                MyGenericClass<String> obj3 = new MyGenericClass<String>();

                obj3.SetInfo("Example of generic class");
                Console.WriteLine("Info = " + obj3.GetInfo());

                MyGenericClass<Node> obj = new MyGenericClass<Node>();
                Node nodeData = new Node("007", "James Bond");

                obj.SetInfo(nodeData);
                Console.WriteLine("Key = " + obj.GetInfo().GetKey() + ", Data = " + obj.GetInfo().GetData());
            }
         }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Collections;

namespace MultiThreading
{
    struct Data
    {
        public static ArrayList data = new ArrayList();
    }
    class A
    {
        public void Method1()
        {
            lock (Data.data)
                lock (Data.data)
                {
                    for (int i = 0; i < 20000; i++)
                    {
                        if (i % 1000 == 0)
                            Data.data.Add(i + 1);
                    }
                }
        }
    }
    class B
    {
        public void Method2()
        {
            lock (Data.data)
                lock (Data.data)
                {
                    for (int i = 0; i < 20000; i++)
                    {
                        if (i % 1000 == 0)
                            Data.data.Add(i + 2);
                    }
                }
        }
    }
    class ThreadLockDemo
    {
        static void Main(string[] args)
        {
            A obj1 = new A();
            B obj2 = new B();
   //         C obj3 = new C();

            Thread threadObj1 = new Thread(new ThreadStart(obj1.Method1));
            Thread threadObj2 = new Thread(new ThreadStart(obj2.Method2));
            //          Thread threadObj3 = new Thread(new ThreadStart(obj3.Method3));

            threadObj1.Start();
 //           Thread.Sleep(1000);
            threadObj2.Start();

            threadObj1.Join();
            threadObj2.Join();

            //           threadObj3.Start();
            foreach (int num in Data.data)
                Console.WriteLine("{0}", num);

            Console.WriteLine("End of Main()");

        }
    }
}

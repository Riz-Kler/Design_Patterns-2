//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading;

//namespace MultiThreading
//{
//        class A
//        {
//            public void Method1()
//            {
//                for (int i = 0; i < 20000; i++)
//                {
//                    if (i % 1000 == 0)
//                        Console.WriteLine("Inside A::Method1() : {0}", i);
//                }

//                Console.WriteLine("Thread Name = {0}", Thread.CurrentThread.Name);
//                Console.WriteLine("IsAlive = {0}", Thread.CurrentThread.IsAlive);
//                Console.WriteLine("Priority = {0}", Thread.CurrentThread.Priority);
//                Console.WriteLine("State = {0}", Thread.CurrentThread.ThreadState);
//            }
//        }

//        class B
//        {
//            public void Method2()
//            {
//                for (int i = 0; i < 20000; i++)
//                {
//                    if (i % 1000 == 0)
//                        Console.WriteLine("Inside A::Method2() : {0}", i);
//                }

//                Console.WriteLine("Thread Name = {0}", Thread.CurrentThread.Name);
//                Console.WriteLine("IsAlive = {0}", Thread.CurrentThread.IsAlive);
//                Console.WriteLine("Priority = {0}", Thread.CurrentThread.Priority);
//                Console.WriteLine("State = {0}", Thread.CurrentThread.ThreadState);
//            }
//        }

//        class C
//        {
//            public void Method3()
//            {
//                for (int i = 0; i < 20000; i++)
//                {
//                    if (i % 1000 == 0)
//                        Console.WriteLine("Inside A::Method3() : {0}", i);
//                }

//                Console.WriteLine("Thread Name = {0}", Thread.CurrentThread.Name);
//                Console.WriteLine("IsAlive = {0}", Thread.CurrentThread.IsAlive);
//                Console.WriteLine("Priority = {0}", Thread.CurrentThread.Priority);
//                Console.WriteLine("State = {0}", Thread.CurrentThread.ThreadState);
//            }
//        }
//    class ThreadPropertiesDemo
//    {
//        static void Main(string[] args)
//        {

//            A obj1 = new A();
//            B obj2 = new B();
//            C obj3 = new C();

//            Thread threadObj1 = new Thread(new ThreadStart(obj1.Method1));
//            Thread threadObj2 = new Thread(new ThreadStart(obj2.Method2));
//            Thread threadObj3 = new Thread(new ThreadStart(obj3.Method3));

//            Thread mainThreadObj = Thread.CurrentThread;

//            mainThreadObj.Name = "Main Thread";
//            threadObj1.Name = "Thread 1";
//            threadObj2.Name = "Thread 2";
//            threadObj3.Name = "Thread 3";

//            Console.WriteLine("Thread Name = {0}", Thread.CurrentThread.Name);
//            Console.WriteLine("IsAlive = {0}", Thread.CurrentThread.IsAlive);
//            Console.WriteLine("Priority = {0}", Thread.CurrentThread.Priority);
//            Console.WriteLine("State = {0}", Thread.CurrentThread.ThreadState);

//            threadObj1.Priority = ThreadPriority.Lowest;
//            threadObj2.Priority = ThreadPriority.Normal;
//            threadObj3.Priority = ThreadPriority.Highest;


//            threadObj1.Start();
//            Thread.Sleep(1000);
//            threadObj2.Start();
//  //          Thread.Sleep(1000);
//  //          threadObj3.Start();

// //           threadObj1.Join();
// //           threadObj2.Join();
// //           threadObj3.Join();

// //           Console.WriteLine("Thread Name = {0}, IsAlive = {1}", Thread.CurrentThread.Name, Thread.CurrentThread.IsAlive);
// //           Console.WriteLine("Thread Name = {0}, IsAlive = {1}", threadObj1.Name, threadObj1.IsAlive);
////            Console.WriteLine("Thread Name = {0}, IsAlive = {1}", threadObj2.Name, threadObj2.IsAlive);
////            Console.WriteLine("Thread Name = {0}, IsAlive = {1}", threadObj3.Name, threadObj3.IsAlive);

//            Console.WriteLine("End of Main()");
//        }
//    }
//}

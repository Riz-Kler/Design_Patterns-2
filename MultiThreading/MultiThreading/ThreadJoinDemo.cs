//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading;

//namespace MultiThreading
//{
//    class A
//    {
//        public void Method1()
//        {
//            for (int i = 0; i < 20000; i++)
//            {
//                if (i % 1000 == 0)
//                    Console.WriteLine("Inside A::Method1() : {0}", i);
//            }
//        }
//    }

//    class B
//    {
//        public void Method2()
//        {
//            for (int i = 0; i < 20000; i++)
//            {
//                if (i % 1000 == 0)
//                    Console.WriteLine("Inside B::Method2() : {0}", i);
//            }
//        }
//    }

//    class C
//    {
//        public void Method3()
//        {
//            for (int i = 0; i < 20000; i++)
//            {
//                if (i % 1000 == 0)
//                    Console.WriteLine("Inside C::Method3() : {0}", i);
//            }
//        }
//    }
//    class ThreadJoinDemo
//    {
//        static void Main(string[] args)
//        {
//            A obj1 = new A();
//            B obj2 = new B();
//            C obj3 = new C();

//            Thread threadObj1 = new Thread(new ThreadStart(obj1.Method1));
//            Thread threadObj2 = new Thread(new ThreadStart(obj2.Method2));
//            Thread threadObj3 = new Thread(new ThreadStart(obj3.Method3));


//            threadObj1.Start();
//            threadObj2.Start();
//            threadObj3.Start();

//            threadObj1.Join();
//  //          threadObj2.Join();
//   //         threadObj3.Join();

//            Console.WriteLine("End of Main()");


//        }
//    }
//}

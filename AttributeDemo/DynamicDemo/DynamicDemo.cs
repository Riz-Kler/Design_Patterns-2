using System;
using System.Dynamic;

namespace DynamicDemo
{
    class DynamicDemo
    {
        class MyClass
        {
            public void Method1()
            {
                Console.WriteLine("Inside MyClass::Method1()");
            }

            public void Method2()
            {
                Console.WriteLine("Inside MyClass::Method2()");
            }
            static void Main(string[] args)
            {
                MyClass myclassObj1 = new MyClass();
                myclassObj1.Method1();
                              myclassObj1.Method2();

                dynamic myclassObj2 = new MyClass();
                myclassObj2.Method1();
                myclassObj2.Method2 ();

            }
        }
    }
}

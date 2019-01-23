using System;
using System.Reflection;

// To demonstrate getting Constructor information

namespace ReflectionConstructorInfoDemo
{
    class MyClass
    {
        public int data;
        public String name;

        public MyClass(int data, String name) { }
        public void Method1() { }
        public int Method2(int value) { return value; }
    }
    class ReflectionConstructorInfoDemo
    {
        static void Main(string[] args)
        {
            Type t = Type.GetType("ReflectionConstructorInfoDemo.MyClass"); // set the type to the namespace and class name

            ConstructorInfo[] cons = t.GetConstructors(); //gets all the onstructords in the namespace and class given above

            foreach (ConstructorInfo c in cons)
            {
                Console.WriteLine("Name : " + c.Name);
                Console.WriteLine("DeclaringType : " + c.DeclaringType);
                Console.WriteLine("MemberType : " + c.MemberType);

                ParameterInfo[] param = c.GetParameters();
                foreach (ParameterInfo p in param)
                {
                    Console.WriteLine("Parameter Name : " + p.Name);
                    Console.WriteLine("Type : " + p.ParameterType);
                }
            }
        }
    }
}

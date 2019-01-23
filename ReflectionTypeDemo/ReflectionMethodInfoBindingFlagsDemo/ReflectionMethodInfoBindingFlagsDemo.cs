using System;
using System.Reflection;

// To demonstrate getting method information using BindingFlags

namespace ReflectionMethodInfoBindingFlagsDemo
{
    class MyClass
    {
        public int data;
        public String name;

        public MyClass(int data, String name) { }
        public void Method1() { }
        public int Method2(int value) { return value; }
        private void Method3() { }
    }
    class ReflectionMethodInfoBindingFlagsDemo
    {
        static void Main(string[] args)
        {
            Type t = Type.GetType("ReflectionMethodInfoBindingFlagsDemo.MyClass"); // set the type to the namespace and class name

            MethodInfo[] methods = t.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic); //gets all the methods in the namespace and class given above using BindingFlags

            foreach (MethodInfo m in methods)
            {
                Console.WriteLine("Name : " + m.Name);
                Console.WriteLine("DeclaringType : " + m.DeclaringType);
                Console.WriteLine("MemberType : " + m.MemberType +"\n");
                //       Console.WriteLine("FieldType : " + p.FieldType + "\n");
            }
        }
    }
}

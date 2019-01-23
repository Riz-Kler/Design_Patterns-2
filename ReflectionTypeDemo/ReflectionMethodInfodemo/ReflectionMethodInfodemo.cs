using System;
using System.Reflection;

// To demonstrate getting method information

namespace ReflectionMethodInfoDemo
{
    class MyClass
    {
        public int data;
        public String name;

        public MyClass(int data, String name) { }

        public int Data
        {
            get { return data; }
            set { data = value; }
        }

        public String Name
        {
            get { return name; }
            set { name = value; }
        }

        public void Method1() { }
        public int Method2(int value) { return value; }
    }
    class ReflectionMethodInfoDemo
    {
        static void Main(string[] args)
        {
            Type t = Type.GetType("ReflectionMethodInfoDemo.MyClass"); // set the type to the namespace and class name

            MethodInfo[] methods = t.GetMethods(); //gets all the fields in the namespace and class given above

            foreach (MethodInfo m in methods)
            {
                Console.WriteLine("Name : " + m.Name);
                Console.WriteLine("DeclaringType : " + m.DeclaringType);
                Console.WriteLine("MemberType : " + m.MemberType);
         //       Console.WriteLine("FieldType : " + p.FieldType + "\n");
            }
        }
    }
}

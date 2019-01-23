using System;
using System.Reflection;

// To demonstrate getting property information

namespace ReflectionPropertyInfoDemo
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
    class ReflectionPropertyInfoDemo
    {
        static void Main(string[] args)
        {
            Type t = Type.GetType("ReflectionPropertyInfoDemo.MyClass"); // set the type to the namespace and class name

            PropertyInfo [] properties = t.GetProperties(); //gets all the fields in the namespace and class given above

            foreach (PropertyInfo p in properties)
            {
                Console.WriteLine("Name : " + p.Name);
                Console.WriteLine("DeclaringType : " + p.DeclaringType);
                Console.WriteLine("MemberType : " + p.MemberType);
                Console.WriteLine("FieldType : " + p.PropertyType + "\n");
            }
        }
    }
}

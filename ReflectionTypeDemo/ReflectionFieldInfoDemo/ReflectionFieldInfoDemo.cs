using System;
using System.Reflection;

//To Demonstrate getting field information
namespace ReflectionMembersInfoDemo
{

    class MyClass
    {
        public int data;
        public String name;

        public MyClass(int data, String name) { }
        public void Method1() { }
        public int Method2(int value) { return value; }
  //      private void Method3() { }
    }
    class ReflectionMembersInfoDemo
    {
        static void Main(string[] args)
        {
            Type t = Type.GetType("ReflectionMembersInfoDemo.MyClass"); //namespace and class name

            FieldInfo[] fields = t.GetFields(); //gets all the fields in the namespace and class given above

            foreach (FieldInfo f in fields)
            {
                Console.WriteLine("Name : " + f.Name);
                Console.WriteLine("DeclaringType : " + f.DeclaringType);
                Console.WriteLine("MemberType : " + f.MemberType);
                Console.WriteLine("FieldType : " + f.FieldType + "\n");
            }
        }
    }
}

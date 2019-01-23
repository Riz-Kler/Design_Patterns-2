using System;
using System.Reflection;

//To demonstrate getting member information

namespace ReflectionMembersInfoDemo
{   
    class MyClass
    {
        public int data;
        public String name;

        public MyClass(int data, String name) { }
        public void Method1() { }
        public int Method2(int value) { return value; }
        private void Method3() {  }
    }
    class ReflectionMembersInfoDemo
    {
        static void Main(string[] args)
        {
            Type t = Type.GetType("ReflectionMembersInfoDemo.MyClass"); //namespace and class name

            MemberInfo[] members = t.GetMembers(); //gets all the public members in the namespace and class given above

            foreach (MemberInfo m in members)
            {
                Console.WriteLine("Name : " + m.Name);
                Console.WriteLine("DeclaringType : " + m.DeclaringType);
                Console.WriteLine("MemberType : " + m.MemberType + "\n");
            }
        }
    }
}

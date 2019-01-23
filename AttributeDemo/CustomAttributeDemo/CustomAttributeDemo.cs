using System;
using System.Reflection;

// To Demonstrate the Custom Attribute

namespace CustomAttributeDemo
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
    class AuthorInfoAttribute : Attribute
    {
        public String author;
        public String creationDate;
        public String comments;

        public AuthorInfoAttribute(String authorName)
        {
            author = authorName;
        }

        public String Author
        {
            get
            {
                return author;
            }
        }

        public String CreationDate
        {
            get
            {
                return creationDate;
            }

            set
            {
                creationDate = value;
            }
        }

        public String Comments
        {
            get
            {
                return comments;
            }

            set
            {
                comments = value;
            }
        }

    }

    [AuthorInfo("Riz Kler")] //positional parameter
    class DeviceManager
    {
        [AuthorInfo("Riz Kler", CreationDate = "25-Feb-2018")]
        public void Configure()
        {

        }

        [AuthorInfo("Riz Kler", CreationDate = "25-Feb-2018", Comments = "This method will do operations")]
        public void DoOperation()
        {
        }
    }
    class CustomAttributeDemo
    {
        static void Main(string[] args)
        {
            Type t = Type.GetType("CustomAttributeDemo.DeviceManager"); //namespace dot classname as parameter

            AuthorInfoAttribute attr;

            //Getting class attributes
            attr = (AuthorInfoAttribute)Attribute.GetCustomAttribute(t, typeof(AuthorInfoAttribute));

            if (attr != null)
            {
                Console.WriteLine("Class Name : {0}", t.ToString());
                Console.WriteLine("Author Name : {0}", attr.Author);
                Console.WriteLine("Creation Date : {0}", attr.CreationDate);
                Console.WriteLine("Comments : {0}", attr.Comments);
            }

            MethodInfo[] methods = t.GetMethods();

            foreach (MethodInfo m in methods)
            {
                //Getting method attributes
                attr = (AuthorInfoAttribute)Attribute.GetCustomAttribute(t, typeof(AuthorInfoAttribute));

                if (attr != null)
                {
                    Console.WriteLine("Method Name : {0}", m.Name);
                    Console.WriteLine("Author Name : {0}", attr.Author);
                    Console.WriteLine("Creation Date : {0}", attr.CreationDate);
                    Console.WriteLine("Comments : {0}", attr.Comments);
                }
            }

        }
    }
}

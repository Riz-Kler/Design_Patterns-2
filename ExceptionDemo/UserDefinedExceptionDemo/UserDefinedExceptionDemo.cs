using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserDefinedExceptionDemo
{
    class UserException : ApplicationException
    {
        private String message;

        public UserException(String msg)
        {
            message = msg;
        }


        public override String ToString()
        {
            String formattedMessage = "Error1001 : " + message;
            return formattedMessage;
        }
    }

    class UserDefinedExceptionDemo
    {
        static void Display()
        {
            try
            {
                throw new UserException("This is a user defined exception");
            }
            catch (UserException e)
            {
                Console.WriteLine("Inside catch block to handle the UserException");
                Console.WriteLine(e);
            }
        }

        static void Main(string[] args)
        {
            Display();
        }
    }
}

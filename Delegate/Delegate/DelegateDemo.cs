using System;
using System.IO;

namespace DelegateDemo
{
    public delegate String OperationDelegate(String command);

    class ComputerSystem
    {
        public String StartApplication(String appName)
        {
            Console.Write("Inside ComputerSystem::StartApplication()\n");

            return "Success";
        }

        public String StopApplication(String appName)
        {
            Console.Write("Inside ComputerSystem::StopApplication()\n");

            return "Success";
        }

        public String InstallSoftware(String software)
        {
            Console.Write("Inside ComputerSystem::InstallSoftware()\n");

            return "Success";
        }

        public String UnInstallSoftware(String software)
        {
            Console.Write("Inside ComputerSystem::UnInstallSoftware()\n");

            return "Success";
        }

        public void Operation(String name, OperationDelegate oprDelegate)
        {
            Console.WriteLine("Result = {0}", oprDelegate(name));
        }
    }

    class DelegateDemo
    {
        static void Main(string[] args)
        {
            ComputerSystem compsysObj = new ComputerSystem();

            //Use of delegate
            OperationDelegate oprDelegate = new OperationDelegate(compsysObj.InstallSoftware);
            Console.WriteLine("Result = {0}", oprDelegate("MyApplication"));

            oprDelegate = new OperationDelegate(compsysObj.StartApplication);
            Console.WriteLine("Result = {0}", oprDelegate("MyApplication"));

            oprDelegate = new OperationDelegate(compsysObj.StopApplication);
            Console.WriteLine("Result = {0}", oprDelegate("MyApplication"));

            oprDelegate = new OperationDelegate(compsysObj.UnInstallSoftware);
            Console.WriteLine("Result = {0}", oprDelegate("MyApplication"));

            //Pasing delegate in method
            oprDelegate = new OperationDelegate(compsysObj.StartApplication);
            Console.WriteLine("Passing delegate in method");
            compsysObj.Operation("MyApplication", oprDelegate);

        }
    }
}

    


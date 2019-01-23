using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;

namespace MulticastDelegateDemo
{
    public delegate void OperationMulticastDelegate();

    class DataCentre
    {
        private Server server;
        private Printer printer;
        private CoolingSystem coolingSystem;

        private OperationMulticastDelegate opr;

        public DataCentre()
        {
            server = new Server();
            printer = new Printer();
            coolingSystem = new CoolingSystem();
        }

        public void Start()
        {
            opr = new OperationMulticastDelegate(server.Start);
            opr += new OperationMulticastDelegate(printer.Start);
            opr += new OperationMulticastDelegate(coolingSystem.Start);

            opr();

            opr -= new OperationMulticastDelegate(server.Start);
            opr -= new OperationMulticastDelegate(printer.Start);
            opr -= new OperationMulticastDelegate(coolingSystem.Start);
        }

        public void Stop()
        {
            opr = new OperationMulticastDelegate(server.Shutdown);
            opr += new OperationMulticastDelegate(printer.Stop);
            opr += new OperationMulticastDelegate(coolingSystem.Stop);

            opr(); // invoking the method

            opr -= new OperationMulticastDelegate(server.Shutdown);
            opr -= new OperationMulticastDelegate(printer.Stop);
            opr -= new OperationMulticastDelegate(coolingSystem.Stop);
        }
    }

    class Server
    {
        public void Start()
        {
            Console.Write("Inside Server::Start()\n");
        }

        public void Shutdown()
        {
            Console.Write("Inside Server::Stop()\n");
        }
    }

    class Printer
    {
        public void Start()
        {
            Console.Write("Inside Printer::Start()\n");
        }


        public void Stop()
        {
            Console.Write("Inside Printer::Stop()\n");
        }
    }

    class CoolingSystem
    {
        public void Start()
        {
            Console.Write("Inside CoolingSystem::Start()\n");
        }

        public void Stop()
        {
            Console.Write("Inside CoolingSystem::Stop()\n");
        }
    }


    class MulticastDelegateDemo
    {
        static void Main(string[] args)
        {
            DataCentre dcObj = new DataCentre();
            Console.Write("Starting Data Centre\n");
            dcObj.Start();

            Console.Write("Stopping Data Centre\n");
            dcObj.Stop();
        }
    }
}

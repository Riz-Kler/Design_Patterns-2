using System;
using IronPython.Hosting;
using System.Dynamic;
using Microsoft.Scripting;
using Microsoft.Scripting.Hosting;

namespace PythonDemo5
{
    class PythonDemo5
    {
        static void Main(string[] args)
        {
            dynamic pyInst = Python.CreateRuntime().UseFile(@"..\..\..\Device.py");
            dynamic sysObj = pyInst.GetHPSystem("HPSystem001", "High", 16);
            dynamic printerObj = pyInst.GetHPPrinter("HPPrinter001", "Inkjet");

            Console.WriteLine("HP System Information =>"); ;
            Console.WriteLine("Id : {0}, Type : {1}, Processor : {2}", sysObj.GetId(), sysObj.GetType(), sysObj.GetProcessor());
            Console.WriteLine("HP Printer Information =>");
            Console.WriteLine("Id : {0}, Type : {1}", printerObj.GetId(), printerObj.GetType());
        }
    }
}

using System;
using IronPython.Hosting;
using Microsoft.Scripting;
using Microsoft.Scripting.Hosting;

namespace PythonDemo4
{
    class PythonDemo4
    {
        static void Main(string[] args)
        {
            dynamic pyInst = Python.CreateRuntime().UseFile(@"..\..\..\adder.py");

            dynamic value = pyInst.add(3, 2);
            Console.WriteLine("add(3, 2) : " + value);

            value = pyInst.add("Hello", "World");
            Console.WriteLine("add('Hello', 'World') : " + value);

        }
    }
}

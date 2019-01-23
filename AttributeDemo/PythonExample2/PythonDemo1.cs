using System;
using IronPython.Hosting;
using Microsoft.Scripting;
using Microsoft.Scripting.Hosting;

namespace PythonExample2
{
    class PythonDemo1
    {
        static void Main(string[] args)
        {
            ScriptEngine engine = Python.CreateEngine();
            dynamic value = engine.Execute("10 + 20");
            Console.WriteLine("10 + 20 = " + value);

            value = engine.Execute("10 * 20");
            Console.WriteLine("10 * 20 = " + value);
        }
    }
}

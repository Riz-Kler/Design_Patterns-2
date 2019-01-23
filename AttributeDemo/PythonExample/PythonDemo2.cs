using System;
using IronPython.Hosting;
using Microsoft.Scripting;
using Microsoft.Scripting.Hosting;

namespace PythonExample
{
    class PythonDemo2
    {
        static void Main(string[] args)
        {
            ScriptEngine engine = Python.CreateEngine();

            String stmt = "value = x + y";
            ScriptScope scope = engine.CreateScope();
            scope.SetVariable("x", 10);
            scope.SetVariable("y", 20);

            ScriptSource source = engine.CreateScriptSourceFromString(stmt, SourceCodeKind.SingleStatement);
            source.Execute(scope);
            Console.WriteLine("value = " + scope.GetVariable("value"));
        }
    }
}

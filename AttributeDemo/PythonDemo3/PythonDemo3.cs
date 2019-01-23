using System;
using IronPython.Hosting;
using Microsoft.Scripting;
using Microsoft.Scripting.Hosting;

namespace PythonDemo3
{
    class PythonDemo3
    {
        ScriptEngine engine = Python.CreateEngine();
        static void Main(string[] args)
        {
            ScriptEngine engine = Python.CreateEngine();

            String stmt = "str3 = str1 + str2";
            ScriptScope scope = engine.CreateScope();
            scope.SetVariable("str1", "Python");
            scope.SetVariable("str2", " with C#");

            ScriptSource source = engine.CreateScriptSourceFromString(stmt, SourceCodeKind.SingleStatement);
            source.Execute(scope);
            Console.WriteLine(scope.GetVariable("str3"));

        }
    }
}

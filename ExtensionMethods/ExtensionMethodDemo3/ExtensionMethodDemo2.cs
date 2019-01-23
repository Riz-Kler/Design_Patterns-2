using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure;

//Extension Method with a class

namespace ExtensionMethodDemo2
{
    using InfrastructureTools;

    class ExtensionMethodDemo2
    {
        static void Main(string[] args)
        {
            DataCenter dcObj = new DataCenter();
            Console.WriteLine("Using Extension Method, dcObj.Restart()");
            dcObj.Restart();
            Console.WriteLine("Using Extension Method, DataCenterTools.Restart()");
            DataCenterTools.Restart(dcObj);
        }
    }
}

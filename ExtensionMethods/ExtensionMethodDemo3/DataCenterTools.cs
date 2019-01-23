using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure;

namespace InfrastructureTools
{
    static class DataCenterTools
    {
        public static void Restart(this DataCenter obj)
        {
            Console.WriteLine("Inside DataCenter::Restart()");
            obj.Stop();
            obj.Start();
        }
    }   
    
}

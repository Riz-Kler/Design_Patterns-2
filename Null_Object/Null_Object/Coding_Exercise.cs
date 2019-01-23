using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding.Exercise
{
    public interface ILog
    {
        // maximum # of elements in the log
        int RecordLimit { get; }

        // number of elements already in the log
        int RecordCount { get; set; }

        // expected to increment RecordCount
        void LogInfo(string message);
    }

    public class Account // : NullLog
    {
             private ILog log;
       // private int log;

        //      public Account(ILog log) // Tightly coupled to ILog

        public Account(ILog log)
        {
            this.log = log;
        }

        public void SomeOperation() // Breaks SRP
        {
            //var log = new NullLog();

            //int d = log.RecordCount;
            //    log.LogInfo("Performing an operation");

            //if (d + 1 != log.RecordCount)
            //{

            //}

            //if (log.RecordCount >= log.RecordLimit)
            //{

            //}

            int c = log.RecordCount;
            log.LogInfo("Performing an operation");
            if (c + 1 != log.RecordCount)
                throw new Exception();
            if (log.RecordCount >= log.RecordLimit)
                throw new Exception();
        }
    }

    public class NullLog : ILog
    {
        // todo
        public int RecordLimit { get; } = int.MaxValue;
        public int RecordCount { get; set; } = int.MinValue;
        public void LogInfo(string message)
        {
       //     throw new NotImplementedException();
            ++RecordCount;
        }
    }
}
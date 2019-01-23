using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotNetDesignPatternDemos.Behavioral.NullObject;
using static System.Console;
using System.Dynamic;
using Autofac;
using Hangfire.Annotations;
using ImpromptuInterface;    // Uses DLR Dynamic Language Runtime

namespace Null_Object
{
    public interface ILog
    {
        void Info(string msg);
        void Warn(string wrn);

    }

    public class ConsoleLog : ILog
    {
        public void Info(string msg)
        {
            WriteLine(msg);
        }

        public void Warn(string wrn)
        {
            WriteLine("WARNING ! ! !");
        }
    }

    public class BankAccount
    {
        private ILog log;
        private int balance;


        public BankAccount(ILog log)  //DI     tried this [CanBeNull] but no hin to use.
        {
            this.log = log ?? throw new ArgumentNullException(nameof(log));
        }

        public void Deposit(int amount)
        {
            balance += amount;
            log.Info($"Deposited {amount}, balance is now {balance}");
        }
    }

    public class NullLog : ILog // Null Object conforms to the interface. Not always safe to use Null Object
    {
        public void Info(string msg)
        {
         //   throw new NotImplementedException();
            // you leave this empty so the memebers are not implementing anything
        }

        public void Warn(string wrn)
        {
            //     throw new NotImplementedException();
            // you leave this empty so the memebers are not implementing anything
        }
    }

    public class Null<TInterface> : DynamicObject where TInterface : class
    {                                                               //ImpromptuInterface allows you to do this... converted to expression body
        public static TInterface Instance => new Null<TInterface>().ActLike<TInterface>();

        // Need to make sure that any invocations do nothin gat all

        public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result)
        {
            result = Activator.CreateInstance(binder.ReturnType);
            return true;  // base.TryInvokeMember(binder, args, out result);
        }
    }                                                                

    class Null_Object
    {
        static void Main(string[] args)
        {

            var log = Null<ILog>.Instance;
            log.Info("eqfdjenfew");     // Nothing happens as thr Null Object Doesn't return anything
            var ba = new BankAccount(log);
            ba.Deposit(100);
            //    //       var log = new ConsoleLog();
            //    //       var ba = new BankAccount(log); //  Open Closed Principle cannot go back into BankAccount
            //     //      ba.Deposit(100);

            //           var cb = new ContainerBuilder();
            //           cb.RegisterType<BankAccount>();
            //           cb.RegisterType<NullLog>();
            ////           cb.RegisterInstance((ILog) null);   This will not work so we need something else
            //  //         cb.Register(ctx => new BankAccount(null)); // this will work
            //           using (var c = cb.Build( ))
            //           {
            //               var ba = c.Resolve<BankAccount>();
            //               ba.Deposit(100);
            //           }
        }       // This is how you implement the Null Object Pattern
    }
}

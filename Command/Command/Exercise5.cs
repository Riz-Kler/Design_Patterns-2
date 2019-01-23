using NUnit.Framework;
using System;
using System.Diagnostics;

namespace Coding.Exercise
{
    public class Command
    {
        public enum Action
        {
            Deposit,
            Withdraw
        }

        public Action TheAction;
        public int Amount;
        public bool Success;
    }

    public class Account
    {
        public int Balance { get; set; }

        public void Process(Command c)
        {
            switch (c.TheAction)
            {
                case Command.Action.Deposit:
                    Balance += c.Amount;
                    c.Success = true;
                    break;

                case Command.Action.Withdraw:
                    if (c.Amount >= Balance)
                    {
                        Balance -= c.Amount;
                        c.Success = true;
                    }
                   // c.Success = false;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}


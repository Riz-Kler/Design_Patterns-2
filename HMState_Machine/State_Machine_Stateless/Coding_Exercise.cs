using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Coding.Exercise
{
    public class CombinationLock
    {
        public enum State
        {
            Locked,
            Failed,
            Unlocked
        }

        public CombinationLock(int[] combination)
        {
            var state = State.Locked;

        }

        // you need to be changing this on user input
        public string Status;

        public void EnterDigit(int digit)
        {
            var entry = new StringBuilder();

            while (true)
            {
                switch (State)
                {
                    case State.Locked:
                        entry.Append(Console.ReadKey().KeyChar);

                        if (entry.ToString() == code)
                        {
                            state = State.Unlocked;
                            break;
                        }

                        if (!code.StartsWith(entry.ToString()))
                        {
                            // the code is blatantly wrong
                            state = State.Failed;
                        }
                        break;
                    case State.Failed:
                        Console.CursorLeft = 0;
                        Console.WriteLine("FAILED");
                        entry.Clear();
                        state = State.Locked;
                        break;
                    case State.Unlocked:
                        Console.CursorLeft = 0;
                        Console.WriteLine("UNLOCKED");
                        return;
                }
            }
        }
    }
}
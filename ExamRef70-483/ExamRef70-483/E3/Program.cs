using System;
using System.Threading;

namespace E3
{
    class Program
    {
        class ThreadTest
        {
            static bool done;    // Static fields are shared between all threads

            static void Main()
            {
                new Thread(Go).Start();
                Go();
            }

            static void Go()
            {
                if (!done) { done = true; Console.WriteLine("Done"); }
            }
        }
    }
}

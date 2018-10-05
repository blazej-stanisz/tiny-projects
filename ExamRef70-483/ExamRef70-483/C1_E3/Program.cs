using System;
using System.Threading;

namespace C1_E3
{
    class Program
    {
        [ThreadStatic]
        static int counter;

        static void Main(string[] args)
        {
            new Thread(() =>
            {
                while(counter < 4)
                {
                    Console.WriteLine($"T1, counter value: {counter}");
                    Thread.Sleep(1000);
                    counter++;
                }
            }).Start();

            new Thread(() =>
            {
                while (counter < 4)
                {
                    Console.WriteLine($"T2, counter value: {counter}");
                    Thread.Sleep(1000);
                    counter++;
                }
            }).Start();
        }
    }
}

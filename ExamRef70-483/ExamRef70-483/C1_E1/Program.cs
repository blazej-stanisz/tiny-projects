using System;
using System.Threading;

namespace C1_E1
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread t1 = new Thread(FirstEmptyMethod);

            Thread t2 = new Thread(() =>
            {
                Console.WriteLine("Second empty method..");
            });

            Thread t3 = new Thread(new ThreadStart(ThirdEmptyMethod));

            Thread t4 = new Thread(new ParameterizedThreadStart(FourthEmptyMethod));

            Thread t5 = new Thread((arg) =>
            {
                Console.WriteLine((string)arg);
            });

            Thread t6 = new Thread(() => FifthEmptyMethod("Emma", "Hevit"));

            t1.Start();             t1.Join();
            t2.Start();             t2.Join();
            t3.Start();             t3.Join();
            t4.Start("John");       t4.Join();
            t5.Start("Patt Flyn");  t5.Join();
            t6.Start();             t6.Join();
        }

        public static void FirstEmptyMethod()
        {
            Console.WriteLine("First empty method..");
        }
        public static void ThirdEmptyMethod()
        {
            Console.WriteLine("Third empty method..");
        }

        public static void FourthEmptyMethod(object name)
        {
            var result = (string)name + " Doe";
            Console.WriteLine(result);
        }

        public static void FifthEmptyMethod(string name, string surname)
        {
            Console.WriteLine(name + " " + surname);
        }
    }
}

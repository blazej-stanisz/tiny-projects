using System;
using System.Threading.Tasks;

namespace C1_E6
{
    class Program
    {
        static void Main(string[] args)
        {
            Task t1 = new Task(FirstEmptyMethod);
            t1.Start(); t1.Wait();

            Task.Run(() =>
            {
                Console.WriteLine("Second empty method..");
            }).Wait();

            Task.Run(() => SecondEmptyMethod("John")).Wait();

            var action = new Action<object>(ThirdEmptyMethod);
            Task t4 = new Task(action, "John");
            t4.Start(); t4.Wait();

            var t5 = Task.Run<string>(() => "returned string1");
            Console.WriteLine(t5.Result);

            var t6 = Task<string>.Run(() => "returned string2");
            Console.WriteLine(t6.Result);
        }

        public static void FirstEmptyMethod()
        {
            Console.WriteLine("First empty method..");
        }

        public static void SecondEmptyMethod(string name)
        {
            var result = name + " Doe1";
            Console.WriteLine(result);
        }

        public static void ThirdEmptyMethod(object name)
        {
            var result = (string)name + " Doe2";
            Console.WriteLine(result);
        }
    }
}

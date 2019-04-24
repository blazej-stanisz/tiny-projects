using System;

namespace SeleniumTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var testContainer = new SeleniumTestApi();
            testContainer.RunTest1();
        }
    }
}

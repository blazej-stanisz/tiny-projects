using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class Pojazd { };

    public class Auto : Pojazd
    {
        public Auto Metoda(Auto auto)
        {
            return new Auto();
        }

        void Program()
        {
            Metoda(new Auto());
            Metoda(new Audi());
        }
    };

    public class Audi : Auto
    {
    };
}

namespace ConsoleApplication11
{
    class Pojazd { };

    class Auto : Pojazd
    {
        static Auto GetAuto()
        {
            return new Auto();
        }

        Pojazd pojazd = GetAuto();
        Auto auto = GetAuto();
    };

    class Audi : Auto { };
}
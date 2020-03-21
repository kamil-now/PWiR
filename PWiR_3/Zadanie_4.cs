using System;
using System.Threading;

namespace PWiR_3
{
    public class Zadanie_4
    {
        static int _bilans = 0;
        public static void RUN()
        {
            Thread t1 = new Thread(new ThreadStart(Dodaj));
            Thread t2 = new Thread(new ThreadStart(Odejmij));
            t1.Start();
            t2.Start();

            Console.ReadKey();
        }
        static void Dodaj()
        {
            for (int i = 0; i < 20; i++)
            {
                _bilans += 100;
                Console.WriteLine($"Po dodaniu: {_bilans}");
            }
        }
        static void Odejmij()
        {
            for (int i = 0; i < 20; i++)
            {
                _bilans -= 100;
                Console.WriteLine($"Po odjęciu: {_bilans}");
            }
        }
    }
}
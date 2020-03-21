using System;
using System.Threading;

namespace PWiR_2
{
    public class Zadanie_5
    {
        static int _bilans = 0;
        public static void RUN()
        {
            Action<int> dodaj = n =>
            {
                for (int i = 0; i < n; i++)
                {
                    Thread.Sleep(500);
                    _bilans += 100;
                    Console.WriteLine($"Po dodaniu: {_bilans}");

                }
            };
            dodaj(100);
        }
    }
}

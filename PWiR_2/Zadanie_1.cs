using System;

namespace PWiR_2
{
    public class Zadanie_1
    {
        static int _bilans = 0;
        public static void RUN()
        {
            Dodaj(100);
        }
        static void Dodaj(int n)
        {
            for (int i = 0; i < n; i++)
            {
                _bilans += 100;
                Console.WriteLine($"Po dodaniu: {_bilans}");

            }
        }
    }
}

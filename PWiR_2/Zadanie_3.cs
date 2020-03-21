using System;

namespace PWiR_2
{
    public class Zadanie_3
    {
        static int _bilans = 0;
        public static void RUN()
        {
            Action<int> dodaj = Dodaj;
            Wykonaj(dodaj, 100);
        }
        static void Wykonaj(Action<int> action, int p)
        {
            action(p);
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

using System;

namespace PWiR_1
{
    public class Przyklad_2
    {
        delegate int DzialanieDelegat(int x, int y);

        public static void RUN()
        {
            WykonajDzialanie(10, 2, Dodaj);
            WykonajDzialanie(10, 2, Odejmij);
            Console.ReadKey();
        }

        static void WykonajDzialanie(int l1, int l2, DzialanieDelegat del)
        {
            int wynik = del(l1, l2);
            Console.WriteLine(wynik);
        }

        static int Dodaj(int x1, int x2)
        {
            return x1 + x2;
        }
        static int Odejmij(int x1, int x2)
        {
            return x1 - x2;
        }
    }
}

using System;

namespace PWiR_1
{
    public class Przyklad_3
    {
        delegate int DzialanieDelegat(int x1, int x2);  // Deklaracja typu degata 

        public static void RUN()
        {
            int l1 = 10;
            int l2 = 2;
            DzialanieDelegat del = Dodaj;
            del += Odejmij;
            del += Inne;
            Console.WriteLine(del(l1, l2));  // Tu delegat wywoła wszystkie metody, na które wskazuje
            Console.ReadKey();
        }
        static int Dodaj(int x1, int x2)
        {
            Console.WriteLine("Jestem w metodzie Dodaj");
            return x1 + x2;
        }
        static int Odejmij(int x1, int x2)
        {
            Console.WriteLine("Jestem w metodzie Odejmij");
            return x1 - x2;
        }
        static int Inne(int x1, int x2)
        {
            Console.WriteLine("Jestem w metodzie Inne");
            return x1 * x2 - 1;
        }
    }
}

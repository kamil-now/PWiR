using System;

namespace PWiR_1
{
    public class Przyklad_1
    {

        delegate int DzialanieDelegat(int x1, int x2);  // Deklaracja typu delegata 
        public static void RUN()
        {
            int l1 = 10, l2 = 2;
            Console.WriteLine("Mam dwie liczby {0} i {1}. Co wolisz - dodaæ czy odj¹æ? (D/O)", l1, l2);
            int znak = Console.Read();

            DzialanieDelegat del = null;    // Deklaracja obiektu delegata 
            if (znak == 'D' || znak == 'd')
                del = new DzialanieDelegat(Dodaj);   // Utworzenie obiektu delegata z referencją do metody Dodaj
            else
                del = new DzialanieDelegat(Odejmij);   // Utworzenie obiektu delegata z referencją do metody Odejmij

            Console.WriteLine(del(l1, l2));  // Wywołanie delegata
            Console.ReadKey();
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

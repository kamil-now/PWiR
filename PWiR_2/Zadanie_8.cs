using System;

namespace PWiR_2
{
    public class Zadanie_8
    {
        public static void RUN()
        {
            Console.Title = "Sortowanie obiektów";
            Towar[] tabTowary = {
                new Towar("DL-2111-M1", "Długopis", 6.5),
                new Towar("DL-2134-M1", "Ołówek", 2.5),
                new Towar("BL-4121-M2", "Blok rysunkowy", 3.2) };
            Towar.WykazTowarow(tabTowary, "Przed sortowaniem:");
            Array.Sort(tabTowary, Towar.Porownaj);
            Towar.WykazTowarow(tabTowary, "Po sortowaniu:");

            Action<Towar> akcja = x => Console.WriteLine(x.ToString());
            Array.ForEach(tabTowary, akcja);

            Console.ReadKey();
        }
        class Towar
        {
            readonly string _symbol;
            readonly string _nazwa;
            readonly double _cena;

            public Towar(string symbol, string nazwa, double cena)
            {
                _symbol = symbol;
                _nazwa = nazwa;
                _cena = cena;
            }

            public override string ToString()
            {
                return $"{_symbol,-12} {_nazwa,-14} {_cena,5}";
            }

            public static void WykazTowarow(Towar[] tab, string opis)
            {
                Console.WriteLine(opis);
                foreach (Towar t1 in tab)
                {
                    Console.WriteLine(t1.ToString());
                }
            }

            public static int Porownaj(Towar t1, Towar t2)
            {
                if (t1 == null && t2 == null) return 0;
                else if (t1 == null) return -1;
                else if (t2 == null) return 2;

                if (t1._cena < t2._cena) return -1;
                else if (t1._cena > t2._cena) return 1;
                else return 0;
            }
        }
    }
}

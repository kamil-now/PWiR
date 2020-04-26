using System;
using System.Collections.Generic;

namespace PWiR_8
{
    public class Przyklad_3
    {
        public static void RUN()
        {
            List<String> imiona = new List<String>();
            imiona.Add("Ania");
            imiona.Add("Janusz");
            imiona.Add("Tomek");
            imiona.Add("Robert");

            // Sposob 1: Uzycie ForEach z u¿yciem metody Pisz.
            imiona.ForEach(Pisz);

            // Sposob 2: Uzycie ForEach z wyra¿eniem lambda
            imiona.ForEach(imie => { Console.WriteLine(imie); });
            Console.ReadKey();
        }
        private static void Pisz(string s)
        {
            Console.WriteLine(s);
        }
    }
}

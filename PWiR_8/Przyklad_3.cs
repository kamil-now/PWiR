using System;
using System.Collections.Generic;

namespace PWiR_8
{
    public class Przyklad_3
    {
        public static void RUN()
        {
            List<string> imiona = new List<string>
            {
                "Ania",
                "Janusz",
                "Tomek",
                "Robert"
            };

            // Sposób 1: Uzycie ForEach z użyciem metody Pisz.
            imiona.ForEach(Pisz);

            // Sposób 2: Uzycie ForEach z wyrażeniem lambda
            imiona.ForEach(imie => Console.WriteLine(imie));
            Console.ReadKey();
        }
        private static void Pisz(string s)
        {
            Console.WriteLine(s);
        }
    }
}

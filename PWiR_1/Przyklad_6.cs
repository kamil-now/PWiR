using System;

namespace PWiR_1
{
    public class Przyklad_6
    {
        public static void RUN()
        {
            Action<int, int, ConsoleColor> akcja = WypiszKomunikat;
            akcja(10, 3, ConsoleColor.Green);
            Console.ReadKey();
        }

        private static void WypiszKomunikat(int kol, int wier, ConsoleColor kolor)
        {
            Console.Title = "Testujemy Action";
            Console.SetCursorPosition(kol, wier);
            Console.ForegroundColor = kolor;
            Console.Write("Komunikat specjalny");
        }
    }
}

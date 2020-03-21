using System;

namespace PWiR_1
{
    public class Przyklad_5
    {
        public static void RUN()
        {
            Func<double, double> fun = Oblicz1;
            fun += Oblicz2;
            Console.WriteLine(fun(10));
            Console.ReadKey();
        }

        private static double Oblicz1(double x)
        {
            return Math.Pow(x, 3) - 2 * x;
        }
        private static double Oblicz2(double x)
        {
            return Math.Pow(x, 3);
        }
    }
}

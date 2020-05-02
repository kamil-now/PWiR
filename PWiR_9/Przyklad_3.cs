using System;
using System.Threading.Tasks;

namespace PWiR_9
{
    public class Przyklad_3
    {
        static double[] tab = { 10.5, 20, 45, 69.1, 4.5, 21 };
        static double suma, minimum, sredniaG;
        public static void RUN()
        {
            Parallel.Invoke(
                   LiczSume,    // Param #0 - statyczna metoda
                   () =>        // Param #1 - wyrazenie lambda
                {
                    minimum = tab[0];
                    for (int i = 1; i < tab.Length; i++)
                    {
                        if (tab[i] < minimum) minimum = tab[i];
                    }
                },
                   () =>        // Param #2 - wyrazenie lambda
                {
                    double iloczyn = 1;
                    foreach (double element in tab)
                    {
                        iloczyn *= element;
                    }
                    sredniaG = Math.Pow(iloczyn, 1.0 / tab.Length);
                }
               );
            Console.Write("Suma {0} minimum {1:F2} srednia geom. {2:F2}",
                suma, minimum, sredniaG);
            Console.ReadKey();
        }
        static void LiczSume()
        {
            foreach (int element in tab)
            {
                suma += element;
            }
        }
    }
}

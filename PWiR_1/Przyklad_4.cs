using System;

namespace PWiR_1
{
    public delegate void DzialanieDelegat();
    public class Przyklad_4
    {
        public static void RUN()
        {
            Podatek p = new Podatek();
            DzialanieDelegat del = Raport;
            p.RaportCallBack(del);
            Console.ReadKey();
        }
        static void Raport()
        {
            Console.WriteLine("Treœæ raportu");
        }
    }
    public class Podatek
    {
        public double kwotaDochodu { get; set; }

        // ...  Jakieś inne składowe klasy Podatek

        public void RaportCallBack(DzialanieDelegat del)
        {
            del();
        }
    }
}

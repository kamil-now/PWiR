//using System;
//using System.Threading.Tasks;

//namespace KOLOS
//{
//    class Program
//    {
//        static readonly Random _rand = new Random();
//        static void Main(string[] args)
//        {
//            var count = 10000;
//            var a = InitWithRandom(count, -5, 5);
//            var b = InitWithRandom(count, 1, 15);

//            Console.WriteLine($"a = {string.Join(", ", a)}");
//            Console.WriteLine($"b = {string.Join(", ", b)}");
//            Console.WriteLine($"Iloczyn skalarny a i b = {IloczynSkalarny(a, b)}");
//            Console.ReadKey();
//        }
//        static int IloczynSkalarny(int[] a, int[] b)
//        {
//            var suma = 0;
//            Parallel.For(0, a.Length, i => suma += a[i] * b[i]);
//            return suma;
//        }
//        static int[] InitWithRandom(int count, int min, int max)
//        {
//            var tab = new int[count];
//            Parallel.For(0, count, i => tab[i] = _rand.Next(min, max));
//            return tab;
//        }
//    }
//}

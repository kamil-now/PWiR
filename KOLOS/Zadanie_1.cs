//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading;
//using System.Threading.Tasks;

//namespace KOLOS
//{
//    class Program
//    {
//        static Semaphore _bagazSem = new Semaphore(2, 2);
//        static Semaphore _odprawaSem = new Semaphore(5, 5);
//        static Semaphore _wejscieSem = new Semaphore(2, 2);
//        static int _naPokladzie = 0;
//        static void Main(string[] args)
//        {
//            var iloscPasazerow = 90;
//            var pasazerowie = new List<Task>();
//            var i = 0;
//            foreach (var pasazer in Enumerable.Range(1, iloscPasazerow))
//            {
//                pasazerowie.Add(Task.Factory.StartNew(() =>
//                {
//                    var j = ++i;
//                    NadajBagaz(j);
//                    OdprawaBezpieczenstwa(j);
//                    WejscieNaPoklad(j);
//                }));
//            }

//            Task.WaitAll(pasazerowie.ToArray());
//            Console.WriteLine($"WSZYSCY NA POKŁADZIE ({_naPokladzie} osób)");
//            Console.ReadKey();
//        }

//        static void NadajBagaz(int id)
//        {
//            _bagazSem.WaitOne();
//            Console.WriteLine($"{id} pasażer nadaje bagaż");
//            Thread.Sleep(450);
//            _bagazSem.Release();
//        }
//        static void OdprawaBezpieczenstwa(int id)
//        {
//            _odprawaSem.WaitOne();
//            Console.WriteLine($"{id} pasażer przechodzi odprawę");
//            Thread.Sleep(500);
//            _odprawaSem.Release();
//        }
//        static void WejscieNaPoklad(int id)
//        {
//            _wejscieSem.WaitOne();
//            Console.WriteLine($"{id} pasażer wchodzi na pokład");
//            Thread.Sleep(250);
//            Interlocked.Increment(ref _naPokladzie);
//            _wejscieSem.Release();
//        }
//    }
//}

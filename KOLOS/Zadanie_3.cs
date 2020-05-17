//using System;
//using System.Collections.Generic;
//using System.IO;

//namespace KOLOS
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            var path = @"C:\Users\Kamil\Desktop\Programowanie współbieżne i rozproszone\tmp.csv";
//            var content = CsvReaderWriter.Read(path);
//            CsvReaderWriter.Write(path, content, false);
//            CsvReaderWriter.ReadAndPrint(path);
//            Console.ReadKey();
//        }
//    }
//    class CsvReaderWriter
//    {
//        public static List<string[]> Read(string path)
//        {
//            var list = new List<string[]>();
//            using (var reader = new StreamReader(path))
//            {
//                while (!reader.EndOfStream)
//                {
//                    var line = reader.ReadLine();
//                    list.Add(line.Split(','));
//                }
//            }
//            return list;
//        }
//        public static void ReadAndPrint(string path)
//        {
//            var content = Read(path);
//            foreach (var row in content)
//            {
//                Console.WriteLine(string.Join(" ", row));
//            }
//        }
//        public static void Write(string path, List<string[]> content, bool append)
//        {
//            using (var writer = new StreamWriter(path, append))
//            {
//                if(content.Count > 0 && new FileInfo(path).Length == 0)
//                {
//                    writer.WriteLine();
//                }
//                foreach (var row in content)
//                {
//                    writer.WriteLine(string.Join(",", row));
//                }
//            }
//        }
//    }
//}

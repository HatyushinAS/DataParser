using System;
using System.IO;
using ParseDate.Models;

namespace ParseDate
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var file = FileReader.GetDateFromFile(new FileInfo(@"C:\Games\20210105.12_15_10.data.txt"));
            Console.WriteLine(file.GetProductsCount());
            Console.WriteLine(file.GetProdictsPrice());
            Console.WriteLine(file.Date.ToString());
        }
    }
}
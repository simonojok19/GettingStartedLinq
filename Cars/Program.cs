using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Cars
{
    class Program
    {
        static void Main(string[] args)
        {
            var cars = ProcessFile("fuel.csv");
        }

        private static List<Car> ProcessFile(string path)
        {
            File.ReadAllLines(path)
                .Skip(1)
                .Where(line => line.Length > 1)

        }
    }
}

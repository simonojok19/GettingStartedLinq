﻿using System;
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

            var query = from car in cars orderby car.Combined ascending, car.Name
                        select car;

            foreach(var car in query.Take(5))
            {
                Console.WriteLine($"{car.Name}: {car.Combined}");
            }
        }
         
        private static List<Car> ProcessFile(string path)
        {
           // var query = from line in File.ReadAllLines(path).Skip(1)
            //            where line.Length > 1
            //          select Car.ParseFromCsv(line);

            return File.ReadAllLines(path)
                .Skip(1)
                .Where(line => line.Length > 1)
                .Select(Car.ParseFromCsv)
                .ToList();

        }
    }
}

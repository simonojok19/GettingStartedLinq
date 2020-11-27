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

            var query = from car in cars
                        where car.Manufacturer == "BMW" && car.Year == 2016
                        orderby car.Combined ascending, car.Name
                        select car;

            var query2 = cars.Where(c => c.Manufacturer == "BMW" && c.Year == 2016)
                .OrderByDescending(c => c.Combined)
                .ThenBy(c => c.Name)
                .Select(c => c)
                .First();

            foreach(var car in query.Take(10))
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

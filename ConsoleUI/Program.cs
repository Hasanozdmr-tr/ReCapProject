using Business.Concrete;
using DataAccess.Concrete;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new InMemoryCarDal());
            Car car1 = new Car()
            {
                Id = 4,
                BrandId = 4,
                ColorId = 3,
                DailyPrice=3,
                ModelYear=2012,
                Description="Mercedes Benz C180"
            };
            Car car2 = new Car()
            {
                Id = 4,
                BrandId = 4,
                ColorId = 3,
                DailyPrice = 3,
                ModelYear = 2012,
                Description = "BMW 3.2"
            };

            Console.WriteLine("Güncel Araba Listesi: ");
            foreach (var cars in carManager.GetAll())
            {
                Console.WriteLine(cars.Description);
            }
            Console.WriteLine("-------------------");
            carManager.Add(car1);
            Console.WriteLine("Güncel Araba Listesi: ");
            foreach (var cars in carManager.GetAll())
            {
                Console.WriteLine(cars.Description);
            }
            Console.WriteLine("-------------------");
            carManager.Update(car2);
            Console.WriteLine("Güncel Araba Listesi: ");
            foreach (var cars in carManager.GetAll())
            {
                Console.WriteLine(cars.Description);
            }
            Console.WriteLine("-------------------");
            carManager.Delete(car2);
            Console.WriteLine("Güncel Araba Listesi: ");
            foreach (var cars in carManager.GetAll())
            {
                Console.WriteLine(cars.Description);
            }

            

            

        }
    }
}

using Business.Concrete;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //CarManager carManager = new CarManager(new InMemoryCarDal());
            //Car car1 = new Car()
            //{
            //    CarId = 4,
            //    BrandId = 4,
            //    ColorId = 3,
            //    DailyPrice = 3,
            //    ModelYear = 2012,
            //    Description = "Mercedes Benz C180"
            //};

            //carManager.Update(car2);
            //carManager.Delete(car2);



            CarManager carManager = new CarManager(new EfCarDal());
            var MarkayaGöreSorgu = carManager.GetCarsByBrandId(2);
            foreach (var car in MarkayaGöreSorgu)
            {
                Console.WriteLine(car.Description);
            }
            Console.WriteLine("----------------------");
            var RengeGöreSorgu = carManager.GetCarsByColorId(1);
            foreach (var car in RengeGöreSorgu)
            {
                Console.WriteLine(car.Description);
            }
            Console.WriteLine("----------------------");
            
            Car car1 = new Car()
            {
                CarId = 5,
                BrandId = 4,
                ColorId = 3,
                DailyPrice = 300,
                ModelYear = 2020,
                Description = "BMW 3.2"
            };
            carManager.Add(car1);
            Console.WriteLine("----------------------");
            Car car2 = new Car()
            {
                CarId = 5,
                BrandId = 4,
                ColorId = 3,
                DailyPrice = 100,
                ModelYear = 2020,
                Description = "B"
            };
            carManager.Add(car2);
        }






        private static void GüncelArabaListesi(CarManager carManager)
        {
            Console.WriteLine("Güncel Araba Listesi: ");
            foreach (var cars in carManager.GetAll())
            {
                Console.WriteLine(cars.Description);
            }
        }
    }
}

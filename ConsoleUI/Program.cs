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
            Car car1 = new Car()
            {
                CarId = 5,
                BrandId = 4,
                ColorId = 3,
                DailyPrice = 300,
                ModelYear = 2020,
                Description = "BMW 3.2"
            };
            Car car2 = new Car()
            {
                CarId = 5,
                BrandId = 4,
                ColorId = 3,
                DailyPrice = 100,
                ModelYear = 2020,
                Description = "B"
            };
            //CarManager carManager = new CarManager(new EfCarDal());

            CarTest();
            Console.WriteLine("----------------------");
            BrandTest(1);
            Console.WriteLine("----------------------");
            ColorTest();
            Console.WriteLine("----------------------");
            GetCarDetailTest();

            AddCarTestEntityFramework(car1);
            car1.Description = "Yeni Model İsmi: BMW 3.2";
            UpdateCarTestEntityFramework(car1);
            //AddTestInMemory();

            





            //var MarkayaGöreSorgu = carManager.GetCarsByBrandId(2);
            //foreach (var car in MarkayaGöreSorgu)
            //{
            //    Console.WriteLine(car.Description);
            //}
            //Console.WriteLine("----------------------");
            //var RengeGöreSorgu = carManager.GetCarsByColorId(1);
            //foreach (var car in RengeGöreSorgu)
            //{
            //    Console.WriteLine(car.Description);
            //}
            //Console.WriteLine("----------------------");


            //carManager.Delete(car1);
            //Console.WriteLine("----------------------");

            //carManager.Add(car2);
        }

        private static void UpdateCarTestEntityFramework(Car car1)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            carManager.Update(car1);
        }

        private static void GetCarDetailTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetCarDetail())
            {
                Console.WriteLine(car.ColorName + "\t" + car.DailyPrice + "\t" + car.BrandName + "\t" + car.CarName);
            }
        }

        private static void ColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine(color.ColorName);
            }

        }

        private static void BrandTest(int id)
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            Console.WriteLine(brandManager.GetById(id).BrandName);
                
            

        }

        private static void CarTest()
        {

            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Description);
            }
            
        }

        private static void AddCarTestEntityFramework(Car car)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            carManager.Add(car);

        }

        private static void AddTestInMemory()
        {
            CarManager carManager;
            Car car1;
            carManager = new CarManager(new InMemoryCarDal());
            car1 = new Car()
            {
                CarId = 4,
                BrandId = 4,
                ColorId = 3,
                DailyPrice = 3,
                ModelYear = 2012,
                Description = "Mercedes Benz C180"
            };
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

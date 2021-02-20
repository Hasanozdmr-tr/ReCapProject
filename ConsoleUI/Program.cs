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

            Rental rental = new Rental

            {
                Id = 3,
                CarId = 3,
                CustomerId = 2,
                RentDate = DateTime.Now,
                ReturnDate = null

            };

            RentalTest(rental);

            CarTest();
            Console.WriteLine("----------------------");
            GetCarDetailTest();
            Console.WriteLine("----------------------");
            BrandTest(1);
            Console.WriteLine("----------------------");
            ColorTest();



            //AddCarTestEntityFramework(car1);
            //car1.Description = "Yeni Model İsmi: BMW 3.2";
            //UpdateCarTestEntityFramework(car1);
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

        private static void RentalTest(Rental rental)
        {
            RentalManager rentalmanager = new RentalManager(new EfRentalDal { });

            var result1 = rentalmanager.Add(rental);
            Console.WriteLine(result1.Message);

            var result2 = rentalmanager.Completed(rental);
            Console.WriteLine(result2.Message);
        }

        private static void UpdateCarTestEntityFramework(Car car1)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            carManager.Update(car1);
        }

        private static void GetCarDetailTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetCarDetail();
            if(result.Success)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine(car.ColorName + "\t" + car.DailyPrice + "\t" + car.BrandName + "\t" + car.CarName);
                    Console.WriteLine(result.Message);
                }
                    
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void ColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            var result = colorManager.GetAll();
            if(result.Success)
            {
                foreach (var color in result.Data)
                {
                    Console.WriteLine(color.ColorName);
                }
                Console.WriteLine(result.Message);
            }
            else
            {
                Console.WriteLine(result.Message);
            }

        }

        private static void BrandTest(int id)
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            var result = brandManager.GetById(id);
            if (result.Success)
            {
              Console.WriteLine(result.Data.BrandName);
             
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void CarTest()
        {

            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetAll();
            if (result.Success)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine(car.Description);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
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
            foreach (var cars in carManager.GetAll().Data)
            {
                Console.WriteLine(cars.Description);
            }
        }
    }
}

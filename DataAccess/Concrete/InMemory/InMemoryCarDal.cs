using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> carList;
        public InMemoryCarDal()
        {
            carList = new List<Car>()
            {
            new Car { Id = 1, BrandId = 1, ColorId = 1, DailyPrice = 15, ModelYear = 2018, Description = "Audi A3" },
            new Car { Id = 2, BrandId = 2, ColorId = 1, DailyPrice = 50, ModelYear = 1999, Description = "Volkswagen Golf"},
            new Car { Id = 3, BrandId = 3, ColorId = 2, DailyPrice = 35, ModelYear = 2018, Description = "Skoda Superb" }
            };
        }
       
        

        public void Add(Car car)
        {
            carList.Add(car);
            
        }


        public void Delete(Car car)
        {
            List<Car> deleteCars = carList.Where(p => p.Id == car.Id).ToList();
            foreach (var c in deleteCars)
            {
                carList.Remove(c);
            }
            
        }

        public List<Car> GetAll()
        {
            
            return carList;
        }

        public List<Car> GetById(int Id)
        {
            List<Car> getCars = carList.Where(p => p.Id == Id).ToList();

            return getCars;
        }

        public void Update(Car car)
        {
            List<Car> updateCars = carList.Where(p => p.Id == car.Id).ToList();
            foreach (var c in updateCars)
            {
                c.Id = car.Id;
                c.ColorId = car.ColorId;
                c.BrandId = car.BrandId;
                c.DailyPrice = car.DailyPrice;
                c.Description = car.Description;
                c.ModelYear = car.ModelYear;
            }
        }
    }
}


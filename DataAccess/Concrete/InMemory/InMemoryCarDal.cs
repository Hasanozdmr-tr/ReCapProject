using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
            new Car { CarId = 1, BrandId = 1, ColorId = 1, DailyPrice = 15, ModelYear = 2018, Description = "Audi A3" },
            new Car { CarId = 2, BrandId = 2, ColorId = 1, DailyPrice = 50, ModelYear = 1999, Description = "Volkswagen Golf"},
            new Car { CarId = 3, BrandId = 3, ColorId = 2, DailyPrice = 35, ModelYear = 2018, Description = "Skoda Superb" }
            };
        }
       
        

        public void Add(Car car)
        {
            carList.Add(car);
            
        }


        public void Delete(Car car)
        {
            List<Car> deleteCars = carList.Where(p => p.CarId == car.CarId).ToList();
            foreach (var c in deleteCars)
            {
                carList.Remove(c);
            }
            
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            
            return carList;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetById(int Id)
        {
            List<Car> getCars = carList.Where(p => p.CarId == Id).ToList();

            return getCars;
        }

        public void Update(Car car)
        {
            List<Car> updateCars = carList.Where(p => p.CarId == car.CarId).ToList();
            foreach (var c in updateCars)
            {
                c.CarId = car.CarId;
                c.ColorId = car.ColorId;
                c.BrandId = car.BrandId;
                c.DailyPrice = car.DailyPrice;
                c.Description = car.Description;
                c.ModelYear = car.ModelYear;
            }
        }
    }
}


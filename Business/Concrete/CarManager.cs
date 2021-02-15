using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CarManager: ICarService
    {
        ICarDal _carDal;
        

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }


        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        public void Add(Car car)
        {
            var AynıKayıtVarMı = _carDal.GetAll(p => p.Description == car.Description);
            if (AynıKayıtVarMı!=null)
            {
                Console.WriteLine("Bu araba daha önce listeye eklenmiştir.");
            }
            
            else
            { 
                if (car.DailyPrice > 0 && car.Description.Length > 2)
                {
                    _carDal.Add(car);
                    Console.WriteLine(car.Description + " isimli araba Listeye eklenmiştir.");
                }
                else if (car.DailyPrice <= 0)
                {
                    Console.WriteLine("Araba kiralama ücreti 0 dan küçük olmamalıdır! ");
                }
                else if (car.Description.Length <= 2)
                    Console.WriteLine("Araba ismi 2 karakterden büyük olmalıdır.");

            }




        }

        public void Update(Car car)
        {
            _carDal.Update(car);
            Console.WriteLine(car.Description + " Detayları Güncellenmiştir.");
        }

        public void Delete(Car car)
        {
            _carDal.Delete(car);
        }

        public List<Car> GetCarsByBrandId(int brandId)
        {
            return _carDal.GetAll().Where(p=>p.BrandId== brandId).ToList();
        }

        public List<Car> GetCarsByColorId(int colorId)
        {
            return _carDal.GetAll().Where(p => p.ColorId == colorId).ToList();
        }

        public List<CarDetailDto> GetCarDetail()
        {
            return _carDal.GetCarDetail();
        }

        public List<Car> GetByUnitPrice(decimal min, decimal max)
        {
            return _carDal.GetAll(p=>p.DailyPrice>min && p.DailyPrice<max);
        }
    }
}

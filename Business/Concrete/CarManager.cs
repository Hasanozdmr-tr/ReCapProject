using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constant;
using Business.DependencyResolvers.ValidationRules.FluentValidator;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.CrosCuttingConcern.Validation;
using Core.Utilities;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;


        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

       // [SecuredOperation("Admin,CarList")]
        [CacheAspect]
        public IDataResult<List<Car>> GetAll()
        {
            if(DateTime.Now.Hour==05)
            {
                return new ErrorDataResult<List<Car>>(Messages.CarMaintenenceTime);
            }

            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.CarListed);
        }

        [ValidationAspect(typeof(CarValidator))]
        [SecuredOperation("Admin,CarAdd")]
        [TransactionScopeAspect]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Add(Car car)
        {
          
            ValidationTool.Validate(new CarValidator(), car);


            var CarControl = _carDal.GetAll(p => p.CarId == car.CarId);
        if (car.Description.Length<2)
        {
            return new ErrorResult(Messages.CarNameInValid);
        }
        else if(CarControl.Count>=1)
            {
                return new ErrorResult(Messages.CarSameName);
            }

            _carDal.Add(car);
            return new SuccessResult(Messages.CarAdded);
             
        }


        [CacheRemoveAspect("ICarService.Get")]
        [TransactionScopeAspect]
        public IResult Update(Car car)
        {
            var _car = _carDal.Get(p => p.CarId == car.CarId);
            if (_car == null)
            {
                return new ErrorDataResult<Car>(Messages.CarCouldntFound);
            }
            _carDal.Update(car);
            return new SuccessResult(Messages.CarUpdated);
        }

        [TransactionScopeAspect]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Delete(Car car)
        {
            var _car = _carDal.Get(p => p.CarId == car.CarId);
            if (_car == null)
            {
                return new ErrorDataResult<Car>(Messages.CarCouldntFound);
            }
            _carDal.Delete(car);
            return new SuccessResult("Ürün silindi");
        }

        public IDataResult<List<CarDetailDto>> GetCarsByBrandId(int brandId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetail().Where(p=>p.BrandId== brandId).ToList(),Messages.CarListed);
        }

        public IDataResult<List<CarDetailDto>> GetCarsByColorId(int colorId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetail().Where(p => p.ColorId == colorId).ToList(), Messages.CarListed);
        }

        public IDataResult<List<CarDetailDto>> GetAllCarDetails()
        {
            if ((int)DateTime.Now.DayOfWeek == 3)
            {
                return new ErrorDataResult<List<CarDetailDto>>(Messages.CarMaintenenceTime);
            }
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetail(), Messages.CarListed); 
        }

        public IDataResult<List<Car>> GetByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p=>p.DailyPrice>min && p.DailyPrice<max), Messages.CarListed); 
        }

        [PerformanceAspect(5)]
        [CacheAspect]
        public IDataResult<Car> Get(int id)
        {
            var _car = _carDal.Get(p => p.CarId == id);
            if (_car==null)
            {
                return new ErrorDataResult<Car>(Messages.CarCouldntFound);
            }
            return new SuccessDataResult<Car>(_car, Messages.CarListed);
        }

    }
}

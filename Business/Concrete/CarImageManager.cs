using Business.Abstract;
using Business.Constant;
using Business.ValidationRules.FluentValidator;
using Core.Aspects.Autofac.Validation;
using Core.Utilities;
using Core.Utilities.Business;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Core.Utilities.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

       [ValidationAspect(typeof(CarImageValidator))]
        public IResult Add(IFormFile file, CarImage carImage)
        {
           IResult result = BusinessRules.Run(CheckCarImageMaxLimit(carImage));
           
            if(result != null)
            {
                return result;
            }

            carImage.ImagePath = FileHelpers.Add(file);
            carImage.Date = DateTime.Now;
            
            _carImageDal.Add(carImage);
            return new SuccessResult(Messages.CarImageAdded);
        }

        public IResult Delete(CarImage carImage)
        {
            var oldpath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..\\..\\..\\wwwroot")) + _carImageDal.Get(I => I.Id == carImage.Id).ImagePath;

            var result = BusinessRules.Run(FileHelpers.Delete(oldpath));

            if (result != null)
            {
                return result;
            }
            _carImageDal.Delete(carImage);
            return new SuccessResult(Messages.CarImageDeleted);
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            List<CarImage> allCarImages = _carImageDal.GetAll();

            if (allCarImages.Count == 0)
            {
                var result = CheckIfCarImageNull();
                return result;
            }
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(),Messages.CarImagesListed);
        }

        public IDataResult<CarImage> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<CarImage>> GetImagesByCarId(int id)
        {
            List<CarImage> allCarImages = _carImageDal.GetAll(p=>p.CarId== id);

            if(allCarImages.Count==0)
            {
               var result = CheckIfCarImageNull();
                return result;
            }

            return new SuccessDataResult<List<CarImage>>(allCarImages);


        }
        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Update(IFormFile file, CarImage carImage)
        {
            var oldpath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..\\..\\..\\wwwroot")) + _carImageDal.Get(p => p.Id == carImage.Id).ImagePath;
            carImage.ImagePath = FileHelpers.Update(oldpath, file);
            carImage.Date = DateTime.Now;
            _carImageDal.Update(carImage);
            return new SuccessResult(Messages.CarImageUpdated);
        }

        private IResult CheckCarImageMaxLimit(CarImage carImage)
        {
            var result = _carImageDal.GetAll(p=>p.CarId==carImage.CarId).Count;
            if(result<=5)
            {
                return new SuccessResult();
            }
            return new ErrorResult(Messages.CarImageNumberReacedMaxLimit);
        }

        private IDataResult<List<CarImage>> CheckIfCarImageNull()
        {
            try
            {
                string path = @"\Images\default.jpg";
                
                    List<CarImage> carImage = new List<CarImage>();
                    carImage.Add(new CarImage { CarId = 1, ImagePath = path, Date = DateTime.Now });
                    return new SuccessDataResult<List<CarImage>>(carImage);
                }
            
            catch (Exception exception)
            {

                return new ErrorDataResult<List<CarImage>>(exception.Message);
            }

            //return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(p => p.CarId == id).ToList());
        }


    }
}

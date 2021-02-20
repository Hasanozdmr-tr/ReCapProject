using Business.Abstract;
using Business.Constant;
using Core.Utilities;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;
        
        public RentalManager(IRentalDal rentalDal )
        {
            _rentalDal = rentalDal;
            
        }

        public IResult Add(Rental rental)
        {
            
            List<Rental> returnedCars = _rentalDal.GetAll(p => p.CarId == rental.CarId).ToList();
            
            if(returnedCars.Count!=0)
            {
                foreach (var car in returnedCars)
                {
                    if (car.ReturnDate == null)
                    {
                      
                        return new ErrorResult(Messages.RentalNotAvailable);
                    }
                }
            }
           
            _rentalDal.Add(rental);
            return new SuccessResult(Messages.RentalAdded);
        }

        public IResult Completed(Rental rental)
        {
            var _rental = _rentalDal.GetAll(p => p.Id == rental.Id);
            foreach (var rent in _rental)
            {
                rent.ReturnDate = DateTime.Now;
                _rentalDal.Update(rent);
            }
          
            return new SuccessResult(Messages.RentalCompleted);
        }

        public IResult Delete(Rental rental)
        {

            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.RentalDeleted);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
        }

        public IDataResult<Rental> GetById(int id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(p => p.Id == id));
        }

        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.RentalUpdated);
        }
    }
}

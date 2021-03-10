using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constant;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.Utilities;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;
        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        //[ValidationAspect(typeof(BrandValidator))]
        [SecuredOperation("Admin")]
        [TransactionScopeAspect]
        [CacheRemoveAspect("IBrandService.Get")]
        public IResult Add(Brand brand)
        {
            _brandDal.Add(brand);
            return new SuccessResult(Messages.BrandAdded);
        }

        [TransactionScopeAspect]
        [CacheRemoveAspect("IBrandService.Get")]
        public IResult Delete(Brand brand)
        {
            _brandDal.Delete(brand);
            return new SuccessResult(Messages.BrandDeleted);
        }

        [PerformanceAspect(5)]
        [CacheAspect]
        public IDataResult<Brand> GetById(int id)
        {
            if((int)DateTime.Today.Month == 2)
            {
                return new ErrorDataResult<Brand>(Messages.BrandMaintenenceTime);
            }
            else
            {
                return new SuccessDataResult<Brand>(_brandDal.Get(p => p.BrandId == id),Messages.BrandListed);
            }
            
        }

        [SecuredOperation("Admin")]
        [CacheAspect]
        public IDataResult<List<Brand>> GetAll()
        {
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(), Messages.BrandListed);
        }

        [CacheRemoveAspect("IBrandService.Get")]
        [TransactionScopeAspect]
        public IResult Update(Brand brand )
        {
            if (brand.BrandName.Length < 2)
            {
                return new ErrorResult(Messages.BrandNameInValid);
            }
            else
            {
                _brandDal.Update(brand);
                return new SuccessResult(Messages.BrandUpdated);
            }
                   
                
        }
    }
}

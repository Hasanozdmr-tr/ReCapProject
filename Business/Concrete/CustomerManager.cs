using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constant;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Transaction;
using Core.Utilities;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        //[ValidationAspect(typeof(CustomerValidator))]
        [SecuredOperation("Admin")]
        [TransactionScopeAspect]
        [CacheRemoveAspect("ICustomerService.Get")]
        public IResult Add(Customer customer)
        {
            _customerDal.Add(customer);
            return new SuccessResult(Messages.CustomerAdded);
        }

        [TransactionScopeAspect]
        [CacheRemoveAspect("ICustomerService.Get")]
        public IResult Delete(Customer customer)
        {
            _customerDal.Delete(customer);
            return new SuccessResult(Messages.CustomerDeleted);
        }

        [SecuredOperation("Admin")]
        [CacheAspect]
        public IDataResult<List<Customer>> GetAll()
        {
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll());
        }

        [PerformanceAspect(5)]
        [CacheAspect]
        public IDataResult<Customer> GetById(int id)
        {
            return new SuccessDataResult<Customer>(_customerDal.Get(p=>p.UserId==id));
        }

        [CacheRemoveAspect("ICustomerService.Get")]
        [TransactionScopeAspect]
        public IResult Update(Customer customer)
        {
            _customerDal.Update(customer);
            return new SuccessResult(Messages.CustomerUpdated);
        }
    }
}

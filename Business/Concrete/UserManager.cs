using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constant;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Transaction;
using Core.Entities.Concrete;
using Core.Utilities;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        //[ValidationAspect(typeof(UserValidator))]
        [SecuredOperation("Admin")]
        [TransactionScopeAspect]
        [CacheRemoveAspect("IUserService.Get")]
        public IResult Add(User user)
        {
            _userDal.Add(user);
            return new SuccessResult(Messages.CustomerAdded);
        }

        [TransactionScopeAspect]
        [CacheRemoveAspect("IUserService.Get")]
        public IResult Delete(User user)
        {
            _userDal.Add(user);
            return new SuccessResult(Messages.CustomerAdded);
        }

        [SecuredOperation("Admin")]
        [CacheAspect]
        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll());
        }

        [PerformanceAspect(5)]
        [CacheAspect]
        public IDataResult<User> GetById(int id)
        {
            return new SuccessDataResult<User>(_userDal.Get(p => p.Id == id));
        }

        public User GetByMail(string email)
        {
            return _userDal.Get(u => u.Email == email);
        }

        public List<OperationClaim> GetClaims(User user)
        {
            return _userDal.GetClaims(user);
        }

        [CacheRemoveAspect("IUserService.Get")]
        [TransactionScopeAspect]
        public IResult Update(User user)
        {
            _userDal.Add(user);
            return new SuccessResult(Messages.CustomerAdded);
        }
    }
}

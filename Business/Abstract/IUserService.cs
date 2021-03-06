﻿using Core.Entities.Concrete;
using Core.Utilities;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IUserService
    {

        IResult Add(User user);
        IResult Update(User user);
        IResult Delete(User user);
        IDataResult<User> GetById(int id);
        IDataResult<List<User>> GetAll();
        User GetByMail(string email);
        List<OperationClaim> GetClaims(User user);
    }
}

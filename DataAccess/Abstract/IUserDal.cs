using Core;
using Core.Entities.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IUserDal:IEntityReposity<User>
    {
        List<OperationClaim> GetClaims(User user);  //veri tabanından operation claimlerini çeker bu operasyon.
    }
}

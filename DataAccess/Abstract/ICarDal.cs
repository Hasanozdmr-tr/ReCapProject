using Core;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface ICarDal: IEntityReposity<Car>
    {
        List<CarDetailDto> GetCarDetail();
    }
}

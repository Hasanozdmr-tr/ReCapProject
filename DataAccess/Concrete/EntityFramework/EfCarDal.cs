using Core.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete
{
    public class EfCarDal : EfEntityRepositoryBase<Car, ReCapProjectContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetail()
        {
            using(ReCapProjectContext context = new ReCapProjectContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands on c.BrandId equals b.BrandId
                             join cl in context.Colors on c.ColorId equals cl.ColorId

                             select new CarDetailDto
                             {
                                 CarName = c.Description,
                                 BrandName = b.BrandName,
                                 DailyPrice = c.DailyPrice,
                                 ColorName = cl.ColorName
                             };


                return result.ToList();
;
            }
        }
    }
}

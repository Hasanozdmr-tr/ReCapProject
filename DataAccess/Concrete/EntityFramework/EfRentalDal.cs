using Core.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, ReCapProjectContext>, IRentalDal
    {
      public List<RentalDetailDto> GetRentalDetails()
        {
            using(ReCapProjectContext context = new ReCapProjectContext())

            {
                var result = from c in context.Cars
                             join r in context.Rentals on c.CarId equals  r.CarId
                             join b in context.Brands on c.BrandId equals b.BrandId
                             join cu in context.Customers on r.CustomerId equals cu.CustomerId
                             join u in context.Users on cu.UserId equals u.Id
                             
                             select new RentalDetailDto
                             {
                                 RentalId = r.Id,
                                 CarId = c.CarId,
                                 BrandName = b.BrandName,
                                 CompanyName = cu.CompanyName,
                                 Decription = c.Description,
                                 ModelYear = c.ModelYear,
                                 RentDate = r.RentDate,
                                 ReturnDate = r.ReturnDate,
                                DailyPrice = c.DailyPrice,
                                 FirstName = u.FirstName,
                                 LastName = u.LastName
                             };

                             return result.ToList();


            }
        }
            
        
    }
}

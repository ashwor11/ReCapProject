using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal:EfEntityRepositoryBase<Rental,ReCapContext>,IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails()
        {
            using (ReCapContext context=new ReCapContext())
            {
                var result = from c in context.Cars
                    join r in context.Rentals on c.CarId equals r.CarId
                    join k in context.Customers on r.CustomerId equals k.UserId
                    select new RentalDetailDto()
                    {
                        RentalId = r.RentalId, CustomerId = k.UserId, CompanyName = k.CompanyName, CarId = c.CarId,
                        CarName = c.CarName, RentDate = r.RentDate, ReturnDate = r.ReturnDate
                    };
                return result.ToList();
            }
        }
    }
}

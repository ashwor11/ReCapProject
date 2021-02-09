using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using Remotion.Linq.Clauses;

namespace DataAccess.Concrete.EntityFramework
{
    public class EFCarDal:EfEntityRepositoryBase<Car,ReCapContext>,ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (ReCapContext context=new ReCapContext())
            {
                var result = from c in context.Cars
                    join b in context.Brands on c.BrandId equals b.BrandId
                    join p in context.Colors on c.ColorId equals p.ColorId
                    select new CarDetailDto
                    {
                        CarName = c.CarName, DailyPrice = c.DailyPrice, BrandName = b.BrandName, ColorName = p.ColorName
                    };
                return result.ToList();
            }   
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class EFCarDal:ICarDal
    {
        public Car Get(Expression<Func<Car, bool>> filter)
        {
            using (ReCapContext context=new ReCapContext())
            {
                return context.Set<Car>().SingleOrDefault(filter);
            }
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            using (ReCapContext context=new ReCapContext())
            {
                return filter == null ? context.Set<Car>().ToList() : context.Set<Car>().Where((filter)).ToList();
            }
        }

        public void Add(Car entity)
        {
            using (ReCapContext context = new ReCapContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();

            }
        }

        public void Update(Car entity)
        {
            using (ReCapContext context=new ReCapContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void Delete(Car entity)
        {
            using (ReCapContext context=new ReCapContext())
            {
                var deletedEntity = context.Entry((entity));
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }


        public List<Car> GetCarsByBrandId(int brandId)
        {
            using (ReCapContext context=new ReCapContext())
            {
                return context.Set<Car>().Where(c => c.BrandId == brandId).ToList();
            }
        }

        public List<Car> GetCarsByColorId(int colorId)
        {
            using (ReCapContext context=new ReCapContext())
            {
                return context.Set<Car>().Where(c => c.ColorId == colorId).ToList();
            }
        }
    }
}

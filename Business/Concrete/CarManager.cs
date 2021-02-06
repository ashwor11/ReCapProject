using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public void Add(Car car)
        {
            while (car.DailyPrice<=0)
            {
                Console.Write("DailyPrice must be higher than 0:");
                car.DailyPrice= Convert.ToDecimal(Console.ReadLine());
            }
            _carDal.Add(car);
            
        }

        public void Delete(Car car)
        {
            _carDal.Delete(car);
        }

        public List<Car> GetCarsByBrandId(int brandId)
        {
           return _carDal.GetCarsByBrandId(brandId);
        }

        public List<Car> GetCarsByColorId(int colorId)
        {
            return _carDal.GetCarsByColorId(colorId);
        }

        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        

        public void Update(Car car)
        {
            while (car.DailyPrice <= 0)
            {
                Console.WriteLine("DailyPrice must be higher than 0:");
                car.DailyPrice = Convert.ToDecimal(Console.ReadLine());
            }
            _carDal.Add(car);
        }
    }
}

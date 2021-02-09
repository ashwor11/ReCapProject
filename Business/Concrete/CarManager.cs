using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entities.DTOs;

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
            return _carDal.GetAll(p => p.BrandId == brandId).ToList();
        }

        public List<Car> GetCarsByColorId(int colorId)
        {
            return _carDal.GetAll(p => p.ColorId == colorId);
        }

        public List<Car> GetCarsByModelYear(int ModelYear)
        {
            return _carDal.GetAll(p => p.ModelYear == ModelYear);
        }

        public List<Car> GetCarsByPrices(decimal minPrice, decimal maxPrice)
        {
            return _carDal.GetAll(p => p.DailyPrice >= minPrice && p.DailyPrice <= maxPrice);
        }

        public List<CarDetailDto> GetCarDetalis()
        {
            return _carDal.GetCarDetails();
        }

        public Car Get(int id)
        {
            return _carDal.Get(p => p.CarId ==id );
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

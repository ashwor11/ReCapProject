using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using Entities.DTOs;
using FluentValidation;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {
            _carDal.Add(car);
            return new SuccessResult();

        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult();
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int brandId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.BrandId == brandId).ToList());
        }

        public IDataResult<List<Car>> GetCarsByColorId(int colorId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.ColorId == colorId));
        }

        public IDataResult<List<Car>> GetCarsByModelYear(int ModelYear)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.ModelYear == ModelYear));
        }

        public IDataResult<List<Car>> GetCarsByPrices(decimal minPrice, decimal maxPrice)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.DailyPrice >= minPrice && p.DailyPrice <= maxPrice));
        }

        public IDataResult<List<CarDetailDto>> GetCarDetalis()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());
        }

        public IDataResult<List<CarsReadyForRentDto>> GeGetCarsReadyForRent()
        {
            return new SuccessDataResult<List<CarsReadyForRentDto>>(_carDal.GetCarsReadyForRent());
        }

        public IDataResult<Car> Get(int id)
        {
            return new  SuccessDataResult<Car>(_carDal.Get(p => p.CarId ==id ));
        }

        public IDataResult<List<Car>> GetAll()
        {
            return new  SuccessDataResult<List<Car>>(_carDal.GetAll(),Messages.CarsListed);
        }

        
        [ValidationAspect(typeof(CarValidator))]
        public IResult Update(Car car)
        {
            
            _carDal.Update(car);
            return new SuccessResult();
        }
    }
}

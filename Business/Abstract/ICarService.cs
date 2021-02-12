using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Core.Utilities.Results;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface ICarService
    {
        IDataResult<Car> Get(int id);
        IDataResult<List<Car>> GetAll();
        IResult Add(Car car);
        IResult Update(Car car);
        IResult Delete(Car car);
        IDataResult<List<Car>> GetCarsByBrandId(int brandId);
        IDataResult<List<Car>> GetCarsByColorId(int colorId);
        IDataResult<List<Car>> GetCarsByModelYear(int ModelYear);
        IDataResult<List<Car>> GetCarsByPrices(decimal minPrice, decimal maxPrice);
        IDataResult<List<CarDetailDto>> GetCarDetalis();
        IDataResult<List<CarsReadyForRentDto>> GeGetCarsReadyForRent();
    }

    

    
}

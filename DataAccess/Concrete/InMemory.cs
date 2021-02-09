using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;
using Entities.DTOs;

namespace DataAccess.Concrete
{
    public class InMemory : ICarDal
    {
        List<Car> _cars;
        List<Color> _colors;
        List<Brand> _brands;

        public InMemory()
        {
            _cars = new List<Car>()
            {
                new Car {CarId=1,BrandId=1,ColorId=1,DailyPrice=100, ModelYear=2002,Description="For families"},
                new Car {CarId=2,BrandId=1,ColorId=2,DailyPrice=100, ModelYear=2002,Description="For families"},
                new Car {CarId=3,BrandId=2,ColorId=1,DailyPrice=50, ModelYear=2002,Description="Ideal for beginners"},
                new Car {CarId=4,BrandId=2,ColorId=3,DailyPrice=75, ModelYear=2002,Description="For who likes adreline"},
                new Car {CarId=5,BrandId=3,ColorId=4,DailyPrice=60, ModelYear=2002,Description="For families"},
                new Car {CarId=6,BrandId=4,ColorId=5,DailyPrice=80, ModelYear=2002,Description="Ideal for beginners"},
                new Car {CarId=7,BrandId=4,ColorId=6,DailyPrice=55, ModelYear=2002,Description="For families"},
            };

            _colors = new List<Color>()
            {
                new Color { ColorId=1, ColorName="Black"},
                new Color { ColorId=2, ColorName="White"},
                new Color { ColorId=3, ColorName="Grey"},
                new Color { ColorId=4, ColorName="Blue"},
                new Color { ColorId=5, ColorName="Yellow"},
                new Color { ColorId=6, ColorName="Cyan"},
            };
            _brands = new List<Brand>()
            {
                new Brand { BrandId=1, BrandName="BMW"},
                new Brand { BrandId=2, BrandName="Mercedes"},
                new Brand { BrandId=3, BrandName="Renault"},
                new Brand { BrandId=4, BrandName="Toyota"},
            };
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car CarToDelete;
            CarToDelete = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            _cars.Remove(CarToDelete);
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public Car GetById(int CarId)
        {
            return _cars.SingleOrDefault(c => c.CarId == CarId);
        }

        public void ListByBrands(int BrandId)
        {
            foreach (var item in _cars)
            {
                if (item.BrandId == BrandId)
                {
                   
                        string color = _colors.SingleOrDefault(c => c.ColorId == item.ColorId).ColorName;
                        string brand = _brands.SingleOrDefault(c => c.BrandId == item.BrandId).BrandName;

                        Console.WriteLine(item.CarId + " " + brand + " " + item.ModelYear + " " + color + " " + item.DailyPrice + "$" + " " + item.Description);
                    
                }
            }
        }

        public void ListByColors(int ColorId)
        {
            foreach (var item in _cars)
            {
                if (item.ColorId == ColorId)
                {

                    string color = _colors.SingleOrDefault(c => c.ColorId == item.ColorId).ColorName;
                    string brand = _brands.SingleOrDefault(c => c.BrandId == item.BrandId).BrandName;

                    Console.WriteLine(item.CarId + " " + brand + " " + item.ModelYear + " " + color + " " + item.DailyPrice + "$" + " " + item.Description);

                }
            }
        }

        public void ListCars()
        {
            foreach (var item in _cars)
            {
                string color = _colors.SingleOrDefault(c => c.ColorId == item.ColorId).ColorName;
                string brand = _brands.SingleOrDefault(c => c.BrandId == item.BrandId).BrandName;

                Console.WriteLine(item.CarId + " " + brand + " " + item.ModelYear + " " + color + " " + item.DailyPrice + "$" + " " + item.Description);
            }
        }

        public void Update(Car car)
        {
            Car CarToUpdate;
            CarToUpdate = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            CarToUpdate.BrandId = car.BrandId;
            CarToUpdate.ColorId = car.ColorId;
            CarToUpdate.DailyPrice = car.DailyPrice;
            CarToUpdate.Description = car.Description;
            CarToUpdate.ModelYear = car.ModelYear;
        }

        public List<Car> GetCarsByBrandId(int brandId)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetCarsByColorId(int colorId)
        {
            throw new NotImplementedException();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Business.Concrete
{
    public class RentalManager:IRentalService
    {
        private IRentalDal _rentalDal;
        private ICarDal _carDal;

        public RentalManager(IRentalDal rentalDal,ICarDal carDal)
        {
            _rentalDal = rentalDal;
            _carDal = carDal;
        }
        public IDataResult<Rental> Get(int id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(p => p.RentalId == id));
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
        }

        public IResult Add(Rental rental)
        {
            Car car;
            car = _carDal.Get(c => c.CarId == rental.CarId);
            if (car.Available)
            {
                _rentalDal.Add(rental);
                car.Available = false;
                _carDal.Update(car);
                Console.WriteLine(car.Available);
                
                return new SuccessResult(Messages.RentalIsSucced);
                
            }
            else
            {
                return new ErrorResult(Messages.CarNotAvailable);
            }
            
        }

        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult();
        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult();
        }

        public IDataResult<List<Rental>> GetNonReturned()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(p => p.ReturnDate ==Convert.ToDateTime("1900-01-01") ));
        }

        public IResult FinishRental(Rental rental)
        {
            var finishedRental = _rentalDal.Get(r => r.RentalId == rental.RentalId);
            finishedRental.ReturnDate = System.DateTime.Now;
            _rentalDal.Update(finishedRental);
            var car = _carDal.Get(c => c.CarId == rental.CarId);
            car.Available = true;
            _carDal.Update(car);

            
            return new SuccessResult(Messages.RentalFinishedSuccesfully);
        }

        public IDataResult<List<RentalDetailDto>> GetRentalDetails()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails());
        }
    }
}

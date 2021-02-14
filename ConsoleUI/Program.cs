using Business.Concrete;
using DataAccess.Concrete;
using Entities.Concrete;
using System;
using System.Threading;
using DataAccess.Concrete.EntityFramework;

namespace ConsoleUI
{
    class Program
    {
        
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EFCarDal());
            ColorManager colorManager = new ColorManager(new EFColorDal());
            BrandManager brandManager = new BrandManager(new EFBrandDal());
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            RentalManager rentalManager = new RentalManager(new EfRentalDal(),new EFCarDal());
            //TestinAllEntities(carManager, brandManager, colorManager);
            //GetCarDetails(carManager);
            //RentalTesst(rentalManager, carManager);
            var result = carManager.GetAll();
            if (result.Success)
            {
                foreach (var VARIABLE in result.Data)
                {
                    Console.WriteLine(VARIABLE.CarName);
                }
            }
        }

        private static void RentalTesst(RentalManager rentalManager, CarManager carManager)
        {
            var result = rentalManager.Add(new Rental()
            {
                CarId = 2, ReturnDate = Convert.ToDateTime("01.01.1900"), CustomerId = 1,
                RentDate = Convert.ToDateTime("11.02.2021")
            });
            if (result.Success)
            {
                Console.WriteLine(result.Message);
            }
            else
            {
                Console.WriteLine(result.Message);
            }

            var result1 = carManager.Get(2);
            Console.WriteLine(result1.Data.Available);
            var result2 = rentalManager.FinishRental(rentalManager.Get(12).Data);
            if (result2.Success)
            {
                Console.WriteLine(result2.Message);
            }

            var result3 = rentalManager.GetRentalDetails();
            if (result3.Success)
            {
                foreach (var VARIABLE in result3.Data)
                {
                    Console.WriteLine(
                        "Rental Id:{0} Customer Id:{1} Company Name={2} Car Id:{3} Car Name:{4} Rent Date:{5} Return Date:{6}",
                        VARIABLE.RentalId, VARIABLE.CustomerId, VARIABLE.CompanyName, VARIABLE.CarId, VARIABLE.CarName,
                        VARIABLE.RentDate, VARIABLE.ReturnDate);
                }
            }
        }

        private static void GetCarDetails(CarManager carManager)
        {
            var result = carManager.GetCarDetalis();
            if (result.Success)
            {
                foreach (var VARIABLE in result.Data)
                {
                    Console.WriteLine("Brand Name:{0} Car Name:{1} Color Name:{2} Daily Price:{3}$", VARIABLE.BrandName,
                        VARIABLE.CarName, VARIABLE.ColorName, VARIABLE.DailyPrice);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        
    }
}

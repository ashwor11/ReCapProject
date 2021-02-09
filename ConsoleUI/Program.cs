using Business.Concrete;
using DataAccess.Concrete;
using Entities.Concrete;
using System;
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


            //TestinAllEntities(carManager, brandManager, colorManager);
            foreach (var VARIABLE in carManager.GetCarDetalis())
            {
                Console.WriteLine("Brand Name:{0} Car Name:{1} Color Name:{2} Daily Price:{3}$",VARIABLE.BrandName,VARIABLE.CarName,VARIABLE.ColorName,VARIABLE.DailyPrice);
            }
        }

        private static void TestinAllEntities(CarManager carManager, BrandManager brandManager, ColorManager colorManager)
        {
            foreach (var asdas in carManager.GetCarsByBrandId(1))
            {
                Console.WriteLine(asdas.DailyPrice);
            }

            foreach (var VARIABLE in brandManager.GetAll())
            {
            }

            Console.WriteLine(brandManager.Get(1).BrandName);
            Console.WriteLine(colorManager.Get(1).ColorName);
        }
    }
}

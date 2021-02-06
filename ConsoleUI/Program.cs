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


            foreach (var asdas in carManager.GetCarsByBrandId(1))
            {
                Console.WriteLine(asdas.DailyPrice);
            }

            foreach (var VARIABLE in carManager.GetAll())
            {
                
            }





        }
    }
}

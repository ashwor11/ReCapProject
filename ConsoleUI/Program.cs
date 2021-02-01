using Business.Concrete;
using DataAccess.Concrete;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new InMemory());
            foreach (var item in carManager.GetAll())
            {
                Console.WriteLine(item.ColorId);
            }
            Console.ReadLine();
            carManager.ListCars();
            Console.ReadLine();
            carManager.Add(new Car { CarId = 8, BrandId = 3, ColorId = 4, DailyPrice = 100, ModelYear = 2002, Description = "For families" });
            carManager.ListCars();
            Console.ReadLine();
            Car car1 = new Car() { CarId = 9, BrandId = 2, ColorId = 3, DailyPrice = 100, ModelYear = 2003, Description = "For families" };
            carManager.Add(car1);
            carManager.ListCars();
            carManager.Delete(car1);
            Console.ReadLine();
            carManager.ListCars();
            Console.ReadLine();
            Console.WriteLine(carManager.GetById(1).Description);
            Console.ReadLine();
            carManager.ListByBrands(2);
            Console.ReadLine();
            carManager.ListByColors(3);
            Console.ReadLine();
            Car car2 = new Car() { CarId = 5, BrandId = 2, ColorId = 3, DailyPrice = 105, ModelYear = 2003, Description = "For families" };
            carManager.Update(car2);
            carManager.ListCars();
            


            Console.ReadLine();
        }
    }
}

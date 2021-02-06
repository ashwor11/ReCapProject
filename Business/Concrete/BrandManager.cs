using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class BrandManager:IBrandService
    {
        private IBrandDal _brandDal;
        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }


        public Brand Get(int id)
        {
            return _brandDal.Get(p=>p.BrandId==id);
        }

        public List<Brand> GetAll()
        {
            return _brandDal.GetAll();
        }

        public void Add(Brand brand)
        {
            while (brand.BrandName.Length<=2)
            {
                Console.Write("Brand name's length must be longer than 2:");
                brand.BrandName=Console.ReadLine();
            }
            _brandDal.Add(brand);
        }

        public void Update(Brand brand)
        {
            while (brand.BrandName.Length <= 2)
            {
                Console.Write("Brand name's length must be longer than 2:");
                brand.BrandName = Console.ReadLine();
            }
            _brandDal.Update(brand);
        }

        public void Delete(Brand brand)
        {
            _brandDal.Delete(brand);
        }
    }
}

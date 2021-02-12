using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IBrandService
    {
        IDataResult<Brand> Get(int id);
        IDataResult<List<Brand>> GetAll();
        IResult Add(Brand brand);
        IResult Update(Brand brand);
        IResult Delete(Brand brand
        );
    }
}


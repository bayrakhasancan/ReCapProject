﻿using Business.Abstract;
using Core.Business;
using Core.DataAccess;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.Concrete
{
    public class BrandManager : BusinessBase<Brand> , IBrandService
    {
        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal) : base(brandDal)
        {
            _brandDal = brandDal;
        }
    }
}

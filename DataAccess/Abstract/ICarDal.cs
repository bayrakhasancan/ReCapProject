﻿using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface ICarDal
    {
        Car GetById(uint carId);
        List<Car> GetAll();
        void Add(Car car);
        void Update(Car car);
        void Delete(ushort carId);
    }
}

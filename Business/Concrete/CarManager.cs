using Business.Abstract;
using Core.Business;
using Core.DataAccess;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : BusinessBase<Car>,ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal) :base(carDal)
        {
            _carDal = carDal;
        }

        public override void Add(Car car)
        {
            if (car.Description.Length < 2)
            {
                throw new Exception("Car's name length must be minimum 2");
            }
            if (car.DailyPrice < 1)
            {
                throw new Exception("Car's daily price cannot be lower than 0");
            }

            base.Add(car);
        }
    }
}

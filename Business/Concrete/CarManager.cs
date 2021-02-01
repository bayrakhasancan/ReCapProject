using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService, ICarDal
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public void Add(Car car)
        {
            //Business rules

            _carDal.Add(car);
        }

        public void Delete(ushort carId)
        {
            //Business rules

            _carDal.Delete(carId);
        }

        public void Update(Car car)
        {
            //Business rules

            _carDal.Update(car);
        }

        public List<Car> GetAll()
        {
            //Business rules

            return _carDal.GetAll();
        }

        public Car GetById(uint carId)
        {
            //Business rules

            return _carDal.GetById(carId);
        }
    }
}

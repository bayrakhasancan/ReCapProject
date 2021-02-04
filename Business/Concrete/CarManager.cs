using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        IBrandDal _brandDal;

        public CarManager(ICarDal carDal, IBrandDal brandDal)
        {
            _carDal = carDal;
            _brandDal = brandDal;
        }

        public void Add(Car car)
        {
            var brandName = _brandDal.Get(x=>x.Id == car.BrandId).Name;

            if (brandName.Length < 2)
            {
                throw new Exception("Car's name length must be minimum 2");
            }
            if (car.DailyPrice < 1)
            {
                throw new Exception("Car's daily price cannot be lower than 0");
            }

            _carDal.Add(car);
        }

        public void Delete(Car car)
        {
            //Business rules

            _carDal.Delete(car);
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

        public List<Car> GetCarsByBrandId(ushort brandId)
        {
            return _carDal.GetAll(x => x.BrandId == brandId);
        }

        public List<Car> GetCarsByColorId(uint colorId)
        {
            return _carDal.GetAll(x => x.ColorId == colorId);
        }
    }
}

using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.DataAccess;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        readonly ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {
            if (car.Description.Length < 2)
            {
                return new ErrorResult(Messages.CarNameMinumumError);
            }
            if (car.DailyPrice < 1)
            {
                return new ErrorResult(Messages.DailyPriceError);
            }

            _carDal.Add(car);

            return new SuccessResult(Messages.CarAdded);
        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);

            return new SuccessResult(Messages.CarDeleted);
        }

        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(Messages.CarsListed, _carDal.GetAll());
        }

        public IDataResult<List<Car>> GetCarsByBrandId(ushort brandId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(x => x.BrandId == brandId));
        }

        public IDataResult<List<Car>> GetCarsByColorId(uint colorId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(x => x.ColorId == colorId));
        }

        public IResult Update(Car car)
        {
            _carDal.Update(car);

            return new SuccessResult(Messages.CarUpdated);
        }
    }
}
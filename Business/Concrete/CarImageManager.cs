using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Business;
using Core.Utilities.Helper.FileHelper;
using Core.Utilities.Helper.FileHelper.ImageHelper;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        readonly ICarImageDal _carImageDal;
        readonly IFileHelper _imageHelper;
        readonly CarImage defaultImage = new CarImage { ImagePath = "default.jpg" };

        public CarImageManager(ICarImageDal carImageDal, IFileHelper fileHelper)
        {
            _carImageDal = carImageDal;
            _imageHelper = fileHelper;
        }

        [ValidationAspect(typeof(FormFileValidator))]
        public IResult Add(CarImage carImage, IFormFile formFile)
        {
            var businessRuleResult = BusinessRules.Run(CheckCarImageCount(carImage.CarId));

            if (businessRuleResult != null)
            {
                return businessRuleResult;
            }

            carImage.Date = DateTime.Now;
            carImage.ImagePath = _imageHelper.Save(formFile);
            _carImageDal.Add(carImage);

            return new SuccessResult(Messages.CarImageAdded);
        }
        public IResult Delete(CarImage carImage)
        {
            _imageHelper.Delete(carImage.ImagePath);
            _carImageDal.Delete(carImage);
            return new SuccessResult(Messages.CarImageDeleted);
        }
        public IDataResult<List<CarImage>> GetAll()
        {
            var result = _carImageDal.GetAll();
            return new SuccessDataResult<List<CarImage>>(Messages.CarImagesListed, result);
        }
        public IDataResult<List<CarImage>> GetImagesByCarId(int carId)
        {
            var result = _carImageDal.GetAll(x => x.CarId == carId);

            if (result.Count == 0)
            {
                List<CarImage> defaultImageList = new List<CarImage>
                {
                    defaultImage
                };

                return new SuccessDataResult<List<CarImage>>(defaultImageList);
            }
            return new SuccessDataResult<List<CarImage>>(result);
        }

        [ValidationAspect(typeof(FormFileValidator))]
        public IResult Update(CarImage carImage, IFormFile formFile)
        {
            var oldCarImage = _carImageDal.Get(x => x.Id == carImage.Id);

            _imageHelper.Delete(oldCarImage.ImagePath);
            carImage.ImagePath = _imageHelper.Save(formFile);
            carImage.Date = DateTime.Now;

            _carImageDal.Update(carImage);
            return new SuccessResult(Messages.CarImageUpdated);
        }
        private IResult CheckCarImageCount(int carId)
        {
            var carImages = _carImageDal.GetAll(x => x.CarId == carId);

            if (carImages.Count < 5)
            {
                return new SuccessResult();
            }
            return new ErrorResult(Messages.CarImageCountExceeded);
        }

    }
}
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EFCarDal : EFEntityRepositoryBase<Car, ReCapContext>, ICarDal
    {
        public CarDetailDto GetCarDetails()
        {
            {
                using (ReCapContext context = new ReCapContext())
                {
                    var result = from c in context.Cars
                                 join b in context.Brands on c.BrandId equals b.Id
                                 join col in context.Colors on c.ColorId equals col.Id
                                 select new CarDetailDto
                                 {
                                     CarName = c.Description,
                                     ColorName = col.Name,
                                     BrandName = b.Name,
                                     DailyPrice = c.DailyPrice
                                 };

                    return result.FirstOrDefault();
                }
            }
        }
    }
}

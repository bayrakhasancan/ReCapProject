using Business.Abstract;
using Core.Business;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.Concrete
{
    public class ColorManager : BusinessBase<Color>, IColorService
    {
        IColorDal _colorDal;

        public ColorManager(IColorDal colorDal) : base(colorDal)
        {
            _colorDal = colorDal;
        }
    }
}

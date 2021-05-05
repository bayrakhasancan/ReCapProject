using Business.Constants;
using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator : AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(x => x.Description).MinimumLength(2).WithMessage(Messages.CarNameMinumumError);
            RuleFor(x => x.DailyPrice).GreaterThan(0).WithMessage(Messages.DailyPriceError);
        }
    }
}

using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.DependencyResolvers.ValidationRules.FluentValidator
{
    public class CarValidator:AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(p => p.Description).MinimumLength(2);
            RuleFor(p => p.Description).NotEmpty();
            RuleFor(p => p.CarId).NotEmpty();
            RuleFor(p => p.DailyPrice).GreaterThan(0).When(p => p.ModelYear <= 2010);
            RuleFor(p => p.Description).Must(StartWithA).WithMessage("Araba ismi A ile başlamalı");



        }

        private bool StartWithA(string arg)
        {
            return arg.StartsWith("A");
        }
    }
}

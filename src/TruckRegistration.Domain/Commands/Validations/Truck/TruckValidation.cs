using FluentValidation;
using System;

namespace TruckRegistration.Domain.Commands.Validations.Truck
{
    public abstract class TruckValidation<T> : AbstractValidator<T> where T : Entities.Truck
    {
        protected void ValidateId()
        {
            RuleFor(c => c.Id).NotEqual(Guid.Empty);
        }

        protected void ValidateDescription()
        {
            RuleFor(c => c.Description).NotEmpty().MaximumLength(100);
        }

        protected void ValidateModel()
        {
            RuleFor(c => c.Model).NotEmpty();
        }

        protected void ValidateManufactureYear()
        {
            RuleFor(c => c.ManufactureYear).NotEmpty().Equals(DateTime.Now.Year);
        }

        protected void ValidateModelYear()
        {
            RuleFor(c => c.ModelYear).NotEmpty().GreaterThanOrEqualTo(DateTime.Now.Year);
        }

        protected void ValidateRenavam()
        {
            RuleFor(c => c.Renavam).NotEmpty().MaximumLength(30);
        }

        protected void ValidateColor()
        {
            RuleFor(c => c.Color).NotEmpty().MaximumLength(30);
        }
    }
}

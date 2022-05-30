using FluentValidation;
using System;

namespace TruckRegistration.Domain.Commands.Validations.Truck
{
    public abstract class TruckValidation<T> : AbstractValidator<T> where T : Entities.Truck
    {
        protected void ValidateId()
        {
            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty);
        }

        protected void ValidateDescription()
        {
            var fieldName = "description";

            RuleFor(c => c.Description)
                .NotEmpty()
                .WithMessage(FieldIsRequired(fieldName));
        }

        protected void ValidateModel()
        {
            var fieldName = "model";

            RuleFor(c => c.Model)
                .NotEmpty()
                .WithMessage(FieldIsRequired(fieldName));
        }

        protected void ValidateManufactureYear()
        {
            var fieldName = "manufacture year";

            RuleFor(c => c.ManufactureYear)
                .NotEmpty().WithMessage(FieldIsRequired(fieldName))
                .GreaterThan(0).WithMessage($"The field is greater than zero (0) for the field {fieldName}.");
        }

        protected void ValidateModelYear()
        {
            var fieldName = "model year";

            RuleFor(c => c.ModelYear)
                .NotEmpty().WithMessage(FieldIsRequired(fieldName))
                .GreaterThan(0).WithMessage($"The field is greater than zero (0) for the field {fieldName}.");
        }
    
        protected void ValidateRenavam()
        {
            var fieldName = "renavam";

            RuleFor(c => c.Renavam)
                .NotEmpty()
                .WithMessage(FieldIsRequired(fieldName));
        }

        protected void ValidateColor()
        {
            var fieldName = "color";

            RuleFor(c => c.Color)
                .NotEmpty()
                .WithMessage(FieldIsRequired(fieldName));
        }

        private string FieldIsRequired(string fieldName)
        {
            return $"The field {fieldName} is required.";
        }
    }
}

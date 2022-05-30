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

        protected void ValidateOrigem()
        {
            var fieldName = "origem";

            RuleFor(c => c.Origem)
                .NotEmpty().WithMessage(FieldIsRequired(fieldName))
                .Length(3, 3).WithMessage($"É necessário o preenchimento do campo {fieldName} com três (03) caracteres");
        }

        protected void ValidateDestino()
        {
            var fieldName = "destino";

            RuleFor(c => c.Destino)
                .NotEmpty().WithMessage(FieldIsRequired(fieldName))
                .Length(3, 3).WithMessage($"É necessário o preenchimento do campo {fieldName} com três (03) caracteres");
        }

        protected void ValidateValor()
        {
            var fieldName = "valor";

            RuleFor(c => c.Valor)
                .NotEmpty().WithMessage(FieldIsRequired(fieldName))
                .GreaterThanOrEqualTo(0).WithMessage($"É necessário informar um valor maior que zero (0) para o campo {fieldName}.");
        }

        private string FieldIsRequired(string fieldName)
        {
            return $"Campo {fieldName} é requerido.";
        }
    }
}

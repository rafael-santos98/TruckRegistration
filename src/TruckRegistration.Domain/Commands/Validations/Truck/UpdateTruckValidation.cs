using FluentValidation;
using System;
using TruckRegistration.Domain.Contracts.Repositories;

namespace TruckRegistration.Domain.Commands.Validations.Truck
{
    public class UpdateTruckValidation : TruckValidation<Entities.Truck>
    {
        private readonly ITruckRepository _truckRepository;
        public UpdateTruckValidation(ITruckRepository truckRepository)
        {
            _truckRepository = truckRepository;
            ValidateId();
            ValidateOrigem();
            ValidateDestino();
            ValidateValor();
            ValidateExisteItem();
            //ValidateExisteOutroItem();
        }

        private void ValidateExisteItem()
        {
            RuleFor(x => x).Must(item => ExisteById(item.Id))
                .WithMessage($"A rota informada não foi localizada.");
        }

        private bool ExisteById(Guid id)
        {
            return _truckRepository.GetById(id)
                .GetAwaiter()
                .GetResult() != null;
        }

        private bool ExisteOutroItemByIdAndOrigemAndDestino(Guid id)
        {
            return _truckRepository.GetById(id)
                .GetAwaiter()
                .GetResult() != null;
        }
    }
}

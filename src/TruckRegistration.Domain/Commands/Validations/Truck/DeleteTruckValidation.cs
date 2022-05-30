using FluentValidation;
using System;
using TruckRegistration.Domain.Contracts.Repositories;

namespace TruckRegistration.Domain.Commands.Validations.Truck
{
    public class DeleteTruckValidation : TruckValidation<Entities.Truck>
    {
        private readonly ITruckRepository _truckRepository;
        public DeleteTruckValidation(ITruckRepository truckRepository)
        {
            _truckRepository = truckRepository;
            ValidateExisteItem();
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

    }
}

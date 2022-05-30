using System;
using TruckRegistration.Domain.Commands.Validations.Caminhoes;
using TruckRegistration.Domain.Contracts.Commands;
using TruckRegistration.Domain.Contracts.Repositories;
using TruckRegistration.Domain.Entities;

namespace TruckRegistration.Domain.Commands
{
    public class TruckCommandHandler : ITruckCommandHandler
    {
        private readonly ITruckRepository _truckRepository;

        public TruckCommandHandler(ITruckRepository truckRepository)
        {
            this._truckRepository = truckRepository;
        }

        public BaseResult Add(Truck truck)
        {
            try
            {
                var validationResult = new AddTruckValidation().Validate(truck);

                var baseResult = new BaseResult(validationResult);

                if (validationResult.IsValid)
                {
                    truck = _truckRepository.Add(truck);
                    baseResult = new BaseResult(validationResult, id: truck.Id, objectItem: truck);
                    _truckRepository.Commit();
                }

                return baseResult;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public BaseResult Update(Truck truck)
        {
            try
            {
                var validationResult = new UpdateTruckValidation(_truckRepository).Validate(truck);

                if (validationResult.IsValid)
                {
                    _truckRepository.Update(truck);
                    _truckRepository.Commit();
                }

                return new BaseResult(validationResult);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public BaseResult Delete(Guid id)
        {
            try
            {
                var truck = new Truck()
                {
                    Id = id
                };

                var validationResult = new DeleteTruckValidation(_truckRepository).Validate(truck);

                if (validationResult.IsValid)
                {
                    truck = _truckRepository.GetById(id).GetAwaiter().GetResult();

                    if (truck != null)
                    {
                        _truckRepository.Remove(truck);
                        _truckRepository.Commit();
                    }
                }

                return new BaseResult(validationResult);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
    }
}

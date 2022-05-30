﻿using System;
using System.Threading.Tasks;
using TruckRegistration.Domain.Commands.Validations.Truck;
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

        public async Task<BaseResult> Add(Truck truck)
        {
            try
            {
                var validationResult = new AddTruckValidation().Validate(truck);

                var baseResult = new BaseResult(validationResult);

                if (validationResult.IsValid)
                {
                    truck = await _truckRepository.SaveOrUpdate(truck);

                    if (truck != null)
                    {
                        baseResult = new BaseResult(validationResult, id: truck.Id, objectItem: truck);
                        await _truckRepository.Commit();
                    }
                }

                return baseResult;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public async Task<BaseResult> Update(Truck truck)
        {
            try
            {
                var validationResult = new UpdateTruckValidation(_truckRepository).Validate(truck);

                if (validationResult.IsValid)
                {
                    if (truck != null)
                    {
                        await _truckRepository.SaveOrUpdate(truck);
                        await _truckRepository.Commit();
                    }
                }

                return new BaseResult(validationResult);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public async Task<BaseResult> Delete(Guid id)
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
                    truck = await _truckRepository.GetById(id).ConfigureAwait(true);

                    if (truck != null)
                    {
                        _truckRepository.Remove(truck);
                        await _truckRepository.Commit();
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

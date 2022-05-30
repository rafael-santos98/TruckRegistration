using System;
using TruckRegistration.Domain.Entities;

namespace TruckRegistration.Domain.Contracts.Commands
{
    public interface ITruckCommandHandler
    {
        BaseResult Add(Truck truck);
        BaseResult Update(Truck truck);
        BaseResult Delete(Guid id);
    }
}

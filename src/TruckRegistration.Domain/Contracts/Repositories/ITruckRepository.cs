using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TruckRegistration.Domain.Entities;

namespace TruckRegistration.Domain.Contracts.Repositories
{
    public interface ITruckRepository
    {
        Task<IEnumerable<Truck>> GetAll(bool asNoTracking = true);
        Task<Truck> GetById(Guid id, bool asNoTracking = true);
        Truck Add(Truck truck);
        void Update(Truck truck);
        void Remove(Truck truck);
        void Commit();
    }
}

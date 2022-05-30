using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TruckRegistration.Domain.Contracts.Repositories;
using TruckRegistration.Domain.Entities;
using TruckRegistration.Infra.Data.Context;

namespace TruckRegistration.Infra.Data.Respositories
{
    public class TruckRepository : ITruckRepository
    {
        protected readonly DataContext Db;
        protected readonly DbSet<Truck> DbSet;

        public TruckRepository(DataContext context)
        {
            Db = context;
            DbSet = Db.Set<Truck>();
        }

        public async Task<IEnumerable<Truck>> GetAll(bool asNoTracking = true)
        {
            if (!asNoTracking)
            {
                return await Db.Truck.ToListAsync();
            }

            return await Db.Truck.AsNoTracking().ToListAsync();
        }

        public async Task<Truck> GetById(Guid id, bool asNoTracking = true)
        {
            if (!asNoTracking)
            {
                return await Db.Truck
                    .Where(r => r.Id.Equals(id))
                    .FirstOrDefaultAsync();
            }

            return await Db.Truck
                .Where(r => r.Id.Equals(id))
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }

        public Truck Add(Truck truck)
        {
            DbSet.Add(truck);
            return truck;
        }

        public void Update(Truck truck)
        {
            DbSet.Update(truck);
            Commit();
        }

        public void Remove(Truck truck)
        {
            DbSet.Remove(truck);
            Commit();
        }

        public void Commit()
        {
            Db.SaveChanges();
        }

        public void Dispose()
        {
            Db.Dispose();
        }
    }
}

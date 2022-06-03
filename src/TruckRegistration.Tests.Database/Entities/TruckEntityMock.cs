using System;
using System.Collections.Generic;
using System.Linq;
using TruckRegistration.Domain.Entities;
using TruckRegistration.Tests.Database.Utils;

namespace TruckRegistration.Tests.Database.Entities
{
    public static class TruckEntityMock
    {
        public static Truck GetTruck(bool withGuidId = true)
        {
            return GetTruckList(withGuidId).FirstOrDefault();
        }

        public static List<Truck> GetTruckList(bool withGuidId = true, int itemsToGenerate = 5)
        {
            var trucks = new List<Truck>();

            while (itemsToGenerate > 0)
            {
                var modelGenerated = TruckRandomUtil.GetRandomModel();

                trucks.Add(new Truck()
                {
                    Id = withGuidId ? System.Guid.NewGuid() : new System.Guid(),
                    Description = $"Volvo {modelGenerated.ToString()}",
                    Model = modelGenerated,
                    ManufactureYear = DateTime.Now.Year,
                    ModelYear = TruckRandomUtil.GetRandomModelYear(),
                    Renavam = TruckRandomUtil.GetRandomRenavan(),
                    Color = TruckRandomUtil.GetRandomColor()
                });

                itemsToGenerate = itemsToGenerate - 1;
            }

            return trucks;
        }
    }
}

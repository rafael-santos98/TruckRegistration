
using System;
using System.Collections.Generic;
using System.Linq;
using TruckRegistration.Domain.Entities;
using TruckRegistration.Domain.Entities.Enums;

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
                var modelGenerated = GetRandomModel();

                trucks.Add(new Truck()
                {
                    Id = withGuidId ? System.Guid.NewGuid() : new System.Guid(),
                    Description = $"Volvo {modelGenerated.ToString()}",
                    Model = modelGenerated,
                    ManufactureYear = 2022,
                    ModelYear = 2023,
                    Renavam = GetRandomRenavan(),
                    Color = GetRandomColor()
                });

                itemsToGenerate = itemsToGenerate -1;
            }

            return trucks;
        }

        private static EModel GetRandomModel()
        {
            var models = Enum.GetValues(typeof(EModel));

            var modelItem = (EModel)models
                .GetValue(new Random()
                .Next(models.Length));

            return modelItem;
        }

        private static string GetRandomRenavan()
        {
            return new Random().Next(10000000, 99999999)
                .ToString()
                .PadLeft(8, '0');
        }

        private static string GetRandomColor()
        {
            var models = new string[] { "White", "Blue", "Black" };

            return (string)models.GetValue(new Random().Next(models.Length));
        }
    }
}

using System.Collections.Generic;
using System.Linq;
using TruckRegistration.Application.Models.Response;
using TruckRegistration.Domain.Entities;

namespace TruckRegistration.Tests.Entities
{
    public static class TruckEntityMock
    {
        public static Truck GetTruck()
        {
            return GetTruckList().FirstOrDefault();
        }

        public static List<Truck> GetTruckList()
        {
            return new List<Truck>{
                new Truck()
                {
                    Id = new System.Guid(),
                    Description = "",
                    Model = Domain.Entities.Enums.EModel.FM,
                    ManufactureYear = 2022,
                    ModelYear = 2023,
                    Renavam = "30808965591",
                    Color = "Color"
                },
                new Truck()
                {
                    Id = new System.Guid(),
                    Description = "",
                    Model = Domain.Entities.Enums.EModel.FM,
                    ManufactureYear = 2022,
                    ModelYear = 2023,
                    Renavam = "22709827033",
                    Color = "White"
                }
            };
        }

        public static TruckResponse GetTruckResponse()
        {
            return GetTruckResponseList().FirstOrDefault();
        }

        public static List<TruckResponse> GetTruckResponseList()
        {
            return new List<TruckResponse>{
                new TruckResponse()
                {
                    Id = new System.Guid(),
                    Description = "",
                    Model = Domain.Entities.Enums.EModel.FM,
                    ManufactureYear = 2022,
                    ModelYear = 2023,
                    Renavam = "30808965591",
                    Color = "Color"
                },
                new TruckResponse()
                {
                    Id = new System.Guid(),
                    Description = "",
                    Model = Domain.Entities.Enums.EModel.FM,
                    ManufactureYear = 2022,
                    ModelYear = 2023,
                    Renavam = "22709827033",
                    Color = "White"
                }
            };
        }
    }
}

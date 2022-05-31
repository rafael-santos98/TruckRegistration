using System.Collections.Generic;
using System.Linq;
using TruckRegistration.Application.Models.Request;
using TruckRegistration.Application.Models.Response;
using TruckRegistration.Domain.Entities;

namespace TruckRegistration.Tests.Entities
{
    public static class TruckEntityMock
    {
        public static Truck GetTruck(bool withGuidId = true)
        {
            return GetTruckList(withGuidId).FirstOrDefault();
        }

        public static List<Truck> GetTruckList(bool withGuidId = true)
        {
            return new List<Truck>{
                new Truck()
                {
                    Id = withGuidId ? System.Guid.NewGuid() : new System.Guid(),
                    Description = "Volvo FM",
                    Model = Domain.Entities.Enums.EModel.FM,
                    ManufactureYear = 2022,
                    ModelYear = 2023,
                    Renavam = "30808965591",
                    Color = "Color"
                },
                new Truck()
                {
                    Id = withGuidId ? System.Guid.NewGuid() : new System.Guid(),
                    Description = "Volvo FH",
                    Model = Domain.Entities.Enums.EModel.FH,
                    ManufactureYear = 2022,
                    ModelYear = 2023,
                    Renavam = "22709827033",
                    Color = "White"
                }
            };
        }

        public static TruckResponse GetTruckResponse(bool withGuidId = true)
        {
            return GetTruckResponseList(withGuidId).FirstOrDefault();
        }

        public static List<TruckResponse> GetTruckResponseList(bool withGuidId = true)
        {
            return new List<TruckResponse>{
                new TruckResponse()
                {
                    Id = withGuidId ? System.Guid.NewGuid() : new System.Guid(),
                    Description = "",
                    Model = Domain.Entities.Enums.EModel.FM,
                    ManufactureYear = 2022,
                    ModelYear = 2023,
                    Renavam = "30808965591",
                    Color = "Color"
                },
                new TruckResponse()
                {
                    Id = withGuidId ? System.Guid.NewGuid() : new System.Guid(),
                    Description = "",
                    Model = Domain.Entities.Enums.EModel.FM,
                    ManufactureYear = 2022,
                    ModelYear = 2023,
                    Renavam = "22709827033",
                    Color = "White"
                }
            };
        }

        public static AddTruckRequest GetAddTruckRequest()
        {
            return GetAddTruckRequestList().FirstOrDefault();
        }

        public static List<AddTruckRequest> GetAddTruckRequestList()
        {
            return new List<AddTruckRequest>{
                new AddTruckRequest()
                {
                    Description = "Volvo FM",
                    Model = Domain.Entities.Enums.EModel.FM,
                    ManufactureYear = 2022,
                    ModelYear = 2023,
                    Renavam = "30808965591",
                    Color = "Color"
                },
                new AddTruckRequest()
                {
                    Description = "Volvo FH",
                    Model = Domain.Entities.Enums.EModel.FH,
                    ManufactureYear = 2022,
                    ModelYear = 2023,
                    Renavam = "22709827033",
                    Color = "White"
                }
            };
        }
    }
}

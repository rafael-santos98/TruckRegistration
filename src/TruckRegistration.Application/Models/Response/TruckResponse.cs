using System;
using TruckRegistration.Domain.Entities.Enums;

namespace TruckRegistration.Application.Models.Response
{
    public class TruckResponse
    {
        public Guid Id { get; set; }
        public EModel? Model { get; set; }
        public int? ManufactureYear { get; set; }
        public int? ModelYear { get; set; }
    }
}

using TruckRegistration.Domain.Entities.Enums;

namespace TruckRegistration.Application.Models.Request
{
    public class UpdateTruckRequest
    {
        public EModel? Model { get; set; }
        public int? ManufactureYear { get; set; }
        public int? ModelYear { get; set; }
    }
}

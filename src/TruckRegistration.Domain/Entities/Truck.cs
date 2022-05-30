using TruckRegistration.Domain.Entities.Enums;

namespace TruckRegistration.Domain.Entities
{
    public class Truck : BaseEntity
    {
        public EModel? Model { get; set; }
        public int? ManufactureYear { get; set; }
        public int? ModelYear { get; set; }

    }
}

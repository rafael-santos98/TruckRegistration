using TruckRegistration.Domain.Entities.Enums;

namespace TruckRegistration.Domain.Entities
{
    public class Truck : BaseEntity
    {
        public Truck()
        {

        }

        public Truck(string description, EModel? model, int? manufactureYear, int? modelYear, string chassi, string renavam)
        {
            this.Description = description;
            this.Model = model;
            this.ManufactureYear = manufactureYear;
            this.ModelYear = modelYear; 
            this.Chassi = chassi;
            this.Renavam = renavam;
        }

        public string Description { get; set; }
        public EModel? Model { get; set; }
        public int? ManufactureYear { get; set; }
        public int? ModelYear { get; set; }        
        public string Chassi { get; set; }
        public string Renavam { get; set; }
    }
}

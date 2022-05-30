namespace TruckRegistration.Domain.Commands.Validations.Truck
{
    public class AddTruckValidation : TruckValidation<Entities.Truck>
    {
        public AddTruckValidation()
        {
            ValidateModel();
            ValidateModelYear();
            ValidateManufactureYear();
        }
    }
}

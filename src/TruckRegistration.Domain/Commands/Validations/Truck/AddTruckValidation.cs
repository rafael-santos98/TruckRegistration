namespace TruckRegistration.Domain.Commands.Validations.Truck
{
    public class AddTruckValidation : TruckValidation<Entities.Truck>
    {
        public AddTruckValidation()
        {
            ValidateDescription();
            ValidateModel();
            ValidateManufactureYear();
            ValidateModelYear();
            ValidateRenavam();
            ValidateColor();
        }
    }
}

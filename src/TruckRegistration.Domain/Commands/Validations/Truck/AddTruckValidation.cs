namespace TruckRegistration.Domain.Commands.Validations.Truck
{
    public class AddTruckValidation : TruckValidation<Entities.Truck>
    {
        public AddTruckValidation()
        {
            ValidateOrigem();
            ValidateDestino();
            ValidateValor();
            //ValidateExisteItem();
        }
    }
}

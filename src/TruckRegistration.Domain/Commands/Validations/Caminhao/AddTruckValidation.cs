namespace TruckRegistration.Domain.Commands.Validations.Caminhoes
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

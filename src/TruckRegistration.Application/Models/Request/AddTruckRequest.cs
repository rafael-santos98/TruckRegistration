namespace TruckRegistration.Application.Models.Request
{
    public class AddTruckRequest
    {
        public string Origem { get; set; }
        public string Destino { get; set; }
        public decimal Valor { get; set; }
    }
}

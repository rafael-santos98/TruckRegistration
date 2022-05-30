namespace TruckRegistration.Domain.Entities
{
    public class Truck : BaseEntity
    {
        public string Origem { get; set; }
        public string Destino { get; set; }
        public decimal Valor { get; set; }
    }
}

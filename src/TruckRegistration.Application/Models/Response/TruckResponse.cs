using System;

namespace TruckRegistration.Application.Models.Response
{
    public class TruckResponse
    {
        public Guid Id { get; set; }
        public string Origem { get; set; }
        public string Destino { get; set; }
        public decimal Valor { get; set; }
    }
}

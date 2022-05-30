using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TruckRegistration.Application.Models.Request;
using TruckRegistration.Application.Models.Response;

namespace TruckRegistration.Application.Contracts
{
    public interface ITruckAppService
    {
        Task<IEnumerable<TruckResponse>> GetAll();
        Task<TruckResponse> GetById(Guid id);
        BaseResponse Add(AddTruckRequest truckRequest);
        BaseResponse Update(Guid id, UpdateTruckRequest truckRequest);
        BaseResponse Delete(Guid id);
    }
}

using FluentValidation.Results;
using System;
using System.Collections.Generic;
using TruckRegistration.Domain.Entities;

namespace TruckRegistration.Application.Models.Response
{
    public class BaseResponse
    {
        public BaseResponse(BaseResult baseResult)
        {
            if (!baseResult.ValidationResult.IsValid)
            {
                IsValid = false;
                ValidationMessages = new List<string>();

                foreach (ValidationFailure failure in baseResult.ValidationResult.Errors)
                {
                    ValidationMessages.Add(failure.ErrorMessage);
                }
            }
            else
            {
                IsValid = true;
            }

            if (baseResult.ObjectItem != null)
            {
                ObjectItem = baseResult.ObjectItem;
            }

            if (baseResult.Id != null)
            {
                Id = baseResult.Id;
            }
        }

        public bool IsValid { get; set; }
        public List<string> ValidationMessages { get; set; }
        public object ObjectItem { get; set; }
        public Guid? Id { get; set; }
    }
}

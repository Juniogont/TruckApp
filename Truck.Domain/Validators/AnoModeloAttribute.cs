using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Truck.Domain.Entities;

namespace Truck.Domain.Validators
{
    public class AnoModeloAttribute : ValidationAttribute
    {
        public AnoModeloAttribute()
        {
        }

        public string GetErrorMessage() =>
            $"O Ano do modelo deve ser o ano atual ou o ano subsequente ao atual.";

        protected override ValidationResult IsValid(object value,
            ValidationContext validationContext)
        {
            var modelYear = ((int)value);
            var thisYear = DateTime.Now.Year;
            if (modelYear < thisYear || modelYear > thisYear + 1)
            {
                return new ValidationResult(GetErrorMessage());
            }

            return ValidationResult.Success;
        }
    }
}

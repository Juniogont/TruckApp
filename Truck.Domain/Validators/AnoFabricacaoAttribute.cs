using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Truck.Domain.Validators
{
    public class AnoFabricacaoAttribute : ValidationAttribute
    {
        public AnoFabricacaoAttribute()
        {
        }

        public string GetErrorMessage() =>
            $"O Ano de fabricação não pode ser diferente ao ano atual.";

        protected override ValidationResult IsValid(object value,
            ValidationContext validationContext)
        {
            var manufacturingYear = ((int)value);
            var thisYear = DateTime.Now.Year;
            if (manufacturingYear != thisYear)
            {
                return new ValidationResult(GetErrorMessage());
            }

            return ValidationResult.Success;
        }
    }
}

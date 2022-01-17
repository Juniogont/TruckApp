using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Truck.Domain.Validators
{    
    public class ModeloAttribute : ValidationAttribute
    {
        public ModeloAttribute()
        {
        }

        public string GetErrorMessage() =>
            $"Somente são permitidos os modelos FH e FM.";

        protected override ValidationResult IsValid(object value,
            ValidationContext validationContext)
        {
            var model = ((string)value);
            if (model !=  "FH" && model != "FM")
            {
                return new ValidationResult(GetErrorMessage());
            }

            return ValidationResult.Success;
        }
    }
}

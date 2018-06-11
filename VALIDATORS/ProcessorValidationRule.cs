using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WOZNY.PW.VALIDATORS
{
    public class ProcessorValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value == null || value.ToString().Length == 0)
            {
                return new ValidationResult(false, "Wartość nie może być nullem");
            }

            var producer = value.ToString().Trim().Split(' ')[0];
            if (producer.ToLower() != "intel" && producer.ToLower() != "amd")
            {
                return new ValidationResult(false, $"Nie ma takiej firmy jak {producer}");
            }

            return new ValidationResult(true, null);
        }
    }
}
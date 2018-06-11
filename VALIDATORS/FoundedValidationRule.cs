using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WOZNY.PW.VALIDATORS
{
    public class FoundedValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value == null || value.ToString().Length == 0)
            {
                return new ValidationResult(false, "Wartość nie może być nullem");
            }

            if (!int.TryParse(value.ToString(), out int converted))
            {
                return new ValidationResult(false, $"{value} to nie wartość całkowitoliczbowa");
            }

            if (converted < 0 || converted > 2018)
            {
                return new ValidationResult(false, "Wprowadzono nieprawidłową datę");
            }

            return new ValidationResult(true, null);
        }
    }
}
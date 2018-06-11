using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WOZNY.PW.VALIDATORS
{
    public class CountryValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value == null || value.ToString().Length == 0)
            {
                return new ValidationResult(false, "Wartość nie może być nullem");
            }

            return !char.IsUpper(value.ToString().Trim()[0])
                ? new ValidationResult(false, "Nazwa kraju musi się zaczynać z wielkiej litery")
                : new ValidationResult(true, null);
        }
    }
}
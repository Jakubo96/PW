using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WOZNY.PW.VM
{
    public class StringToIntValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            return value != null && int.TryParse(value.ToString(), out int i) && i > 20
                ? new ValidationResult(true, null)
                : new ValidationResult(false, "Please enter a valid integer value.");
        }
    }
}
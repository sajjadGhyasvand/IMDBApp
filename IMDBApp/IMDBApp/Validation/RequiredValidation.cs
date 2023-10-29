using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace IMDBApp.Validation
{
    public class RequiredValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (!string.IsNullOrEmpty(value?.ToString()))
                if (value.ToString() != "0")
                    return ValidationResult.ValidResult;
                else
                    return new ValidationResult(false, "لطفا یک گزینه را انتخاب کنید !");
            return new ValidationResult(false, "فیلد اجباری!");
        }
    }

}

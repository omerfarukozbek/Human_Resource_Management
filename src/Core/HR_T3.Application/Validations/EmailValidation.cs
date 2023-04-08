using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace HR_T3.Application.Validations
{
    public class EmailValidation : ValidationAttribute

    {
        public override bool IsValid(object? value)
        {

            if (value != null)
            {
                string email = value.ToString();
                MatchCollection matches = Regex.Matches(email, @"^[\w.+\-]+@bilgeadamboost\.com$",
                                             RegexOptions.IgnorePatternWhitespace);
                if (matches.Count > 0)
                {
                    return true;
                }
                return false;
            }
            return true;
        }


    }
}

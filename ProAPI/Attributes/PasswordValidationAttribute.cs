namespace RestAPI.Attributes
{
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    public class PasswordValidationAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value is not string password)
                return false;

            // Check password length (8-20 characters)
            if (password.Length < 8 || password.Length > 20)
                return false;

            // Check for at least one number
            if (!password.Any(char.IsDigit))
                return false;

            // Check for at least one lowercase letter
            if (!password.Any(char.IsLower))
                return false;

            // Check for at least one uppercase letter
            if (!password.Any(char.IsUpper))
                return false;

            // Check for at least one symbol
            var symbols = @"!"";#$%&'()*+,-./:;<=>?@[\]^_`{|}~";
            if (!password.Any(c => symbols.Contains(c)))
                return false;

            return true;
        }

        public override string FormatErrorMessage(string name)
        {
            return $"{name} must be 8-20 characters long and include at least one uppercase letter, one lowercase letter, one number, and one symbol.";
        }
    }

}

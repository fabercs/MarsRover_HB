using System.Text.RegularExpressions;

namespace hepsiburada.MarsRover.Helpers.Validator
{
    public abstract class InputValidator
    {
        public string RegexRule { get; set; }
        public virtual ValidationResult Validate(string input) {
            
            if(!string.IsNullOrWhiteSpace(input) && Regex.IsMatch(input, RegexRule))
                return new ValidationResult { Succeeded = true };
            else
                return new ValidationResult { Succeeded = false };
        }
    }
}

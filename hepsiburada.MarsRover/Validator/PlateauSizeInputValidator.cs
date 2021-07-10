namespace hepsiburada.MarsRover.Helpers.Validator
{
    public class PlateauSizeInputValidator : InputValidator
    {
        public PlateauSizeInputValidator()
        {
            RegexRule = @"^\d+\s\d+?$";
        }

        public override ValidationResult Validate(string input)
        {
            var validationResult = base.Validate(input);
            if(!validationResult.Succeeded)
            {
                validationResult.ErrorMessage = ScreenMessages.PLATEAU_SIZE_INPUT_INVALID;
            }
            else
            {
                var cooridantes = input.Split(' ');
                if (cooridantes[0] == "0" || cooridantes[1] == "0")
                {
                    validationResult.Succeeded = false;
                    validationResult.ErrorMessage = ScreenMessages.PLATEAU_SIZE_NOT_BE_ZERO;
                }
            }
            return validationResult;
        }
    }
}

namespace hepsiburada.MarsRover.Helpers.Validator
{
    public class RoverInstructionInputValidator : InputValidator
    {
        public RoverInstructionInputValidator()
        {
            RegexRule = @"\b[MLR]+\b(?![,])";
        }

        public override ValidationResult Validate(string input)
        {
            var validationResult = base.Validate(input);
            if (!validationResult.Succeeded)
            {
                validationResult.ErrorMessage = ScreenMessages.ROVER_INSTRUCTIONS_ERROR;
            }

            return validationResult;
        }
    }
}

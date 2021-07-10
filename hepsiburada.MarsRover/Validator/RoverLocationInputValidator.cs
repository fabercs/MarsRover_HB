using System;

namespace hepsiburada.MarsRover.Helpers.Validator
{
    public class RoverLocationInputValidator : InputValidator
    {
        public RoverLocationInputValidator()
        {
            RegexRule = @"^\d+\s\d+\s[WSNE]$";
        }

        public override ValidationResult Validate(string input)
        {
            var validationResult = base.Validate(input);
            if (!validationResult.Succeeded)
            {
                validationResult.ErrorMessage = ScreenMessages.ROVER_COORDINATE_ERROR;
            }
            else
            {
                var parameters = input.Split(' ');
                int x = Convert.ToInt32(parameters[0]);
                int y = Convert.ToInt32(parameters[1]);

                if (x < 0)
                {
                    validationResult.Succeeded = false;
                    validationResult.ErrorMessage = ScreenMessages.COORDINATE_X_AXIS_OUT_BOUNDRY;
                }

                if(y < 0)
                {
                    validationResult.Succeeded = false;
                    validationResult.ErrorMessage = ScreenMessages.COORDINATE_Y_AXIS_OUT_BOUNDRY;
                }
            }

            return validationResult;
        }
    }
}

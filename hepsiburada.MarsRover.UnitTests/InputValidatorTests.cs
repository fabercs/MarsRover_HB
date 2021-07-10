using hepsiburada.MarsRover.Helpers.Validator;
using NUnit.Framework;

namespace hepsiburada.MarsRover.UnitTests
{
    [TestFixture]
    public class InputValidatorTests
    {
        [Test]
        [TestCase("5 5", true)]
        [TestCase("21 1", true)]
        public void PlateauSizeValidator_Validate_Called_IsValid(string input, bool expectedResult)
        {
            var validator = new PlateauSizeInputValidator();
            var result = validator.Validate(input);

            Assert.That(result.Succeeded, Is.EqualTo(expectedResult));
        }

        [Test]
        [TestCase("0 5", false, Reason = "X axis is zero")]
        [TestCase("0 0", false, Reason = "Both axises are zero")]
        [TestCase("20 0", false, Reason ="Y axis is zero")]
        [TestCase("", false)]
        public void PlateauSizeValidator_Validate_Called_IsNotValid(string input, bool expectedResult)
        {
            var validator = new PlateauSizeInputValidator();
            var result = validator.Validate(input);

            Assert.That(result.Succeeded, Is.EqualTo(expectedResult));
        }

        [Test]
        [TestCase("0 1 N", true)]
        [TestCase("0 0 N", true)]
        [TestCase("8 10 E", true)]
        [TestCase("0 10 E", true)]
        public void RoverLocationValidator_Validate_Called_IsValid(string input, bool expectedResult)
        {
            var validator = new RoverLocationInputValidator();
            var result = validator.Validate(input);

            Assert.That(result.Succeeded, Is.EqualTo(expectedResult));
        }

        [Test]
        [TestCase("", false)]
        [TestCase("0 0", false)]
        [TestCase("1 2 X", false)]
        [TestCase("1 N", false)]
        public void RoverLocationValidator_Validate_Called_IsNotValid(string input, bool expectedResult)
        {
            var validator = new RoverLocationInputValidator();
            var result = validator.Validate(input);

            Assert.That(result.Succeeded, Is.EqualTo(expectedResult));

        }

        [Test]
        [TestCase("MMM", true)]
        [TestCase("MLRMLRRLM", true)]
        public void RoverInstructionValidator_Validate_Called_IsValid(string input, bool expectedResult)
        {
            var validator = new RoverInstructionInputValidator();
            var result = validator.Validate(input);

            Assert.That(result.Succeeded, Is.EqualTo(expectedResult));
        }

        [Test]
        [TestCase("XYZ", false)]
        [TestCase("", false)]
        [TestCase("MLRMMRRTRLM", false)]
        public void RoverInstructionValidator_Validate_Called_IsNotValid(string input, bool expectedResult)
        {
            var validator = new RoverInstructionInputValidator();
            var result = validator.Validate(input);

            Assert.That(result.Succeeded, Is.EqualTo(expectedResult));
        }
    }
}

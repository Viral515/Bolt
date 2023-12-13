namespace BoltPlugin.Model.UnitTests
{
    using NUnit.Framework;

    /// <summary>
    /// ValidatorTests.
    /// </summary>
    internal class ValidatorTests
    {
        [Test(Description = "Checking for a value in the range.")]
        public void Validate_IsValueInRange_SetCorrectValue_ReturnsTrue()
        {
            // Arrange
            var correctValue = 50;
            var correctMinValue = 10;
            var correctMaxValue = 100;
            var expected = true;

            // Act
            var actual = Validator.IsValueInRange(correctValue, correctMinValue, correctMaxValue);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test(Description = "Checking for a value less than the range.")]
        public void Validate_IsValueInRange_SetLowerValue_ReturnsFalse()
        {
            // Arrange
            var incorrectValue = 5;
            var correctMinValue = 10;
            var correctMaxValue = 100;
            var expected = false;

            // Act
            var actual = Validator.IsValueInRange(incorrectValue, correctMinValue, correctMaxValue);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test(Description = "Checking for a value greater than the range.")]
        public void Validate_IsValueInRange_SetLargerValue_ReturnsFalse()
        {
            // Arrange
            var incorrectValue = 500;
            var correctMinValue = 10;
            var correctMaxValue = 100;
            var expected = false;

            // Act
            var actual = Validator.IsValueInRange(incorrectValue, correctMinValue, correctMaxValue);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test(Description = "Checking if the value is lower than correct.")]
        public void Validate_IsValueLess_SetCorrectValue_ReturnsTrue()
        {
            // Arrange
            var correctValue = 50;
            var correctMaxValue = 100;
            var expected = true;

            // Act
            var actual = Validator.IsValueLess(correctValue, correctMaxValue);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test(Description = "Checking if the value is larger than correct.")]
        public void Validate_IsValueLess_SetIncorrectValue_ReturnsFalse()
        {
            // Arrange
            var correctValue = 500;
            var correctMaxValue = 100;
            var expected = false;

            // Act
            var actual = Validator.IsValueLess(correctValue, correctMaxValue);

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}

using Xunit;

namespace StackCalculatorLogic.Tests
{
    public class StackCalculatorServiceTests
    {
        [Fact]
        public void Calculate_CanAdd()
        {
            //Arrange
            var input = "12+";
            var expected = 3;

            //Act
            var actual = StackCalculatorService.Calculate(input);

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Calculate_CanSubtract()
        {
            //Arrange
            var input = "13-";
            var expected = 2;

            //Act
            var actual = StackCalculatorService.Calculate(input);

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Calculate_CanMultiply()
        {
            //Arrange
            var input = "23*";
            var expected = 6;

            //Act
            var actual = StackCalculatorService.Calculate(input);

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Calculate_CanDivide()
        {
            //Arrange
            var input = "28/";
            var expected = 4;

            //Act
            var actual = StackCalculatorService.Calculate(input);

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Calculate_SupportsAllOperationsInOneInput()
        {
            //Arrange
            var input = "13-2+8/3*"; 
            var expected = 6;

            //Act
            var actual = StackCalculatorService.Calculate(input);

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ScrubInput_RemovesDisallowedCharacters()
        {
            //Arrange
            //TODO: Figure out a better way to get complete set of disallowed characters.
            var input = "1234567890+-*/!#¤%&()=?`@£$€{[]}|¨^~',;.:_<>\\ ";
            var expected = "1234567890+-*/";

            //Act
            var actual = StackCalculatorService.ScrubInput(input);

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TryCalculate_WhenInputIsInvalid_ReturnsError()
        {
            //Arrange
            var input = "1+";
            var expected = "Invalid input";

            //Act
            var sut = new StackCalculatorService();
            var actual = sut.TryCalculate(input);

            //Assert
            Assert.Equal(expected, actual);
        }
    }
}
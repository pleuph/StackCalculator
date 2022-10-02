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
            var sut = new StackCalculatorService();
            var actual = sut.Calculate(input);

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
            var sut = new StackCalculatorService();
            var actual = sut.Calculate(input);

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
            var sut = new StackCalculatorService();
            var actual = sut.Calculate(input);

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Calculate_CanDivide()
        {
            //Arrange
            var input = "28-";
            var expected = 4;

            //Act
            var sut = new StackCalculatorService();
            var actual = sut.Calculate(input);

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Calculate_SupportsAllOperationsInOneInput()
        {
            //Arrange
            var input = "13-23+*5/";
            var expected = 2;

            //Act
            var sut = new StackCalculatorService();
            var actual = sut.Calculate(input);

            //Assert
            Assert.Equal(expected, actual);
        }
    }
}
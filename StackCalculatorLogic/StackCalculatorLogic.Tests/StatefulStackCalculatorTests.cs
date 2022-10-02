using Xunit;

namespace StackCalculatorLogic.Tests
{
    public class StatefulStackCalculatorTests
    {
        [Fact]
        public void CanAdd()
        {
            //Arrange
            var a = 5.5;
            var b = 8.3;
            var expected = a + b;

            //Act
            var sut = new StatefulStackCalculator();
            sut.Enter(a);
            var actual = sut.Add(b);

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CanSubtract()
        {
            //Arrange
            var a = 5.5;
            var b = 8.3;
            var expected = a - b;

            //Act
            var sut = new StatefulStackCalculator();
            sut.Enter(a);
            var actual = sut.Subtract(b);

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CanMultiply()
        {
            //Arrange
            var a = 5.5;
            var b = 8.3;
            var expected = a * b;

            //Act
            var sut = new StatefulStackCalculator();
            sut.Enter(a);
            var actual = sut.Multiply(b);

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CanDivide()
        {
            //Arrange
            var a = 5.5;
            var b = 8.3;
            var expected = a / b;

            //Act
            var sut = new StatefulStackCalculator();
            sut.Enter(a);
            var actual = sut.Divide(b);

            //Assert
            Assert.Equal(expected, actual);
        }
    }
}

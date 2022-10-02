using System;
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
            var expected = b + a;

            //Act
            var sut = new StatefulStackCalculator();
            sut.Enter(a);
            sut.Enter(b);
            var actual = sut.Add();

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CanSubtract()
        {
            //Arrange
            var a = 5.5;
            var b = 8.3;
            var expected = b - a;

            //Act
            var sut = new StatefulStackCalculator();
            sut.Enter(a);
            sut.Enter(b);
            var actual = sut.Subtract();

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CanMultiply()
        {
            //Arrange
            var a = 5.5;
            var b = 8.3;
            var expected = b * a;

            //Act
            var sut = new StatefulStackCalculator();
            sut.Enter(a);
            sut.Enter(b);
            var actual = sut.Multiply();

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CanDivide()
        {
            //Arrange
            var a = 5.5;
            var b = 8.3;
            var expected = b / a;

            //Act
            var sut = new StatefulStackCalculator();
            sut.Enter(a);
            sut.Enter(b);
            var actual = sut.Divide();

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void DivideByZero_ReturnsInfinity()
        {
            //Arrange
            var a = 0;
            var b = 8.3;
            var expected = double.PositiveInfinity;

            //Act
            var sut = new StatefulStackCalculator();
            sut.Enter(a);
            sut.Enter(b);
            var actual = sut.Divide();

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void WhenStackCountLessThanTwo_ReturnZero()
        {
            //Arrange
            var a = 5.5;
            var expected = 0;

            //Act
            var sut = new StatefulStackCalculator();
            sut.Enter(a);
            var actual = sut.Divide();

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SupportsMultipleOperations()
        {
            //Arrange
            var a = 5.5;
            var b = 8.3;
            var c = 14.5;
            var d = 9.2;
            var e = 4.7;
            var expected = e / ((d * c) - (b + a));

            //Act
            var sut = new StatefulStackCalculator();
            sut.Enter(a);
            sut.Enter(b);
            sut.Enter(sut.Add());
            sut.Enter(c);
            sut.Enter(d);
            sut.Enter(sut.Multiply());
            sut.Enter(sut.Subtract());
            sut.Enter(e);
            var actual = sut.Divide();

            //Assert
            Assert.Equal(expected, actual);
        }
    }
}

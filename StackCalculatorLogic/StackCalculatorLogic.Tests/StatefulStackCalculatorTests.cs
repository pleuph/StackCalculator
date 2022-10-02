using Xunit;

namespace StackCalculatorLogic.Tests
{
    public class StatefulStackCalculatorTests
    {
        [Fact]
        public async void CanAdd()
        {
            //Arrange
            var a = 5.5;
            var b = 8.3;
            var expected = b + a;
            var sut = new StatefulStackCalculator();

            //Act
            sut.Enter(a);
            sut.Enter(b);
            var actual = await sut.Add();

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public async void CanSubtract()
        {
            //Arrange
            var a = 5.5;
            var b = 8.3;
            var expected = b - a;
            var sut = new StatefulStackCalculator();

            //Act
            sut.Enter(a);
            sut.Enter(b);
            var actual = await sut.Subtract();

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public async void CanMultiply()
        {
            //Arrange
            var a = 5.5;
            var b = 8.3;
            var expected = b * a;
            var sut = new StatefulStackCalculator();

            //Act
            sut.Enter(a);
            sut.Enter(b);
            var actual = await sut.Multiply();

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public async void CanDivide()
        {
            //Arrange
            var a = 5.5;
            var b = 8.3;
            var expected = b / a;
            var sut = new StatefulStackCalculator();

            //Act
            sut.Enter(a);
            sut.Enter(b);
            var actual = await sut.Divide();

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public async void DivideByZero_ReturnsInfinity()
        {
            //Arrange
            var a = 0;
            var b = 8.3;
            var expected = double.PositiveInfinity;
            var sut = new StatefulStackCalculator();

            //Act
            sut.Enter(a);
            sut.Enter(b);
            var actual = await sut.Divide();

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public async void WhenStackCountLessThanTwo_ReturnZero()
        {
            //Arrange
            var a = 5.5;
            var expected = 0;
            var sut = new StatefulStackCalculator();

            //Act
            sut.Enter(a);
            var actual = await sut.Divide();

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public async void SupportsMultipleOperations()
        {
            //Arrange
            var a = 5.5;
            var b = 8.3;
            var c = 14.5;
            var d = 9.2;
            var e = 4.7;
            var expected = e / ((d * c) - (b + a));
            var sut = new StatefulStackCalculator();

            //Act            
            sut.Enter(a);
            sut.Enter(b);
            sut.Enter(await sut.Add());
            sut.Enter(c);
            sut.Enter(d);
            sut.Enter(await sut.Multiply());
            sut.Enter(await sut.Subtract());
            sut.Enter(e);
            var actual = await sut.Divide();

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public async void TenthOperationReturnsRandomNumber()
        {
            //Arrange
            var sut = new StatefulStackCalculator();

            //Act
            sut.Enter(0);
            sut.Enter(0);
            for(int i = 0; i < 9; i++)
            {
                sut.Enter(await sut.Add());
                sut.Enter(0);
            }
            var actual = await sut.Add();

            //Assert
            Assert.NotEqual(0, actual);
        }

        [Fact]
        public async void GetRandomReturnsResult()
        {
            //Arrange
            var sut = new StatefulStackCalculator();

            //Act
            var actual = await sut.GetRandom();

            //Assert
            Assert.NotEqual(0, actual);
        }
    }
}

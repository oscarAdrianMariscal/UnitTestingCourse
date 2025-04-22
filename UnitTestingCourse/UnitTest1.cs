using System.Globalization;
using FluentAssertions;
using Xunit;

namespace UnitTestingCourse
{
    public class UnitTest1
    {
        readonly NetworkTesting _networkTester;
        public UnitTest1()
        {
            //SUT System under test
            _networkTester = new NetworkTesting();
        }

        [Fact]
        public void NetworkTesting_SendPing_ReturnString()
        {
            //Arrange

            //Act
            var result = _networkTester.SendPing();
            //Assert

            result.Should().NotBeNullOrEmpty();
            result.Should().Be("Success: ping send");
        }


        [Theory]
        [InlineData(1, 2, 3)]
        [InlineData(2, 2, 4)]
        public void NetworkTesting_TestTimeout_ReturnInt(int a, int b, int expected)
        {
            //Arrange

            //Act
            var result = _networkTester.TestTimeout(a, b);
            //Assert
            result.Should().Be(expected);
            result.Should().BeGreaterThanOrEqualTo(1);
        }
        [Fact]
        public void NetworkTesting_LastLogonDateAttempt_ReturnDateTime()
        {
            //Arrange
            var creationDateUser = new DateTime(2000, 4, 16);


            //Act
            var result = _networkTester.LastLogonDateAttempt();
            //Assert
            result.Should().BeAfter(creationDateUser);

        }
    }
}
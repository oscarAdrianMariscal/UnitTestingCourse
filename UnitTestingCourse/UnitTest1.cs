using FluentAssertions;
using Xunit;

namespace UnitTestingCourse
{
    public class UnitTest1
    {
        [Fact]
        public void NetworkTesting_SendPing_ReturnString()
        {
            //Arrange
            NetworkTesting networkTester = new NetworkTesting();
            //Act
            var result = networkTester.SendPing();
            //Assert

            result.Should().NotBeNullOrEmpty();
            result.Should().Be("Success: ping send");
        }
    }
}
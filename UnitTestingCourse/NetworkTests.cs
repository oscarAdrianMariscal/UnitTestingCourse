using System.Globalization;
using FakeItEasy;
using FluentAssertions;
using UnitTestingCourse.DNS;
using Xunit;

namespace UnitTestingCourse
{
    public class NetworkTests
    {
        readonly NetworkTesting _networkTester;
        readonly IDns _dns;
        public NetworkTests()
        {
            //Dependency injection example with fakeiteasy
            _dns = A.Fake<IDns>();

            //SUT System under test
            _networkTester = new NetworkTesting(_dns);
        }

        [Fact]
        public void NetworkTesting_SendPing_ReturnString()
        {
            //Arrange
            A.CallTo(() => _dns.SendDns()).Returns (true) ;
            //Act
            var result = _networkTester.SendPing();
            //Assert

            result.Should().NotBeNullOrEmpty();
            result.Should().Be("Success: ping sent");
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
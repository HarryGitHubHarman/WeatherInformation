using Moq;
using Services;
using Xunit;

namespace XUnitTestProject
{
    public class WeatherReportTest
    {
        [Theory]
        [InlineData(10)]
        [InlineData(9)]
        public void WeatherReport_ProcessData_Test(int value)
        {
            // Arrange
            var mockReport = new Mock<IWeatherRepository>();
            mockReport.Setup(rep => rep.GetWeatherReport()).Returns(value);
            var testReport = mockReport.Object;

            // Act
            var result = testReport.GetWeatherReport();

            // Assert
            Assert.Equal(value,result);
        }
    }
}

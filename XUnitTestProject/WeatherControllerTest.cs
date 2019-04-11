using Microsoft.AspNetCore.Mvc;
using Moq;
using OpenWeatherService;
using Services;
using WeatherApp.Controllers;
using Xunit;

namespace XUnitTestProject
{
    public class WeatherControllerTest
    {
        [Theory]
        [InlineData(5)]
        public void GetWeather_Test(int Value)
        {
            // Arrange
            var mockWR = new Mock<IWeatherRepository>();
            mockWR.Setup(wr => wr.GetWeatherReport()).Returns(Value);
            var mockWS = new Mock<IWeatherService>();
            mockWS.Setup(ws => ws.GetWeather(Value)).ReturnsAsync($"Weather data for cityId {Value}");
            var controller = new WeatherController(mockWR.Object);

            // Act
            var result = controller.GetWeatherReport();

            // Assert
            Assert.IsType<JsonResult>(result);
            Assert.Equal(new JsonResult($"message : {Value} cities processed for weather data").Value, result.Value);
        }
    }
}

using System.Net.Http;
using System.Threading.Tasks;

namespace OpenWeatherService
{
    /// <summary>
    /// WeatherService 
    /// </summary>
    public class WeatherService : IWeatherService
    {
        private const string api_key = "aa69195559bd4f88d79f9aadeb77a8f6";
        private const string api_uri = "https://api.openweathermap.org/data/2.5/weather?id=";
        private HttpClient Client { get; set; }

        /// <summary>
        /// Constructor : WeatherService
        /// </summary>
        public WeatherService()
        {
            Client = new HttpClient();
        }

        /// <summary>
        /// GetWeather
        /// </summary>
        /// <param name="CityId">CityID</param>
        /// <returns>Weather information in JSON format</returns>
        public async Task<string> GetWeather(int CityId)
        {
            var json = await Client.GetStringAsync(api_uri + CityId + "&APPID=" + api_key);
            return json;
        }

    }
}

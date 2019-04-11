using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OpenWeatherService
{
    /// <summary>
    /// IWeatherService
    /// </summary>
    public interface IWeatherService
    {
        /// <summary>
        /// GetWeather
        /// </summary>
        /// <param name="id">City ID</param>
        /// <returns>Weather information in JSON format</returns>
        Task<string> GetWeather(int id);
    }
}

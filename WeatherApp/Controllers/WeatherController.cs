using Microsoft.AspNetCore.Mvc;
using Services;

namespace WeatherApp.Controllers
{
    /// <summary>
    /// Weather Controller, which handles incoming requests.
    /// Route : api/controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherController : ControllerBase
    {
        private IWeatherRepository _repository;
        /// <summary>
        /// WeatherController Constructor
        /// </summary>
        /// <param name="repository">IWeatherRepository repository</param>
        public WeatherController(IWeatherRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// GET api/Weather
        /// </summary>
        /// <returns>JsonResult</returns>
        [HttpGet]
        public JsonResult GetWeatherReport()
        {
            var dataCount = _repository.GetWeatherReport();
            var msg = string.Format(@"message : {0} cities processed for weather data", dataCount);
            return new JsonResult(msg);
        }
    }
}      
    


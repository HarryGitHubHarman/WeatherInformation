using Model;
using Newtonsoft.Json;
using OpenWeatherService;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Services
{
    /// <summary>
    /// Class : WeatherRepository 
    /// </summary>
    public class WeatherRepository : IWeatherRepository
    {
        private IWeatherService _weatherRepository { get; set; }
        private string InputPath { get; set; }
        private string OutputPath { get; set; }

        /// <summary>
        /// Constructor : WeatherRepository
        /// </summary>
        /// <param name="weatherRepository">IWeatherService</param>
        public WeatherRepository(IWeatherService weatherRepository )
        {
            _weatherRepository = weatherRepository;
        }

        /// <summary>
        /// GetWeatherReport
        /// </summary>
        /// <returns>count of cities processed</returns>
        public int GetWeatherReport()
        {
            string file = Path.GetFullPath("Files\\data.json");
            string data = File.ReadAllText(file);
            List<CityViewModel> cityData = new List<CityViewModel>();
            dynamic list = JsonConvert.DeserializeObject(data);
            foreach (var item in list)
            {
                var cityInfo = new CityViewModel { ID = item.id, Name = item.name };
                GetWeatherData(cityInfo);
                cityData.Add(cityInfo);
            }
            return cityData.Count();
        }

        /// <summary>
        /// GetWeatherData
        /// </summary>
        /// <param name="dataModel">CityViewModel </param>
        private async void GetWeatherData(CityViewModel dataModel)
        {
            var result = await _weatherRepository.GetWeather(dataModel.ID);
            SaveData(result, dataModel.ID, dataModel.Name);
        }

        /// <summary>
        /// SaveData
        /// </summary>
        /// <param name="result">Save the data in .JSON file</param>
        /// <param name="key">CityID</param>
        /// <param name="name">CityName</param>
        private void SaveData(string result, int key, string name)
        {
            DirectoryInfo dirInfo = Directory.CreateDirectory("OutPut\\" + DateTime.Now.ToLongDateString());
            StringBuilder sb = new StringBuilder(dirInfo.FullName);
            sb.Append("\\" + key);
            sb.Append("_" + name);
            sb.Append(".json");
            File.WriteAllText(sb.ToString(), result);
        }
      
    }
}

namespace Services
{
    /// <summary>
    /// Interface : IWeatherRepository 
    /// </summary>
    public interface IWeatherRepository
    {
        /// <summary>
        /// Method : GetWeatherReport
        /// </summary>
        /// <returns>count of cities processed</returns>
        int GetWeatherReport();
    }
}

using Newtonsoft.Json;

namespace Weather
{
    public struct WeatherInfo
    {
        [JsonProperty("main")]
        public MainWeatherInfo Main { get; set; }
    }
}

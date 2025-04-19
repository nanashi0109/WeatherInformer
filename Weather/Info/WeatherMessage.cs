namespace Weather
{
    public struct WeatherMessage
    {
        #region Properties
        public float Temperature => _temperature;

        public float FeelsLike => _feelsLike;

        public int Humidity => _humidity;

        public int Pressure => _pressure;
        #endregion

        private readonly float _temperature;
        private readonly float _feelsLike;
        private readonly int _humidity;
        private readonly int _pressure;

        public WeatherMessage(float temperature, float feelsLike, int humidity, int pressure)
        {
            _temperature = temperature;
            _feelsLike = feelsLike;
            _humidity = humidity;
            _pressure = pressure;
        }

        public WeatherMessage(WeatherInfo info)
        {
            _temperature = info.Main.Temperature;
            _feelsLike = info.Main.FeelsLike;
            _humidity = info.Main.Humidity;
            _pressure = info.Main.Pressure;
        }
    }
}

namespace Weather
{
    public interface IWeatherSubscriber
    {
        void Update(WeatherMessage message);
    }
}

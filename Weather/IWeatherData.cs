namespace Weather
{
    public interface IWeatherData : IWeatherPublisher
    {
        void Notify();
    }
}

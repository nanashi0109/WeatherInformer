namespace Weather
{
    public interface IWeatherPublisher
    {
        void AddListener(IWeatherSubscriber subscriber);
        void RemoveListener(IWeatherSubscriber subscriber);
    }
}

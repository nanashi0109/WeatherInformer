namespace Weather
{
    public interface IWeatherData : IWeatherPublisher
    {
        void UpdateData();
        void Notify();
    }
}

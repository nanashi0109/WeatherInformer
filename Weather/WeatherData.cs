using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Tools;

namespace Weather
{
    public class WeatherData : IWeatherData
    {
        private List<IWeatherSubscriber> _subscribers;

        private WeatherInfo _weatherInfo;

        public WeatherData()
        {
            _subscribers = new List<IWeatherSubscriber>();
        }

        #region Publisher methods
        public void AddListener(IWeatherSubscriber subscriber)
        {
            if (_subscribers.Contains(subscriber))
            {
                Console.WriteLine("Subscriber is already registered");
                return;
            }

            _subscribers.Add(subscriber);
        }

        public void RemoveListener(IWeatherSubscriber subscriber)
        {
            if (!_subscribers.Contains(subscriber))
            {
                Console.WriteLine("This subscriber is not registered");
                return;
            }

            _subscribers.Remove(subscriber);
        }

        public void Notify()
        {
            WeatherMessage message = new WeatherMessage(_weatherInfo);

            foreach (var subscriber in _subscribers)
                subscriber.Update(message);
        }
        #endregion

        public async void UpdateData()
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    await UpdateInfo(client);
                    Notify();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private async Task UpdateInfo(HttpClient client)
        {
            var response = await GetResponse(client);

            _weatherInfo = JsonConvert.DeserializeObject<WeatherInfo>(response);
        }

        private async Task<string> GetResponse(HttpClient client)
        {
            string url = $"{Constants.SITE_URL}/data/2.5/weather?q=Moscow&appid={Constants.API_KEY}&units=metric";
            HttpResponseMessage response = await client.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine($"Error: {response.StatusCode}");
            }

            return await response.Content.ReadAsStringAsync();
        }
    }
}

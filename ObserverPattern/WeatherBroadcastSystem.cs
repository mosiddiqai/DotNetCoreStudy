

using System.Collections.Generic;

namespace ObserverPattern
{
    public interface IObservable
    {
        void Add(IObserver observer);
        void Delete(IObserver observer);
        void Notify();
    }

    public class WeatherData
    {
        public int temparature = 0;
    }

    public class WeatherStation : IObservable
    {
        public WeatherData weatherData;
        public WeatherStation(WeatherData weatherData)
        {
            this.weatherData = weatherData;
        }
        int temparature = 0;
        public List<IObserver> observers = new List<IObserver>();
        public void Add(IObserver observer)
        {
            this.observers.Add(observer);
        }

        public void Delete(IObserver observer)
        {
            this.observers.Remove(observer);
        }

        public void Notify()
        {
            this.observers.ForEach(o => o.Update());
        }

        public int GetTemparature()
        {
            return this.weatherData.temparature;
        }

        public void UpdateTemparature(int temparature)
        {
            this.weatherData.temparature = temparature;

            this.Notify();
        }
    }

    public interface IObserver
    {
        void Update();
    }

    public class AndriodPhoneDisplay : IObserver
    {
        public WeatherData weatherData;
        public AndriodPhoneDisplay(WeatherData weatherData)
        {
            this.weatherData = weatherData;
        }
        public void Update()
        {
            System.Console.WriteLine($"I got the update!!!");
            System.Console.WriteLine($"Weather {this.weatherData.temparature}, Displayed by Andriod phone!!!!");
        }
    }

    public class IPhonePhoneDisplay : IObserver
    {
        public WeatherData weatherData;
        public IPhonePhoneDisplay(WeatherData weatherData)
        {
            this.weatherData = weatherData;
        }
        public void Update()
        {
            System.Console.WriteLine($"I got the update!!!");
            System.Console.WriteLine($"Weather {this.weatherData.temparature}, Displayed by IPhone phone!!!!");
        }
    }

    public class LCDDisplay : IObserver
    {
        public WeatherData weatherData;
        public LCDDisplay(WeatherData weatherData)
        {
            this.weatherData = weatherData;
        }
        public void Update()
        {
            System.Console.WriteLine($"I got the update!!!");
            System.Console.WriteLine($"Weather {this.weatherData.temparature}, Displayed by LCS devices!!!!");
        }
    }
}

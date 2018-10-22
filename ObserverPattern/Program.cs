using System;


namespace ObserverPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=================Weather Staion================");
            WeatherData weatherData = new WeatherData();
            WeatherStation weatherStation = new WeatherStation(weatherData);
            AndriodPhoneDisplay andriodPhoneDisplay = new AndriodPhoneDisplay(weatherStation.weatherData);
            IPhonePhoneDisplay iPhonePhoneDisplay = new IPhonePhoneDisplay(weatherStation.weatherData);
            LCDDisplay lcdDisplay = new LCDDisplay(weatherStation.weatherData);

            weatherStation.Add(andriodPhoneDisplay);
            weatherStation.Add(iPhonePhoneDisplay);
            weatherStation.Add(lcdDisplay);

            Console.WriteLine("=================Weather check at #1 ================");
            weatherStation.UpdateTemparature(30);

            Console.WriteLine("=================Weather check at #2 ================");
            weatherStation.UpdateTemparature(60);

            Console.WriteLine("=================Weather check at #3 ================");
            weatherStation.UpdateTemparature(25);

            Console.WriteLine("================================================");

            Console.ReadLine();
        }
    }
}

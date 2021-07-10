using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Xml;

namespace XmlParse
{
    public class WeatherForecast
    {
        private List<Weather> _weather;

        public WeatherForecast()
        {
            _weather = new List<Weather>();
        }

        private void UpdateInformation()
        {
            string url = @"http://api.pogoda.com/index.php?api_lang=ru&localidad=13088&affiliate_id=4v7j6at7rkya";
            using (var wc = new WebClient(){Encoding = Encoding.UTF8})
            {
                try
                {
                    wc.DownloadFile(url, "weather.xml");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        private void ParseFile()
        {
            UpdateInformation();
            
            XmlTextReader reader = null;
            bool min_temp = false;
            bool max_temp = false;
            bool wind = false;
            bool clouds = false;
            
            List<int> minTemp = new List<int>();
            List<int> maxTemp = new List<int>();
            List<string> winds = new List<string>();
            List<string> overcast = new List<string>();
            
            try
            {
                using (reader = new XmlTextReader("weather.xml"))
                {
                    reader.WhitespaceHandling = WhitespaceHandling.None;
                    
                    while (reader.Read())
                    {
                        if (reader.Value == "Мин. температура")
                            min_temp = true;
                        if (min_temp)
                        {
                            if (reader.Name == "forecast")
                            {
                                reader.MoveToNextAttribute();
                                reader.MoveToNextAttribute();
                                minTemp.Add(int.Parse(reader.Value));
                                //Console.WriteLine($"Name: {reader.Name} -> Value: {reader.Value}");
                            }
                            if (minTemp.Count == 7)
                                min_temp = false;
                        }
                        
                        if (reader.Value == "Макс. температура")
                            max_temp = true;
                        if (max_temp)
                        {
                            if (reader.Name == "forecast")
                            {
                                reader.MoveToNextAttribute();
                                reader.MoveToNextAttribute();
                                maxTemp.Add(int.Parse(reader.Value));
                                //Console.WriteLine($"Name: {reader.Name} -> Value: {reader.Value}");
                            }
                            if (maxTemp.Count == 7)
                                max_temp = false;
                        }
                        
                        if (reader.Value == "Ветер")
                            wind = true;
                        if (wind)
                        {
                            if (reader.Name == "forecast")
                            {
                                reader.MoveToNextAttribute();
                                reader.MoveToNextAttribute();
                                reader.MoveToNextAttribute();
                                reader.MoveToNextAttribute();
                                winds.Add(reader.Value);
                                //Console.WriteLine($"Name: {reader.Name} -> Value: {reader.Value}");
                            }
                            if (winds.Count == 7)
                                wind = false;
                        }
                        
                        if (reader.Value == "Метеорологический знак")
                            clouds = true;
                        if (clouds)
                        {
                            if (reader.Name == "forecast")
                            {
                                reader.MoveToNextAttribute();
                                reader.MoveToNextAttribute();
                                reader.MoveToNextAttribute();
                                reader.MoveToNextAttribute();
                                overcast.Add(reader.Value);
                                //Console.WriteLine($"Name: {reader.Name} -> Value: {reader.Value}");
                            }
                            if (overcast.Count == 7)
                                clouds = false;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Weather weather;
            for (int i = 0; i < 7; i++)
            {
                weather = new Weather()
                    {MaxTemp = maxTemp[i], MinTemp = minTemp[i], Overcast = overcast[i], Wind = winds[i]};
                _weather.Add(weather);
            }
        }

        public void GetForecast()
        {
            ParseFile();
            int i = 1;
            foreach (var weather in _weather)
            {
                Console.WriteLine($"Day_{i++}");
                Console.WriteLine(weather);
                Console.WriteLine();
            }
        }
    }
}